using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Auction_Prop_API.Models.DataBaseModels;

namespace Auction_Prop_API.Controllers.APIControllers
{
    public class PropertiesController : ApiController
    {
        private DataBaseModels db = new DataBaseModels();

        // GET: api/Properties
        public IQueryable<Property> GetProperties()
        {
            var properties = db.Properties.Include(p => p.Auction.EndTime).Include(p => p.ConcludedAuction.WinningBidder).Include(p => p.ConcludedAuction.HiegestBid).Include(p => p.Seller.PrivateSeller).Include(p => p.Seller.ProfilePhoto).Include(p => p.Seller.Retailer).Include(p => p.Seller.Auctioneer).Include(p => p.Seller.FirtstName).Include(p => p.Seller.LastName).Include(p => p.Seller.SellerType).Include(p => p.Seller.SellerNumber).Include(p => p.Seller.SellerEmail);

            return properties;
        }

        // GET: api/Properties/5
        [ResponseType(typeof(Property))]
        public async Task<IHttpActionResult> GetProperty(int id)
        {
            Property property = await db.Properties.FindAsync(id);
            if (property == null)
            {
                return NotFound();
            }

            return Ok(property);
        }

        // PUT: api/Properties/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutProperty(int id, Property property)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != property.PropertyID)
            {
                return BadRequest();
            }

            db.Entry(property).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PropertyExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Properties
        [ResponseType(typeof(Property))]
        public async Task<IHttpActionResult> PostProperty(Property property)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Properties.Add(property);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = property.PropertyID }, property);
        }

        // DELETE: api/Properties/5
        [ResponseType(typeof(Property))]
        public async Task<IHttpActionResult> DeleteProperty(int id)
        {
            Property property = await db.Properties.FindAsync(id);
            if (property == null)
            {
                return NotFound();
            }

            db.Properties.Remove(property);
            await db.SaveChangesAsync();

            return Ok(property);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PropertyExists(int id)
        {
            return db.Properties.Count(e => e.PropertyID == id) > 0;
        }
    }
}