using Microsoft.AspNetCore.Http;
using System;

namespace UploadFile.API
{
    public class CallDetails
    {
        public string key { get; set; }
        public string CallerId { get; set; }
        public string CalleeId { get; set; }

        


        public string Recording { get; set; }
        public decimal CallDuration { get; set; }
        public DateTime CurrentDateTime { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public Guid? RecordID { get; set; }
        public string MobileNumbers { get; set; }
        public string CallType { get; set; }
        public string CallerNumber { get; set; }

        public string DeviceId { get; set; }
        public IFormFile recordingMp3 { get; set; }
        public string FileName { get; set; }
    }

    public class RequestCallDetails
    {
        public string key { get; set; }
        public string CallerId { get; set; }
        public string DeviceId { get; set; }
    }

    public class OutResponse
    {
        public Boolean Success { get; set; }
        public string Message { get; set; }
        public string url { get; set; }
    }
}
