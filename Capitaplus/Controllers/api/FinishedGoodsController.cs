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
    public class FinishedGoodsController : ApiController
    {
        private CapitaplusEntities db = new CapitaplusEntities();

        // GET: api/FinishedGoods
        public IQueryable<FinishedGood> GetFinishedGoods()
        {
            return db.FinishedGoods;
        }

        // GET: api/FinishedGoods/5
        [ResponseType(typeof(FinishedGood))]
        public async Task<IHttpActionResult> GetFinishedGood(int id)
        {
            FinishedGood finishedGood = await db.FinishedGoods.FindAsync(id);
            if (finishedGood == null)
            {
                return NotFound();
            }

            return Ok(finishedGood);
        }

      

        // PUT: api/FinishedGoods/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutFinishedGood(int id, FinishedGood finishedGood)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != finishedGood.Id)
            {
                return BadRequest();
            }

            db.Entry(finishedGood).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FinishedGoodExists(id))
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

        // POST: api/FinishedGoods
        [ResponseType(typeof(FinishedGood))]
        public async Task<IHttpActionResult> PostFinishedGood(FinishedGood finishedGood)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.FinishedGoods.Add(finishedGood);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = finishedGood.Id }, finishedGood);
        }

        // DELETE: api/FinishedGoods/5
        [ResponseType(typeof(FinishedGood))]
        public async Task<IHttpActionResult> DeleteFinishedGood(int id)
        {
            FinishedGood finishedGood = await db.FinishedGoods.FindAsync(id);
            if (finishedGood == null)
            {
                return NotFound();
            }

            db.FinishedGoods.Remove(finishedGood);
            await db.SaveChangesAsync();

            return Ok(finishedGood);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FinishedGoodExists(int id)
        {
            return db.FinishedGoods.Count(e => e.Id == id) > 0;
        }
    }
}