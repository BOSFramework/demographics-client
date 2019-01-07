using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BOS.Demographics.Client.ClientModels
{
    public class PhoneNumber
    {
        [JsonProperty("number")]
        public string Number { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }
}
