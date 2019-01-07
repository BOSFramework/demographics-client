using BOS.Demographics.Client.ClientModels;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace BOS.Demographics.Client.Responses
{
    public class GetPeopleResponse<T> 
        : BOSWebServiceResponse where T : IPerson
    {
        public List<T> People { get; set; }

        public GetPeopleResponse(HttpStatusCode statusCode)
            : base(statusCode)
        {

        }
    }
}
