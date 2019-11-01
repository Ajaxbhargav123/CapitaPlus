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
    public class GrnsController : ApiController
    {
        private CapitaplusEntities db = new CapitaplusEntities();

        // GET: api/Grns
        public IQueryable<Grn> GetGrns()
        {
            return db.Grns;
        }

        // GET: api/Grns/5
        [ResponseType(typeof(Grn))]
        public async Task<IHttpActionResult> GetGrn(int id)
        {
            Grn grn = await db.Grns.FindAsync(id);
            if (grn == null)
            {
                return NotFound();
            }

            return Ok(grn);
        }

        // PUT: api/Grns/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutGrn(int id, Grn grn)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != grn.Id)
            {
                return BadRequest();
            }

            db.Entry(grn).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GrnExists(id))
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

        // POST: api/Grns
        [ResponseType(typeof(Grn))]
        public async Task<IHttpActionResult> PostGrn([FromBody]Grn datas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Grns.Add(datas);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = datas.Id }, datas);
        }

        // DELETE: api/Grns/5
        [ResponseType(typeof(Grn))]
        public async Task<IHttpActionResult> DeleteGrn(int id)
        {
            Grn grn = await db.Grns.FindAsync(id);
            if (grn == null)
            {
                return NotFound();
            }

            db.Grns.Remove(grn);
            await db.SaveChangesAsync();

            return Ok(grn);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GrnExists(int id)
        {
            return db.Grns.Count(e => e.Id == id) > 0;
        }
    }
}