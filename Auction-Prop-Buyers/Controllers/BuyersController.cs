using APILibrary;
using Auction_Prop_Buyers.Models.DisplayMadels;
using AutoMapper;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Auction_Prop_Buyers.Controllers
{
    public class BuyersController : Controller
    {
        // GET: Buyers
        public ActionResult Index(RegisteredBuyer model)
        {
            if (ModelState.IsValid)
            {
                return View();
            }
            else
            {


                
                try
                {
                    RegisteredBuyer buyer = APIMethods.APIGet<RegisteredBuyer>(User.Identity.GetUserId(), "RegisteredBuyers");

                    return View(buyer);
                }
                catch
                {
                   
                   
                    return View();
                }

            }

        }
        // GET: Buyers
        public ActionResult _Index()
        {
       
                return PartialView();
            
        }

        // GET: Buyers/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Buyers/Create
        public ActionResult Create(BuyerViewModel model)
        {
            model.UserId = User.Identity.GetUserId();
            if (ModelState.IsValid)
            {
                try
                {
                    var newData = new RegisteredBuyer
                    {
                        UserId = model.UserId,
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        IDNumber = model.IDNumber,
                        DateOfBirth = model.DateOfBirth,
                        BondedOrCash = model.BondedOrCash,
                        Signiture = model.Signiture,
                        RegistrationDate = DateTime.Now
                    };

                    newData.ProfilePhotoPath = FileController.PostFile(model.ProfilePhotoPath, Server.MapPath("~/uploads/ProfilePhotos"), "uploads/ProfilePhotos");
                    newData.ProofOfResidencePath = FileController.PostFile(model.ProofOfResidencePath, Server.MapPath("~/uploads/ProofOfResedence"), "uploads/ProofOfResedence");
                    newData.CopyOfIDPath = FileController.PostFile(model.CopyOfIDPath, Server.MapPath("~/uploads/CopyOfIDPath"), "uploads/ProofOfResedence");



                    //Call Post Method
                    RegisteredBuyer ob = APIMethods.APIPost<RegisteredBuyer>(newData, "RegisteredBuyers");
                    return RedirectToAction("Index");
                }
                catch
                {
                    return RedirectToAction("ErrorView");
                }

            }
            else
            {
                return View();
            }
        }

        // GET: Buyers/Create
        public ActionResult CreateAddress(Address model)
        {
            if (ModelState.IsValid)
            {

                try
                {  //Call Post Method
                    Address objec = APIMethods.APIPost<Address>(model, "Addresses");

                    BuyerAddress bAdd = new BuyerAddress();
                    bAdd.AddressID = objec.AddressID;
                    bAdd.UserID = User.Identity.GetUserId();
                    APIMethods.APIPost<BuyerAddress>(bAdd, "BuyerAddresses");
                    return RedirectToAction("Index");

                }
                catch
                {

                    return RedirectToAction("ErrorView");

                }

            }
            else
            {
                return View();
            }

        }
        // GET: Buyers/Create
        public ActionResult RegisterForAuction(int id,AuctionRegistrationViewModel model)
        {
            if (ModelState.IsValid && model.Signiture)
            {

                model.PropertyID = id;
                model.BuyerId = User.Identity.GetUserId();
                model.RegesterDate = DateTime.Now;

                AuctionRegistration objec = APIMethods.APIPost<AuctionRegistration>(model, "AuctionRegistrations");

                try
                {  //Call Post Method
                   
                    return RedirectToAction("Index");

                }
                catch
                {

                    return RedirectToAction("ErrorView");

                }

            }
            else
            {
                return View();
            }

        }

        public ActionResult AddBankGuarintee(GuarinteeViewModel model)
        {
            
            if (ModelState.IsValid)
            {

                try
                {
                    Guarintee newModel = new Guarintee
                    {
                        BuyerID = User.Identity.GetUserId(),
                        DateOfSubmition = DateTime.Now
                    };
                    newModel.GuarinteePath = FileController.PostFile(model.GuarinteePath, Server.MapPath("~/uploads/Guarintees"), "uploads/Guarintees");

                        //Call Post Method
                        APIMethods.APIPost<Guarintee>(newModel, "Guarintees");
                    



                    return RedirectToAction("Index");
                }
                catch (Exception e)
                {

                    ViewBag.Message = "Error while file uploading." + e + " e";
                    return RedirectToAction("ErrorView");
                }
            }
            else
            {
                return View();
            }
        }


        // GET: Buyers/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Buyers/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Buyers/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Buyers/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
