using MSS.DMSS.Console.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSS.DMSS.Console.Services
{
    public class DocumentService : BaseService
    {
        public async Task<bool> UploadDocumentAsync(object file)
        {
            var json = JsonConvert.SerializeObject(file);
            return await PostAsync<bool>("Documents", json);
        }

        public async Task<bool> UploadDocumentAsync(Document file)
        {
            return await PostAsync<bool>("Documents", new { file.Length, file.Attachment });
        }

    }
}
