using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSS.DMSS.Console.Services
{
    public class CompressionService
    {
        public string TempDir => Path.Combine(Environment.ExpandEnvironmentVariables("%userprofile%"), "Documents");

        public FileInfo Compress(FileInfo fileToCompress)
        {
            using (FileStream originalFileStream = fileToCompress.OpenRead())
            {
                if ((File.GetAttributes(fileToCompress.FullName) &
                   FileAttributes.Hidden) != FileAttributes.Hidden & fileToCompress.Extension != ".gz") {
                    using (FileStream compressedFileStream = File.Create(fileToCompress.FullName + ".gz"))
                        using (GZipStream compressionStream = new GZipStream(compressedFileStream,
                           CompressionMode.Compress)) 
                            originalFileStream.CopyTo(compressionStream);
                    FileInfo info = new FileInfo(TempDir + "\\" + fileToCompress.Name + ".gz");
                    return info;
                }
            }
            throw new Exception();
        }
    }
}
