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
    public class RoleMaterialCreationsController : ApiController
    {
        private CapitaplusEntities db = new CapitaplusEntities();

        // GET: api/RoleMaterialCreations
        public IQueryable<RoleMaterialCreation> GetRoleMaterialCreations()
        {
            return db.RoleMaterialCreations;
        }

        // GET: api/RoleMaterialCreations/5
        [ResponseType(typeof(RoleMaterialCreation))]
        public async Task<IHttpActionResult> GetRoleMaterialCreation(int id)
        {
            RoleMaterialCreation roleMaterialCreation = await db.RoleMaterialCreations.FindAsync(id);
            if (roleMaterialCreation == null)
            {
                return NotFound();
            }

            return Ok(roleMaterialCreation);
        }

        // PUT: api/RoleMaterialCreations/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutRoleMaterialCreation(int id, RoleMaterialCreation roleMaterialCreation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != roleMaterialCreation.Id)
            {
                return BadRequest();
            }

            db.Entry(roleMaterialCreation).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoleMaterialCreationExists(id))
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

        // POST: api/RoleMaterialCreations
        [ResponseType(typeof(RoleMaterialCreation))]
        public async Task<IHttpActionResult> PostRoleMaterialCreation(RoleMaterialCreation roleMaterialCreation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.RoleMaterialCreations.Add(roleMaterialCreation);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = roleMaterialCreation.Id }, roleMaterialCreation);
        }

        // DELETE: api/RoleMaterialCreations/5
        [ResponseType(typeof(RoleMaterialCreation))]
        public async Task<IHttpActionResult> DeleteRoleMaterialCreation(int id)
        {
            RoleMaterialCreation roleMaterialCreation = await db.RoleMaterialCreations.FindAsync(id);
            if (roleMaterialCreation == null)
            {
                return NotFound();
            }

            db.RoleMaterialCreations.Remove(roleMaterialCreation);
            await db.SaveChangesAsync();

            return Ok(roleMaterialCreation);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RoleMaterialCreationExists(int id)
        {
            return db.RoleMaterialCreations.Count(e => e.Id == id) > 0;
        }
    }
}