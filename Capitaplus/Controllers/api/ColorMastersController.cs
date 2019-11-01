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
    public class ColorMastersController : ApiController
    {
        private CapitaplusEntities db = new CapitaplusEntities();

        // GET: api/ColorMasters
        public IQueryable<ColorMaster> GetColorMasters(string query = null)
        {
            var code= db.ColorMasters.Where(x => x.Color.Contains(query));
        
            return code;
        }

        // GET: api/ColorMasters/5
        [ResponseType(typeof(ColorMaster))]
        public async Task<IHttpActionResult> GetColorMaster(int id)
        {
            ColorMaster colorMaster = await db.ColorMasters.FindAsync(id);
            if (colorMaster == null)
            {
                return NotFound();
            }

            return Ok(colorMaster);
        }

        // PUT: api/ColorMasters/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutColorMaster(int id, ColorMaster colorMaster)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != colorMaster.Id)
            {
                return BadRequest();
            }

            db.Entry(colorMaster).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ColorMasterExists(id))
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

        // POST: api/ColorMasters
        [ResponseType(typeof(ColorMaster))]
        public async Task<IHttpActionResult> PostColorMaster(ColorMaster colorMaster)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ColorMasters.Add(colorMaster);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = colorMaster.Id }, colorMaster);
        }

        // DELETE: api/ColorMasters/5
        [ResponseType(typeof(ColorMaster))]
        public async Task<IHttpActionResult> DeleteColorMaster(int id)
        {
            ColorMaster colorMaster = await db.ColorMasters.FindAsync(id);
            if (colorMaster == null)
            {
                return NotFound();
            }

            db.ColorMasters.Remove(colorMaster);
            await db.SaveChangesAsync();

            return Ok(colorMaster);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ColorMasterExists(int id)
        {
            return db.ColorMasters.Count(e => e.Id == id) > 0;
        }
    }
}