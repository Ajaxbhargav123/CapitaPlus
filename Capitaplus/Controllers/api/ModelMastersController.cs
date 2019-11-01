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
    public class ModelMastersController : ApiController
    {
        private CapitaplusEntities db = new CapitaplusEntities();

        // GET: api/ModelMasters
        public IQueryable<ModelMaster> GetModelMasters(string query = null)
        {
            return db.ModelMasters.Where(c => c.Model.Contains(query));
        }

        // GET: api/ModelMasters/5
        [ResponseType(typeof(ModelMaster))]
        public async Task<IHttpActionResult> GetModelMaster(int id)
        {
            ModelMaster modelMaster = await db.ModelMasters.FindAsync(id);
            if (modelMaster == null)
            {
                return NotFound();
            }

            return Ok(modelMaster);
        }

        // PUT: api/ModelMasters/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutModelMaster(int id, ModelMaster modelMaster)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != modelMaster.Id)
            {
                return BadRequest();
            }

            db.Entry(modelMaster).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ModelMasterExists(id))
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

        // POST: api/ModelMasters
        [ResponseType(typeof(ModelMaster))]
        public async Task<IHttpActionResult> PostModelMaster(ModelMaster modelMaster)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ModelMasters.Add(modelMaster);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = modelMaster.Id }, modelMaster);
        }

        // DELETE: api/ModelMasters/5
        [ResponseType(typeof(ModelMaster))]
        public async Task<IHttpActionResult> DeleteModelMaster(int id)
        {
            ModelMaster modelMaster = await db.ModelMasters.FindAsync(id);
            if (modelMaster == null)
            {
                return NotFound();
            }

            db.ModelMasters.Remove(modelMaster);
            await db.SaveChangesAsync();

            return Ok(modelMaster);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ModelMasterExists(int id)
        {
            return db.ModelMasters.Count(e => e.Id == id) > 0;
        }
    }
}