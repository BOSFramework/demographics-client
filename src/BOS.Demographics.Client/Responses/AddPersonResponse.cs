using BOS.Demographics.Client.ClientModels;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace BOS.Demographics.Client.Responses
{
    public class AddPersonResponse<T>
        : BOSWebServiceResponse where T : IPerson
    {
        public T Person { get; set; }
        public List<DemographicsError> Errors { get; set; }

        public AddPersonResponse(HttpStatusCode statusCode) 
            : base(statusCode)
        {
            Errors = new List<DemographicsError>();
        }
    }
}
