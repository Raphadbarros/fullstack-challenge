using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using ViajarApi.Models;
using ViajarApi.Services;

namespace ViajarApi.Controllers
{
    
    public class HeroesController : ApiController
    {

        // GET: api/Heroes
        [Route("api/list")]
        public IEnumerable<HeroesModels> Get()

        {
            ListarHeroes api = new ListarHeroes();
            var result = api.getHeroes().ToList();
            
            return result;
        }
        

        // GET: api/Heroes/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Heroes
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Heroes/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Heroes/5
        public void Delete(int id)
        {
        }
    }
}
