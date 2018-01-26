using MSS.DMSS.Console.Model;
using MSS.DMSS.Console.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSS.DMSS.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var srv = new DocumentService();
            var cmp = new CompressionService();
            var path = Path.Combine(Environment.ExpandEnvironmentVariables("%userprofile%"), "Documents", "Itinerary Template 2016.docx");
            var selectedDirectory = new DirectoryInfo(path);
            var file = cmp.Compress(new FileInfo(path));
            var emb = File.ReadAllBytes(file.FullName);
            var embeddedDoc = new Document {
                Attachment = emb ?? throw new Exception("File is empty"),
                Length = emb?.Length };
            var json = JsonConvert.SerializeObject(embeddedDoc);
            var result = Task.Run(() => srv.UploadDocumentAsync(json)).GetAwaiter().GetResult();
        }
    }
}
