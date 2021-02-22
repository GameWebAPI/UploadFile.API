using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UploadFile.API.Helper
{
    public class HttpPostedFile
    {
        public HttpPostedFile(string name, string filename, byte[] file)
        {
            //Property Assignment
        }

        public string Name { get; private set; }
        public string Filename { get; private set; }
        public byte[] File { private set; get; }
    }
}
