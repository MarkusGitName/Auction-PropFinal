using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Auction_Prop_API.Models.DataBaseModels;

namespace Auction_Prop_API.Controllers.MVC
{
    public class GuarinteesController : Controller
    {
        private DataBaseModels db = new DataBaseModels();

        // GET: Guarintees
        public async Task<ActionResult> Index()
        {
            var guarintees = db.Guarintees.Include(g => g.RegisteredBuyer);
            return View(await guarintees.ToListAsync());
        }

        // GET: Guarintees/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Guarintee guarintee = await db.Guarintees.FindAsync(id);
            if (guarintee == null)
            {
                return HttpNotFound();
            }
            return View(guarintee);
        }

        // GET: Guarintees/Create
        public ActionResult Create()
        {
            ViewBag.BuyerID = new SelectList(db.RegisteredBuyers, "UserId", "FirstName");
            return View();
        }

        // POST: Guarintees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "GuarinteeID,BuyerID,GuarinteePath,GuarinteeApproval,DateOfSubmition")] Guarintee guarintee)
        {
            if (ModelState.IsValid)
            {
                db.Guarintees.Add(guarintee);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.BuyerID = new SelectList(db.RegisteredBuyers, "UserId", "FirstName", guarintee.BuyerID);
            return View(guarintee);
        }

        // GET: Guarintees/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Guarintee guarintee = await db.Guarintees.FindAsync(id);
            if (guarintee == null)
            {
                return HttpNotFound();
            }
            ViewBag.BuyerID = new SelectList(db.RegisteredBuyers, "UserId", "FirstName", guarintee.BuyerID);
            return View(guarintee);
        }

        // POST: Guarintees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "GuarinteeID,BuyerID,GuarinteePath,GuarinteeApproval,DateOfSubmition")] Guarintee guarintee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(guarintee).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.BuyerID = new SelectList(db.RegisteredBuyers, "UserId", "FirstName", guarintee.BuyerID);
            return View(guarintee);
        }

        // GET: Guarintees/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Guarintee guarintee = await db.Guarintees.FindAsync(id);
            if (guarintee == null)
            {
                return HttpNotFound();
            }
            return View(guarintee);
        }

        // POST: Guarintees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Guarintee guarintee = await db.Guarintees.FindAsync(id);
            db.Guarintees.Remove(guarintee);
            await db.SaveChangesAsync();
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
