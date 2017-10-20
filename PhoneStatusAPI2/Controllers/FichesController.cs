using BDD;
using Newtonsoft.Json;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using System.Data.Entity;

namespace PhoneStatusAPI2.Controllers
{
    public class FichesController : ApiController
    {
        // GET: api/Fiches
        public IHttpActionResult Get()
        {
            return Ok(LoadListFiche().Select(fiche => fiche.ToJson()));
        }

        private IList<Fiche> LoadListFiche()
        {
            List<Fiche> listFiche = new List<Fiche>();
            
            using (DatabaseEntities database = new DatabaseEntities())
            {
                listFiche.AddRange(
                    database.Fiches
                    .Include(fiche => fiche.Client)
                    .ToList()
                );
            }
            return listFiche;
        }

        // GET: api/Fiches/5
        public IHttpActionResult Get(int id)
        {
            Fiche fiche;
            using (DatabaseEntities db = new DatabaseEntities())
            {
                fiche = db.Fiches.Find(id);
                if (id == 0)
                {
                    return BadRequest();
                }

                if (fiche == null)
                {
                    return NotFound();
                }
                
                return Ok(fiche.ToJson());
            }
                
             
        }

        // POST: api/Fiches
        public IHttpActionResult Post([FromBody] Fiche value)
        {     
                Fiche newFiche = new Fiche();
                    using (DatabaseEntities database = new DatabaseEntities())
                    {
                        newFiche = database.Fiches.Add(value);
                        database.SaveChanges();
                    }
                return Ok(newFiche.ToJson());
        }

        // PUT: api/Fiches/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Fiches/5
        public void Delete(int id)
        {
        }
        
    }
}
