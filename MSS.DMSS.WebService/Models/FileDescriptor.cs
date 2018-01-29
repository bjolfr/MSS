using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MSS.DMSS.WebService.Models
{
    public class FileDescriptor
    {
        public int Id { get; set; }

        public string FileName { get; set; }

        public string Description { get; set; }

        public DateTime CreatedTimestamp { get; set; }

        public DateTime UpdatedTimestamp { get; set; }

        public string ContentType { get; set; }

        public string SourcePath { get; set; }

        public string DestinationPath { get; set; }

    }
}