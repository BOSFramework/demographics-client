using System;
using System.Collections.Generic;
using System.Text;

namespace BOS.Demographics.Client.ClientModels
{
    public class DemographicsError
    {
        public int ErrorCode { get; set; }
        public string Message { get; set; }

        public DemographicsError(int errorCode, string message)
        {
            ErrorCode = errorCode;
            Message = message;
        }
    }
}
