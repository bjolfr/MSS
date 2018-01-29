using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using MSS.DMSS.WebService.Models;
using Spire.Doc;

namespace MSS.DMSS.WebService.Services
{
    public class WordDocConverterService : IConverterService
    {
        public string Convert(object source)
        {
            if (!(source is FileDescriptor)) return "";
            var param = source as FileDescriptor;

            var wordDocument = new Document();
            wordDocument.LoadFromFile(param.SourcePath, FileFormat.Docx);

            //var destinationPath = Path.GetTempFileName();
            //var destinationPath = Path.GetTempFileName();
            var di = Directory.CreateDirectory(Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString()));
            var fileName = param.FileName.Substring(param.FileName.LastIndexOf('\\')+1, param.FileName.Length - param.FileName.LastIndexOf('\\')-1);
            var shortFileName = fileName.Substring(0, fileName.LastIndexOf('.'));
            var destinationPath = Path.Combine(di.FullName, shortFileName+".html");
            wordDocument.SaveToFile(destinationPath, FileFormat.Html);

            return destinationPath;
        }
    }
}