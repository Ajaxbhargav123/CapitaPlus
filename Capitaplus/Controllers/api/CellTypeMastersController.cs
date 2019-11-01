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
    public class CellTypeMastersController : ApiController
    {
        private CapitaplusEntities db = new CapitaplusEntities();

        // GET: api/CellTypeMasters
        public IQueryable<CellTypeMaster> GetCellTypeMasters(string query = null)
        {
            return db.CellTypeMasters.Where(c => c.CellType.Contains(query));
        }

        // GET: api/CellTypeMasters/5
        [ResponseType(typeof(CellTypeMaster))]
        public async Task<IHttpActionResult> GetCellTypeMaster(int id)
        {
            CellTypeMaster cellTypeMaster = await db.CellTypeMasters.FindAsync(id);
            if (cellTypeMaster == null)
            {
                return NotFound();
            }

            return Ok(cellTypeMaster);
        }

        // PUT: api/CellTypeMasters/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCellTypeMaster(int id, CellTypeMaster cellTypeMaster)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cellTypeMaster.Id)
            {
                return BadRequest();
            }

            db.Entry(cellTypeMaster).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CellTypeMasterExists(id))
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

        // POST: api/CellTypeMasters
        [ResponseType(typeof(CellTypeMaster))]
        public async Task<IHttpActionResult> PostCellTypeMaster(CellTypeMaster cellTypeMaster)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CellTypeMasters.Add(cellTypeMaster);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = cellTypeMaster.Id }, cellTypeMaster);
        }

        // DELETE: api/CellTypeMasters/5
        [ResponseType(typeof(CellTypeMaster))]
        public async Task<IHttpActionResult> DeleteCellTypeMaster(int id)
        {
            CellTypeMaster cellTypeMaster = await db.CellTypeMasters.FindAsync(id);
            if (cellTypeMaster == null)
            {
                return NotFound();
            }

            db.CellTypeMasters.Remove(cellTypeMaster);
            await db.SaveChangesAsync();

            return Ok(cellTypeMaster);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CellTypeMasterExists(int id)
        {
            return db.CellTypeMasters.Count(e => e.Id == id) > 0;
        }
    }
}