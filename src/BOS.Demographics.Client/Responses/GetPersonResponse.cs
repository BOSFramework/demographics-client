using BOS.Demographics.Client.ClientModels;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace BOS.Demographics.Client.Responses
{
    public class GetPersonResponse<T> 
        : BOSWebServiceResponse where T : IPerson
    {
        public T Person { get; set; }

        public GetPersonResponse(HttpStatusCode statusCode) 
            : base(statusCode)
        {
        }
    }
}
