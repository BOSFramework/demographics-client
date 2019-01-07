using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace BOS.Demographics.Client.Responses
{
    public class DeletePersonResponse : BOSWebServiceResponse
    {
        public DeletePersonResponse(HttpStatusCode statusCode) 
            : base(statusCode)
        {
        }
    }
}
