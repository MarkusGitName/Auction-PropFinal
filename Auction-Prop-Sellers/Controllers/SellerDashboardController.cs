using APILibrary;
using Auction_Prop_Sellers.Models.DataViewModels;
using Auction_Prop_Sellers.Models.ErrorModels;
using AutoMapper;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;

namespace Auction_Prop_Sellers.Controllers
{
    public class SellerDashboardController : Controller
    {
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
                    Seller sellerModel = APIMethods.APIGet<Seller>(User.Identity.GetUserId(), "Sellers");

                    return View(sellerModel);


                }
                catch (Exception E)
                {
                    return View();
                }

            }



        }
        public ActionResult ErrorView(ErrorView error)
        {
            return View();
        }


        public ActionResult CreateProperty(PropertyView model)
        {
            
            if (ModelState.IsValid)
            {
               
                var config = new MapperConfiguration(cfg => {
                    cfg.CreateMap<PropertyView, Property>();
                });

                IMapper mapper = config.CreateMapper();
                Property NewProp = mapper.Map<PropertyView, Property>(model);
                NewProp.SellerID = User.Identity.GetUserId();
                NewProp.TaxesAndRates = FileController.PostFile(model.TaxesAndRates, Server.MapPath("~/App_Data/uploads/TaxesAndRates"), "taxesandrates");
                NewProp.PlansPath = FileController.PostFile(model.PlansPath, Server.MapPath("~/App_Data/uploads/Plans"), "plans");
                NewProp.TitleDeedPath = FileController.PostFile(model.TitleDeedPath, Server.MapPath("~/App_Data/uploads/TitleDeeds"), "titledeeds");


                try
                {
                    //Call Post Method
                    Property ob = APIMethods.APIPost<Property>(NewProp, "Properties");

                    return RedirectToAction("Index");
                }
                catch (Exception E)
                {
                    ErrorViewModel error = new ErrorViewModel()
                    {
                        Msge = E.ToString(),
                    };
                    return RedirectToAction("ErrorView", "SellerDashboard", error);
                }
            }
            else
            {
                return View(model);
            }


        }

        public ActionResult AddPropertyStyled(Property model)
        {
            model.SellerID = User.Identity.GetUserId();

            bool m = ModelState.IsValid;
            string adddd = model.Address;
            if (ModelState.IsValid)
            {
                    Property ob = APIMethods.APIPost<Property>(model, "Properties");

                try
                {
                    //Call Post Method
                    return RedirectToAction("Index");
                }
                catch (Exception E)
                {
                    ErrorViewModel error = new ErrorViewModel()
                    {
                        Msge = E.ToString(),
                    };
                    return RedirectToAction("ErrorView", "SellerDashboard", error);
                }
            }
            else
            {
                return View();
            }


        }


        public ActionResult AddPhoto(int id, PropertyPhotoView file)
        {

            if (ModelState.IsValid)
            {

                
                    PropertyPhoto model = new PropertyPhoto();
                    if (file != null)
                    {
                        model.PropertyId = id;
                        model.Description = file.Description;
                        model.Title = file.Title;
                        model.PropertyId = id;
                        model.PropertyPhotoPath = FileController.PostFile(file.PropertyPhotoPath, Server.MapPath("~/App_Data/uploads/PropertyPhotos"), "propertyphotos");

                        //Call Post Method
                       APIMethods.APIPost<PropertyPhoto>(model, "PropertyPhotoes");
                    }



                    return RedirectToAction("Index");
                
            
            }
            else
            {
                return View();
            }


        }

        // GET: SellersAccount/Edit/5

        public ActionResult Edit(int id, Property model)
        {
            if (ModelState.IsValid)
            {
                 try
                {
               APIMethods.APIPut<Property>(model, id.ToString(), "Properties");
                return RedirectToAction("Index");
                }
                catch (Exception E)
                {
                    ErrorViewModel error = new ErrorViewModel()
                    {
                        Msge = E.ToString(),
                    };
                    return RedirectToAction("ErrorView", "SellerDashboard", error);
                }

            }
            else
            {
                return View(APIMethods.APIGet<Property>(id.ToString(), "Properties"));
            }

        }

        // GET: SellersAccount/Edit/5
        public ActionResult Delete(int id, Property model)
        {
            if (model.PropertyID != 0)
            {
                try
                {
                    APIMethods.APIDelete<Property>( model.PropertyID.ToString(), "Properties");
                    return RedirectToAction("Index");
                }
                catch (Exception E)
                {
                    ErrorViewModel error = new ErrorViewModel()
                    {
                        Msge = E.ToString(),
                    };
                    return RedirectToAction("ErrorView", "SellerDashboard", error);
                }

            }
            else
            {
                return View(APIMethods.APIGet<Property>(id.ToString(), "Properties"));
            }

        }


      

        public ActionResult Details(int id, Property model)
        {
            if (ModelState.IsValid)
            {

                return View();


            }
            else
            {
                return View(APIMethods.APIGet<Property>(id.ToString(), "Properties"));
            }
        }



        public ActionResult _PhotoPartial(PropertyPhoto propertyPhoto)
        {
           
            if ( ModelState.IsValid)
            {
               // NewPropView.PropertyPhotos.Add(propertyPhoto);
                
                return PartialView();
            }
            else
            {
                return PartialView();
            }


        }

    }

}
