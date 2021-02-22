using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

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
        public ActionResult Submit([FromForm]CallDetails callDetails)
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
                outResponse.Success = true;
                outResponse.Message = "File Uploaded Successfully";

            }


           

            return Ok(outResponse);
        }
    }
}
