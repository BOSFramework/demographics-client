using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace BOS.Demographics.Client.Utilities
{
    public class OdataDateTimeConverter : IsoDateTimeConverter
    {
        public OdataDateTimeConverter()
        {
            base.DateTimeFormat = "yyyy-MM-ddTHH:mm:ssZ";
        }
    }
}
