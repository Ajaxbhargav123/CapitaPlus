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
using Capitaplus.Models;

namespace Capitaplus.Controllers.api
{
    public class PurchaseOrderSummariesController : ApiController
    {
        private CapitaplusEntities db = new CapitaplusEntities();

        // GET: api/PurchaseOrderSummaries
        public IQueryable<PurchaseOrderSummary> GetPurchaseOrderSummaries()
        {
            return db.PurchaseOrderSummaries;
        }

        // GET: api/PurchaseOrderSummaries/5
        [ResponseType(typeof(PurchaseOrderSummary))]
        public async Task<IHttpActionResult> GetPurchaseOrderSummary(int id)
        {
            PurchaseOrderSummary purchaseOrderSummary = await db.PurchaseOrderSummaries.FindAsync(id);
            if (purchaseOrderSummary == null)
            {
                return NotFound();
            }

            return Ok(purchaseOrderSummary);
        }

        // PUT: api/PurchaseOrderSummaries/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPurchaseOrderSummary(int id, PurchaseOrderSummary purchaseOrderSummary)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != purchaseOrderSummary.Id)
            {
                return BadRequest();
            }

            db.Entry(purchaseOrderSummary).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PurchaseOrderSummaryExists(id))
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

        // POST: api/PurchaseOrderSummaries
        [ResponseType(typeof(PurchaseOrderSummary))]
        public async Task<IHttpActionResult> PostPurchaseOrderSummary(PurchaseOrderSummary purchaseOrderSummary)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PurchaseOrderSummaries.Add(purchaseOrderSummary);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = purchaseOrderSummary.Id }, purchaseOrderSummary);
        }

        // DELETE: api/PurchaseOrderSummaries/5
        [ResponseType(typeof(PurchaseOrderSummary))]
        public async Task<IHttpActionResult> DeletePurchaseOrderSummary(int id)
        {
            PurchaseOrderSummary purchaseOrderSummary = await db.PurchaseOrderSummaries.FindAsync(id);
            if (purchaseOrderSummary == null)
            {
                return NotFound();
            }

            db.PurchaseOrderSummaries.Remove(purchaseOrderSummary);
            await db.SaveChangesAsync();

            return Ok(purchaseOrderSummary);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PurchaseOrderSummaryExists(int id)
        {
            return db.PurchaseOrderSummaries.Count(e => e.Id == id) > 0;
        }
    }
}