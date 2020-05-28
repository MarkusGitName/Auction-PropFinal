using Auction_Prop_Sellers.Models.DataViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using APILibrary;
using Auction_Prop_Sellers.Models.ErrorModels;
using System.Web.Hosting;

namespace Auction_Prop_Sellers.Controllers
{
    public class SellerRegistrationController : Controller
    {
        // GET: SellersAccount/RegistrationWiz

        public ActionResult Index(Seller model)
        {
            if (ModelState.IsValid)
            {
                return View();
            }
            else
            {
                     
                   
                try
                {
                     Seller sellerModel = APIMethods.APIGet<Seller>(User.Identity.GetUserId(), "sellers");
                   
                      return View(sellerModel);
                }
                catch (Exception E)
                {
                    return View();
                }

            }

        }


        // POST: SellersAccount/Create     

        public ActionResult CreateSeller(Seller model)
        {
            model.UserID = User.Identity.GetUserId();

            if (ModelState.IsValid)
            {
                
                   
                try
                { //Call Post Method
                    Seller ob = APIMethods.APIPost<Seller>(model, "Sellers");
                    return Index(ob);
                }
                catch (Exception E)
                {
                    ErrorViewModel error = new ErrorViewModel()
                    {
                        Msge = E.ToString(),
                    };
                    return RedirectToAction("ErrorView", "SellerRegistration", error);
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

                    newData.ProfilePhotoPath = FileController.PostFile(model.ProfilePhotoPath, Server.MapPath("~/App_Data/uploads/ProfilePhotos"), "profilephotos");
                    newData.ProofOfResedence = FileController.PostFile(model.ProofOfResedence, Server.MapPath("~/App_Data/uploads/ProofOfResedence"), "proofofresedence");



                    //Call Post Method
                    Retailer ob = APIMethods.APIPost<Retailer>(newData, "Retailelers");
                    return RedirectToAction("Index");
                }
                catch (Exception E)
                {
                    ErrorViewModel error = new ErrorViewModel()
                    {
                        Msge = E.ToString(),
                    };
                    return RedirectToAction("ErrorView", "SellerRegistration", error);
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

                    newData.ProfilePhotoPath = FileController.PostFile(model.ProfilePhotoPath, Server.MapPath("~/App_Data/uploads/ProfilePhotos"), "profilephotos");
                    newData.ProofOfResedence = FileController.PostFile(model.ProofOfResedence, Server.MapPath("~/App_Data/uploads/ProofOfResedence"), "proofofresedence");

                    //Call Post Method
                    PrivateSeller ob = APIMethods.APIPost<PrivateSeller>(newData, "PrivateSellers");

                    return RedirectToAction("Index");
                }
                catch (Exception E)
                {
                    ErrorViewModel error = new ErrorViewModel()
                    {
                        Msge = E.ToString(),
                    };
                    return RedirectToAction("ErrorView", "SellerRegistration", error);
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
                catch (Exception E)
                {
                    ErrorViewModel error = new ErrorViewModel()
                    {
                        Msge = E.ToString(),
                    };
                    return RedirectToAction("ErrorView", "SellerRegistration", error);
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