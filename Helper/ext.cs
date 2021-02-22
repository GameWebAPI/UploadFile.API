using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace UploadFile.API.Helper
{
    public static class ext
    {
        /*
        public static async Task<HttpPostedData> ParseMultipartAsync(this Microsoft.AspNetCore.Http.HttpContext postedContent)
        {
            var provider = await postedContent..ReadAsMultipartAsync();

            var files = new Dictionary<string, HttpPostedFile>(StringComparer.InvariantCultureIgnoreCase);
            var fields = new Dictionary<string, HttpPostedField>(StringComparer.InvariantCultureIgnoreCase);

            foreach (var content in provider.Contents)
            {
                var fieldName = content.Headers.ContentDisposition.Name.Trim('"');
                if (!string.IsNullOrEmpty(content.Headers.ContentDisposition.FileName))
                {
                    var file = await content.ReadAsByteArrayAsync();
                    var fileName = content.Headers.ContentDisposition.FileName.Trim('"');
                    files.Add(fieldName, new HttpPostedFile(fieldName, fileName, file));
                }
                else
                {
                    var data = await content.ReadAsStringAsync();
                    fields.Add(fieldName, new HttpPostedField(fieldName, data));
                }
            }

            return new HttpPostedData(fields, files);
        }*/
    }
}
