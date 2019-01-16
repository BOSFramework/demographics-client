using BOS.Demographics.Client.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BOS.Demographics.Client.ClientModels
{
    public interface IPerson
    {
        Guid Id { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string MiddleName { get; set; }
        string Email { get; set; }
        string Gender { get; set; }
        List<PhoneNumber> PhoneNumbers { get; set; }
        List<Address> Addresses { get; set; }
        bool Deleted { get; set; }


        [JsonConverter(typeof(OdataDateTimeConverter))]
        DateTimeOffset? BirthDate { get; set; }

        [JsonConverter(typeof(OdataEnumJsonConverter))]
        RelationshipStatus RelationshipStatus { get; set; }
    }

    public enum RelationshipStatus
    {
        Unknown = 0,
        Single = 1,
        Married = 2,
        CivilUnion = 3,
        DomesticPartnership = 4,
        Divorced = 5,
        Widowed = 6
    }
}
