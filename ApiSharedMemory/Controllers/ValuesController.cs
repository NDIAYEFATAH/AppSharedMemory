using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using MetierSharedMemory.Model;

namespace ApiSharedMemory.Controllers
{

    [RoutePrefix("api")]
    public class ValuesController : ApiController
    {
        /*private dbKireneEntities7 db = new dbKireneEntities7();*/
        BdSharedMemoryContext dbs = new BdSharedMemoryContext();
        private readonly BdSharedMemoryContext _context;

        // Constructeur par défaut sans paramètres
        public ValuesController()
        {
            _context = new BdSharedMemoryContext();
        }

        // Constructeur avec paramètre (si nécessaire pour des tests ou une injection de dépendances)
        public ValuesController(BdSharedMemoryContext context)
        {
            _context = context ?? new BdSharedMemoryContext();
        }

        
        // GET api/values
        [HttpGet]
        [Route("")]
        public IEnumerable<Jury> Get()
        {
            return dbs.Jurys;
        }

        [HttpGet]
        [Route("GetListJury")]
        public List<Jury> GetListJury()
        {
            return dbs.Jurys.ToList();

        }

        // GET api/values/5
        public string Get(int id) 
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
