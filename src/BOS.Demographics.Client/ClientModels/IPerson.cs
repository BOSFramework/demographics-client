using BOS.Demographics.Client.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BOS.Demographics.Client.ClientModels
{
    public interface IPerson
    {
        [JsonProperty("id")]
        Guid Id { get; set; }

        [JsonProperty("firstName")]
        string FirstName { get; set; }

        [JsonProperty("lastName")]
        string LastName { get; set; }

        [JsonProperty("middleName")]
        string MiddleName { get; set; }

        [JsonProperty("email")]
        string Email { get; set; }

        [JsonProperty("gender")]
        string Gender { get; set; }

        [JsonProperty("phoneNumbers")]
        List<PhoneNumber> PhoneNumbers { get; set; }

        [JsonProperty("addresses")]
        List<Address> Addresses { get; set; }

        [JsonProperty("birthDate")]
        [JsonConverter(typeof(OdataDateTimeConverter))]
        DateTimeOffset? BirthDate { get; set; }

        [JsonProperty("relationshipStatus")]
        [JsonConverter(typeof(OdataEnumJsonConverter))]
        RelationshipStatus RelationshipStatus { get; set; }

        [JsonProperty("deleted")]
        bool Deleted { get; set; }
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
