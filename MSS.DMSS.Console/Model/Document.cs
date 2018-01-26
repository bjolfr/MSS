using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSS.DMSS.Console.Model
{
    public class Document
    {
        public string Type { get; set; }
        public int? Width { get; set; }
        public int? Length { get; set; }
        public int? DPI { get; set; }
        public object Font { get; set; }
        public object Attachment { get; set; }
    }
}
