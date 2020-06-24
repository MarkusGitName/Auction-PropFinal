using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc; 

using System.Net;
using System.Configuration;
using System.Threading.Tasks;

using PayFast;
using PayFast.AspNet;

using Auction_Prop_Buyers.Models.DisplayMadels;
using Microsoft.AspNet.Identity;

namespace Auction_Prop_Buyers.Controllers
{
    public class PaymentController : Controller
    {
        // GET: Payment
        #region Fields

        private readonly PayFastSettings payFastSettings;

        #endregion Fields

        #region Constructor

        public PaymentController()
        {
            this.payFastSettings = new PayFastSettings();
            this.payFastSettings.MerchantId = ConfigurationManager.AppSettings["MerchantId"];
            this.payFastSettings.MerchantKey = ConfigurationManager.AppSettings["MerchantKey"];
            this.payFastSettings.PassPhrase = ConfigurationManager.AppSettings["PassPhrase"];
            this.payFastSettings.ProcessUrl = ConfigurationManager.AppSettings["ProcessUrl"];
            this.payFastSettings.ValidateUrl = ConfigurationManager.AppSettings["ValidateUrl"];
            this.payFastSettings.ReturnUrl = ConfigurationManager.AppSettings["Auction-prop.com"];
            this.payFastSettings.CancelUrl = ConfigurationManager.AppSettings["Auction-prop.com"];
            this.payFastSettings.NotifyUrl = ConfigurationManager.AppSettings["Auction-prop.com"];
        }

        #endregion Constructor

        #region Methods

        public ActionResult Index()
        {
            return View();
        }
           
        public ActionResult Deposit()
        {
            return OnceOff( 5000,0);
        }
        
        public ActionResult AdminFees(int id)
        {
            return OnceOff(150, id);
        }
        public ActionResult AdminAndDeposit(int id)
        {
            return OnceOff(5150,id);
        }

       



        public ActionResult OnceOff(double amount,  int idd)
        {
            var onceOffRequest = new PayFastRequest(this.payFastSettings.PassPhrase);

            // Merchant Details
            onceOffRequest.merchant_id = this.payFastSettings.MerchantId;
            onceOffRequest.merchant_key = this.payFastSettings.MerchantKey;
            onceOffRequest.return_url = this.payFastSettings.ReturnUrl;
            onceOffRequest.cancel_url = this.payFastSettings.CancelUrl;
            onceOffRequest.notify_url = this.payFastSettings.NotifyUrl;

            onceOffRequest.email_address = "sbtu01@payfast.co.za";

            // Transaction Details
            onceOffRequest.m_payment_id = idd.ToString();
            onceOffRequest.amount = 50;
            onceOffRequest.item_name = "Once off option";
            onceOffRequest.item_description = "Some details about the once off payment";

            // Transaction Options
            onceOffRequest.email_confirmation = true;
            onceOffRequest.confirmation_address = "sbtu01@payfast.co.za";
            // Transaction Options
            onceOffRequest.email_confirmation = true;
            onceOffRequest.confirmation_address = "";

            var redirectUrl = $"{this.payFastSettings.ProcessUrl}{onceOffRequest.ToString()}";

            if (idd != 0)
            { 
            
                AdminFee fees = new AdminFee
                {
                    PaymentID = idd,
                    ProofOfPaymentPath = "none",
                    DateOfPayment = DateTime.Now,
                    Amount = 150

                };
                APILibrary.APIMethods.APIPost<Deposit>(fees, "AdminFees");
                
            }
            if(amount>=500)
            {
                Deposit dep = new Deposit
                {
                    BuyerID = User.Identity.GetUserId(),
                    DateOfPayment = DateTime.Now,
                    Paid = true,
                    DepositReturned = false,
                    ProofOfPaymentPath = "none",
                    ProofOfReturnPayment = "none"
                };
                APILibrary.APIMethods.APIPost<Deposit>(dep, "Deposits");
               
            }


            return Redirect(redirectUrl);
        }

       

        public ActionResult Return()
        {

            return View();
        }

        [HttpPost]
        public void _PayAdminFees(int id, AuctionRegistration reg)
        {
            AdminFee fees = new AdminFee
            {
                PaymentID = reg.id,
                ProofOfPaymentPath = "none",
                DateOfPayment = DateTime.Now,
                Amount = 150

            };
            APILibrary.APIMethods.APIPost<Deposit>(fees, "AdminFees");



        }

        public ActionResult Cancel()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Notify([ModelBinder(typeof(PayFastNotifyModelBinder))]PayFastNotify payFastNotifyViewModel)
        {
            payFastNotifyViewModel.SetPassPhrase(this.payFastSettings.PassPhrase);

            var calculatedSignature = payFastNotifyViewModel.GetCalculatedSignature();

            var isValid = payFastNotifyViewModel.signature == calculatedSignature;

            System.Diagnostics.Debug.WriteLine($"Signature Validation Result: {isValid}");

            // The PayFast Validator is still under developement
            // Its not recommended to rely on this for production use cases
            var payfastValidator = new PayFastValidator(this.payFastSettings, payFastNotifyViewModel, IPAddress.Parse(this.HttpContext.Request.UserHostAddress));

            var merchantIdValidationResult = payfastValidator.ValidateMerchantId();

            System.Diagnostics.Debug.WriteLine($"Merchant Id Validation Result: {merchantIdValidationResult}");

            var ipAddressValidationResult = payfastValidator.ValidateSourceIp();

            System.Diagnostics.Debug.WriteLine($"Ip Address Validation Result: {merchantIdValidationResult}");

            // Currently seems that the data validation only works for successful payments
            if (payFastNotifyViewModel.payment_status == PayFastStatics.CompletePaymentConfirmation)
            {
                var dataValidationResult = await payfastValidator.ValidateData();

                System.Diagnostics.Debug.WriteLine($"Data Validation Result: {dataValidationResult}");
            }

            if (payFastNotifyViewModel.payment_status == PayFastStatics.CancelledPaymentConfirmation)
            {
                System.Diagnostics.Debug.WriteLine($"Subscription was cancelled");
            }

            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }

        public ActionResult Error()
        {
            return View();
        }

        #endregion Methods
    }
}