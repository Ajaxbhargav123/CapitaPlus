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
    public class SalesOrdersController : ApiController
    {
        private CapitaplusEntities db = new CapitaplusEntities();

        // GET: api/SalesOrders
        public IQueryable<SalesOrder> GetSalesOrders()
        {
            return db.SalesOrders;
        }

        // GET: api/SalesOrders/5
        [ResponseType(typeof(SalesOrder))]
        public async Task<IHttpActionResult> GetSalesOrder(int id)
        {
            SalesOrder salesOrder = await db.SalesOrders.FindAsync(id);
           
            if (salesOrder == null)
            {
                return NotFound();
            }

            return Ok(salesOrder);
        }

        // PUT: api/SalesOrders/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSalesOrder(int id, SalesOrder salesOrder)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != salesOrder.Id)
            {
                return BadRequest();
            }

            db.Entry(salesOrder).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalesOrderExists(id))
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

        // POST: api/SalesOrders
        [ResponseType(typeof(SalesOrder))]
        public async Task<IHttpActionResult> PostSalesOrder(SalesOrder salesOrder)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SalesOrders.Add(salesOrder);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = salesOrder.Id }, salesOrder);
        }

        // DELETE: api/SalesOrders/5
        [ResponseType(typeof(SalesOrder))]
        public async Task<IHttpActionResult> DeleteSalesOrder(int id)
        {
            SalesOrder salesOrder = await db.SalesOrders.FindAsync(id);
            if (salesOrder == null)
            {
                return NotFound();
            }

            db.SalesOrders.Remove(salesOrder);
            await db.SaveChangesAsync();

            return Ok(salesOrder);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SalesOrderExists(int id)
        {
            return db.SalesOrders.Count(e => e.Id == id) > 0;
        }
    }
}