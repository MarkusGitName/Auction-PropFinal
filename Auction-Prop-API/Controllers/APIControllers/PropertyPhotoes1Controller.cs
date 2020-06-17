using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Auction_Prop_API.Models.DataBaseModels;

namespace Auction_Prop_API.Controllers.APIControllers
{
    public class PropertyPhotoes1Controller : Controller
    {
        private DataBaseModels db = new DataBaseModels();

        // GET: PropertyPhotoes1
        public ActionResult Index()
        {
            var propertyPhotos = db.PropertyPhotos.Include(p => p.Property);
            return View(propertyPhotos.ToList());
        }

        // GET: PropertyPhotoes1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PropertyPhoto propertyPhoto = db.PropertyPhotos.Find(id);
            if (propertyPhoto == null)
            {
                return HttpNotFound();
            }
            return View(propertyPhoto);
        }

        // GET: PropertyPhotoes1/Create
        public ActionResult Create()
        {
            ViewBag.PropertyId = new SelectList(db.Properties, "PropertyID", "SellerID");
            return View();
        }

        // POST: PropertyPhotoes1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ImageID,PropertyId,Title,Description,PropertyPhotoPath")] PropertyPhoto propertyPhoto)
        {
            if (ModelState.IsValid)
            {
                db.PropertyPhotos.Add(propertyPhoto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PropertyId = new SelectList(db.Properties, "PropertyID", "SellerID", propertyPhoto.PropertyId);
            return View(propertyPhoto);
        }

        // GET: PropertyPhotoes1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PropertyPhoto propertyPhoto = db.PropertyPhotos.Find(id);
            if (propertyPhoto == null)
            {
                return HttpNotFound();
            }
            ViewBag.PropertyId = new SelectList(db.Properties, "PropertyID", "SellerID", propertyPhoto.PropertyId);
            return View(propertyPhoto);
        }

        // POST: PropertyPhotoes1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ImageID,PropertyId,Title,Description,PropertyPhotoPath")] PropertyPhoto propertyPhoto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(propertyPhoto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PropertyId = new SelectList(db.Properties, "PropertyID", "SellerID", propertyPhoto.PropertyId);
            return View(propertyPhoto);
        }

        // GET: PropertyPhotoes1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PropertyPhoto propertyPhoto = db.PropertyPhotos.Find(id);
            if (propertyPhoto == null)
            {
                return HttpNotFound();
            }
            return View(propertyPhoto);
        }

        // POST: PropertyPhotoes1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PropertyPhoto propertyPhoto = db.PropertyPhotos.Find(id);
            db.PropertyPhotos.Remove(propertyPhoto);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
