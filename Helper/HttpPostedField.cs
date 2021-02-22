using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UploadFile.API.Helper
{
    public class HttpPostedField
    {
        public HttpPostedField(string name, string value)
        {
            //Property Assignment
        }

        public string Name { get; private set; }
        public string Value { get; private set; }
    }
}
