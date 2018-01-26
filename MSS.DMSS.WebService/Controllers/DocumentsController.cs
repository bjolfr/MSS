using MSS.DMSS.Console.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Unity;

namespace MSS.DMSS.WebService.Controllers
{
    public class DocumentsController : ApiController
    {
        IScenario _scenario;

        public DocumentsController(IScenario scenario)
        {
            _scenario = scenario;
        }

        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public async void Post()
        {
            var res = await Request.Content.ReadAsStringAsync();
        }

        public bool Post([FromBody]string value)
        {
            //var json = JsonConvert.DeserializeObject<Document>(value);
            var type = "Word";
            if (type == "Word")
                _scenario.Run(value);

            return true;
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}