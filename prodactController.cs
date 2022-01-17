using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;


namespace AstoolTechRestFullAPI.Controllers
{
    public class prodactController : ApiController
    {
      /*  private orderapiEntities db = new orderapiEntities();

        // GET: api/prodact
        public IQueryable<prodactacoun> Getprodactacouns()
        {
            return db.prodactacouns;
        }

        // GET: api/prodact/5
        [ResponseType(typeof(prodactacoun))]
        public IHttpActionResult Getprodactacoun(int id)
        {
            prodactacoun prodactacoun = db.prodactacouns.Find(id);
            if (prodactacoun == null)
            {
                return NotFound();
            }

            return Ok(prodactacoun);
        }

        // PUT: api/prodact/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putprodactacoun(int id, prodactacoun prodactacoun)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != prodactacoun.ID)
            {
                return BadRequest();
            }

            db.Entry(prodactacoun).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!prodactacounExists(id))
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

        // POST: api/prodact
        [ResponseType(typeof(prodactacoun))]
        public IHttpActionResult Postprodactacoun(prodactacoun prodactacoun)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.prodactacouns.Add(prodactacoun);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = prodactacoun.ID }, prodactacoun);
        }

        // DELETE: api/prodact/5
        [ResponseType(typeof(prodactacoun))]
        public IHttpActionResult Deleteprodactacoun(int id)
        {
            prodactacoun prodactacoun = db.prodactacouns.Find(id);
            if (prodactacoun == null)
            {
                return NotFound();
            }

            db.prodactacouns.Remove(prodactacoun);
            db.SaveChanges();

            return Ok(prodactacoun);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool prodactacounExists(int id)
        {
            return db.prodactacouns.Count(e => e.ID == id) > 0;
        }
        */
    }
}