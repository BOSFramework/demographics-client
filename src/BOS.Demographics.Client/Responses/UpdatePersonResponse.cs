using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace BOS.Demographics.Client.Responses
{
    public class UpdatePersonResponse : BOSWebServiceResponse
    {
        public UpdatePersonResponse(HttpStatusCode statusCode) 
            : base(statusCode)
        {
        }
    }
}
