using Auction_Prop_Sellers.Models.DataViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using APILibrary;
using Auction_Prop_Sellers.Models.ErrorModels;

namespace Auction_Prop_Sellers.Controllers
{
    public class SellerRegistrationController : Controller
    {
        // GET: SellersAccount/RegistrationWiz
        public ActionResult Index(Sellers model)
        {
            if (ModelState.IsValid)
            {
                return View();
            }
            else
            {
                     
                   
                try
                {
                     Sellers sellerModel = APIMethods.APIGet<Sellers>(User.Identity.GetUserId(), "sellers");
                   
                      return View(sellerModel);
                }
                catch
                {
                    return View();
                }

            }

        }


        // POST: SellersAccount/Create     
        public ActionResult CreateSeller(Sellers model)
        {
            model.UserID = User.Identity.GetUserId();

            if (ModelState.IsValid)
            {
                
                   
                try
                { //Call Post Method
                    Sellers ob = APIMethods.APIPost<Sellers>(model, "Sellers");
                    return Index(ob);
                }
                catch
                {
                    ErrorViewModel e = new ErrorViewModel();
                    e.Msge = "you are already registered";
                    return RedirectToAction("ErrorView");
                }
            }
            else
            {
                return View();
            }
        }




        public ActionResult CreateRetialer(RetailerView model)
        {
            model.UserID = User.Identity.GetUserId();
            if (ModelState.IsValid)
            {
                try
                {
                    var newData = new Retailer
                    {
                        UserID = model.UserID,
                        RetailerName = model.RetailerName,
                        Signature = model.Signature,
                        CompanyContactNumber = model.CompanyContactNumber,
                        CompanyEmail = model.CompanyEmail
                    };

                    newData.ProfilePhotoPath = FileController.PostFile(model.ProfilePhotoPath, Server.MapPath("~/uploads/ProfilePhotos"), "uploads/ProfilePhotos");
                    newData.ProofOfResedence = FileController.PostFile(model.ProofOfResedence, Server.MapPath("~/uploads/ProofOfResedence"), "uploads/ProofOfResedence");



                    //Call Post Method
                    Retailer ob = APIMethods.APIPost<Retailer>(newData, "Retailelers");
                    return RedirectToAction("Index");
                }
                catch
                {
                    ErrorViewModel error = new ErrorViewModel();
                    error.Msge = "Could not add youre information. Please try again.";
                    return RedirectToAction("ErrorView");
                }
            }
            else
            {
                return View();
            }
        }


        public ActionResult CreatePrivate(PrivateSellerData model)
        {
            model.UserID = User.Identity.GetUserId();
            if (ModelState.IsValid)
            {

                try
                {


                    var newData = new PrivateSeller
                    {
                        UserID = model.UserID,
                        IDNumber = model.IDNumber,
                        Signiture = model.Signiture,
                    };

                    newData.ProfilePhotoPath = FileController.PostFile(model.ProfilePhotoPath, Server.MapPath("~/uploads/ProfilePhotos"), "uploads/ProfilePhotos");
                    newData.ProofOfResedence = FileController.PostFile(model.ProofOfResedence, Server.MapPath("~/uploads/ProofOfResedence"), "uploads/ProofOfResedence");

                    //Call Post Method
                    PrivateSeller ob = APIMethods.APIPost<PrivateSeller>(newData, "PrivateSellers");

                    return RedirectToAction("Index");
                }
                catch
                {
                    ErrorViewModel error = new ErrorViewModel();
                    error.Msge = APIMethods.APIPost<string>(model, "PrivateSellers");
                    return RedirectToAction("ErrorView" );
                }
            }
            else
            {
                return View();
            }
        }



        public ActionResult AddAddress(Address model)
        {
            if (ModelState.IsValid)
            {
              
                try
                {  //Call Post Method
                Address objec = APIMethods.APIPost<Address>(model, "Addresses");

                SellerAddress sAdd = new SellerAddress();
                sAdd.AddressID = objec.AddressID;
                sAdd.UserID = User.Identity.GetUserId();
                    APIMethods.APIPost<SellerAddress>(sAdd, "SellerAddresses");
                    return RedirectToAction("Index");

                }
                catch
                {

                    ErrorViewModel error = new ErrorViewModel();
                  //  error.Message = APIMethods.APIPost<string>(sAdd, "SellerAddresses");
                    return ErrorView(error);

                }

            }
            else
            {
                return View();
            }



        }
        public ActionResult ErrorView(ErrorViewModel model)
        {
            return View(model);
        }
    }
}