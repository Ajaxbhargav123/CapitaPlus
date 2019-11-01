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
    public class FGstocksController : ApiController
    {
        private CapitaplusEntities db = new CapitaplusEntities();

        // GET: api/FGstocks
        public IQueryable<FGstock> GetFGstocks()
        {
            return db.FGstocks;
        }
        
        // GET: api/FGstocks/5
        [ResponseType(typeof(FGstock))]
        public async Task<IHttpActionResult> GetFGstock(string id,int Cid)
        {
            FGstock fGstock = await db.FGstocks.FirstAsync(x => x.Code == id && x.Cid == Cid);
            if (fGstock == null)
            {
                return NotFound();
            }

            return Ok(fGstock);
        }

        // PUT: api/FGstocks/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutFGstock(int id, FGstock fGstock)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != fGstock.Id)
            {
                return BadRequest();
            }

            db.Entry(fGstock).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FGstockExists(id))
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

        // POST: api/FGstocks
        [ResponseType(typeof(FGstock))]
        public async Task<IHttpActionResult> PostFGstock(FGstock fGstock)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.FGstocks.Add(fGstock);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = fGstock.Id }, fGstock);
        }

        // DELETE: api/FGstocks/5
        [ResponseType(typeof(FGstock))]
        public async Task<IHttpActionResult> DeleteFGstock(int id)
        {
            FGstock fGstock = await db.FGstocks.FindAsync(id);
            if (fGstock == null)
            {
                return NotFound();
            }

            db.FGstocks.Remove(fGstock);
            await db.SaveChangesAsync();

            return Ok(fGstock);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FGstockExists(int id)
        {
            return db.FGstocks.Count(e => e.Id == id) > 0;
        }
    }
}