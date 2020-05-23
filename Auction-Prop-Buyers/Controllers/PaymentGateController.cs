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
using System.Web.Security;
using Auction_Prop_Buyers.Models;
using Microsoft.AspNet.Identity;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using Auction_Prop_Buyers.Models.DisplayMadels;

namespace Auction_Prop_Buyers.Controllers
{
    public class PaymentGateController : Controller
    {
    

        #region Fields



        private readonly PayFastSettings payFastSettings;



        #endregion Fields



        #region Constructor



        public PaymentGateController()

        {

            this.payFastSettings = new PayFastSettings();

            this.payFastSettings.MerchantId = ConfigurationManager.AppSettings["14467005"];

            this.payFastSettings.MerchantKey = ConfigurationManager.AppSettings["5rghx29uaoiui"];

            this.payFastSettings.PassPhrase = ConfigurationManager.AppSettings["Auctionsliveonline78"];

            this.payFastSettings.ProcessUrl = ConfigurationManager.AppSettings["https://payfast.co.za/eng/process"];

            this.payFastSettings.ValidateUrl = ConfigurationManager.AppSettings["https://payfast.co.za/eng/query/validate"];

            this.payFastSettings.ReturnUrl = ConfigurationManager.AppSettings["https://localhost:44316/PaymentGate/Index"];

            this.payFastSettings.CancelUrl = ConfigurationManager.AppSettings["https://localhost:44316/PaymentGate/Canceled"];

            this.payFastSettings.NotifyUrl = ConfigurationManager.AppSettings["https://localhost:44316/PaymentGate/Notify"];

        }



        #endregion Constructor



        #region Methods



        public ActionResult Index()
        {

            return View();

        }


        public ActionResult Return()

        {

            return View();

        }



        public ActionResult Cancel()

        {

            return View();

        }
        public ActionResult _DeposiAndAdminFees()
        {
            return PartialView();
        }


        public ActionResult _PayDeposiAndAdminFees(AuctionRegistration reg)
        {
            if(ModelState.IsValid)
            _PayAdminFees(reg);
            _PayDeposit();
           // return RedirectToAction("Detailss", "home",new { id = prop.PropertyID});
            return PartialView();



             /* var onceOffRequest = new PayFastRequest(this.payFastSettings.PassPhrase);



              // Merchant Details

              onceOffRequest.merchant_id = this.payFastSettings.MerchantId;

              onceOffRequest.merchant_key = this.payFastSettings.MerchantKey;

              onceOffRequest.return_url = this.payFastSettings.ReturnUrl;

              onceOffRequest.cancel_url = this.payFastSettings.CancelUrl;

              onceOffRequest.notify_url = this.payFastSettings.NotifyUrl;




              // Buyer Details

              onceOffRequest.email_address = "cmmadeleyn@gmail.com";



              // Transaction Details

              onceOffRequest.m_payment_id = "8d00bf49";

              onceOffRequest.amount = 5150;

              onceOffRequest.item_name = "Deposit And Admin fees";

              onceOffRequest.item_description = "This payment is to bid on the Auction you have sellected.";



              // Transaction Options

              onceOffRequest.email_confirmation = true;

              onceOffRequest.confirmation_address = "Janus@auction-prop.com";



              var redirectUrl = $"{this.payFastSettings.ProcessUrl}{onceOffRequest.ToString()}";



              return Redirect(redirectUrl);

              //return PartialView(redirectUrl);*/

        }
        public ActionResult PayAdmin(AuctionRegistration reg)
        {
            _PayAdminFees(reg);
            return PartialView();
        }



        public void _PayAdminFees(AuctionRegistration reg)
        {
            AdminFee fees = new AdminFee
            {
                PaymentID = reg.id,
              ProofOfPaymentPath = "none",
               DateOfPayment = DateTime.Now,
              
               
            };
            APILibrary.APIMethods.APIPost<Deposit>(fees, "AdminFees");



        }
        
        public ActionResult PayDeposit()
        {
            _PayDeposit();
            return View();
        }
        public void _PayDeposit()
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