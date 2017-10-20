using BDD;
using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PhoneStatusAPI2.Controllers
{
    public class ClientsController : ApiController
    {
        private Func<IJsonable, dynamic> objToJson = obj => obj.ToJson();

        // GET: api/Clients
        public IHttpActionResult Get()
        {
            using (DatabaseEntities database = new DatabaseEntities())
            {
                return Ok(new List<dynamic>(
                    database.Clients
                   .Select(objToJson)
                   .ToList()
                   ));
                
            }
        }
        

        // GET: api/Clients/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Clients
        public IHttpActionResult Post([FromBody]Client value)
        {
            Client newClient = new Client();
            if (Validator.IsEmail(value.Mail))
            {
                using (DatabaseEntities database = new DatabaseEntities())
                {
                    newClient = database.Clients.Add(value);
                    database.SaveChanges();
                }
            }
            return Ok(newClient);
        }

        // PUT: api/Clients/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Clients/5
        public void Delete(int id)
        {
        }
    }
}
