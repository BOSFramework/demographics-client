using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BOS.Demographics.Client.ClientModels
{
    public class Address
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
    }
}
