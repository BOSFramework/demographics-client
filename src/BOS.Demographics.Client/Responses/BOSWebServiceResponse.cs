using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace BOS.Demographics.Client.Responses
{
    public class BOSWebServiceResponse
    {
        public HttpStatusCode StatusCode { get; set; }

        public BOSWebServiceResponse(HttpStatusCode statusCode)
        {
            StatusCode = statusCode;
        }

        public bool IsSuccessStatusCode { get { return (int)StatusCode > 199 && (int)StatusCode < 300; } }
    }
}
