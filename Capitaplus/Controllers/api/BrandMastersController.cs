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
    public class BrandMastersController : ApiController
    {
        private CapitaplusEntities db = new CapitaplusEntities();

        // GET: api/BrandMasters
        public IQueryable<BrandMaster> GetBrandMasters(string query = null)
        {
            return db.BrandMasters.Where(c=>c.BrandName.Contains(query));
        }

        // GET: api/BrandMasters/5
        [ResponseType(typeof(BrandMaster))]
        public async Task<IHttpActionResult> GetBrandMaster(int id)
        {
            BrandMaster brandMaster = await db.BrandMasters.FindAsync(id);
            if (brandMaster == null)
            {
                return NotFound();
            }

            return Ok(brandMaster);
        }

        // PUT: api/BrandMasters/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutBrandMaster(int id, BrandMaster brandMaster)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != brandMaster.Id)
            {
                return BadRequest();
            }

            db.Entry(brandMaster).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BrandMasterExists(id))
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

        // POST: api/BrandMasters
        [ResponseType(typeof(BrandMaster))]
        public async Task<IHttpActionResult> PostBrandMaster(BrandMaster brandMaster)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.BrandMasters.Add(brandMaster);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = brandMaster.Id }, brandMaster);
        }

        // DELETE: api/BrandMasters/5
        [ResponseType(typeof(BrandMaster))]
        public async Task<IHttpActionResult> DeleteBrandMaster(int id)
        {
            BrandMaster brandMaster = await db.BrandMasters.FindAsync(id);
            if (brandMaster == null)
            {
                return NotFound();
            }

            db.BrandMasters.Remove(brandMaster);
            await db.SaveChangesAsync();

            return Ok(brandMaster);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BrandMasterExists(int id)
        {
            return db.BrandMasters.Count(e => e.Id == id) > 0;
        }
    }
}