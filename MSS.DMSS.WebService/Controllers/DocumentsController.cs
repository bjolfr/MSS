using MSS.DMSS.Console.Model;
using MSS.DMSS.WebService.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
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
        public string Get(string id)
        {
            var cv = File.ReadAllText(id);
            return cv;
        }

        [HttpPost]
        public HttpResponseMessage UploadAsync()
        {
            if (!Request.Content.IsMimeMultipartContent())
                Request.CreateResponse(HttpStatusCode.UnsupportedMediaType);

            var path = Path.GetTempFileName();
            FileDescriptor fname = new FileDescriptor();
            foreach (string name in HttpContext.Current.Request.Files)
            {
                var file = HttpContext.Current.Request.Files[name];
                file.SaveAs(path);
                fname.FileName = file.FileName;
                fname.ContentType = file.ContentType;
                fname.SourcePath = path;
            }

            _scenario.Run(fname, out var converted);
            var cv = File.ReadAllText(converted.ToString());
            fname.DestinationPath = converted.ToString();

            return Request.CreateResponse(HttpStatusCode.OK, fname);
        }
    }
}