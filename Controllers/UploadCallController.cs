using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using UploadFile.API.Services;

namespace UploadFile.API.Controllers
{
    [ApiController]
    
    public class UploadCallController : ControllerBase
    {
        private readonly ILogger<UploadCallController> _logger;
        private readonly IConfiguration Configuration;

        public UploadCallController(ILogger<UploadCallController> logger, IConfiguration configuration)
        {
            _logger = logger;
            Configuration = configuration;
        }

        [Route("api/retrieve")]
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Retrieve(RequestCallDetails requestCallDetails)
        {
            if (!Configuration["SecrectKey"].Equals(requestCallDetails.key))
                return Unauthorized("Unauthorized");

            CallDetails callDetails = new CallDetails();

            return Ok(callDetails);
        }

        [Route("api/submit")]
        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult> Submit([FromForm]CallDetails callDetails)
        {

            //if (!Configuration["SecrectKey"].Equals(callDetails.key))
            //    return Unauthorized("Unauthorized");
            OutResponse outResponse = new OutResponse();
            // Getting Image
            var recording = callDetails.recordingMp3;
            // Saving Image on Server
            if (recording.Length > 0)
            {
                using (var fileStream = new FileStream("Recordings/" + recording.FileName, FileMode.Create))
                {
                    recording.CopyTo(fileStream);
                }
                outResponse.url = await u(recording);
                callDetails.FileName = outResponse.url;
                DBService svc = new DBService();
                svc.UploadRecordingDBSave(callDetails);
                outResponse.Success = true;
                outResponse.Message = "File Uploaded Successfully";

            }


           

            return Ok(outResponse);
        }
        [Route("api/prvate")]
        public async  Task<string> u(IFormFile file)
        {
            var storageConnectionString = Configuration["ConnectionStrings:AzureStorageConnectionString"];

            if (CloudStorageAccount.TryParse(storageConnectionString, out CloudStorageAccount storageAccount))
            {
                CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

                CloudBlobContainer container = blobClient.GetContainerReference("recordings");

                await container.CreateIfNotExistsAsync();

                //MS: Don't rely on or trust the FileName property without validation. The FileName property should only be used for display purposes.
                var picBlob = container.GetBlockBlobReference(Guid.NewGuid().ToString()+ Path.GetExtension(file.FileName));

                await picBlob.UploadFromStreamAsync(file.OpenReadStream());

                return picBlob.Uri.ToString();
            }
            return "";
        }
    }
}
