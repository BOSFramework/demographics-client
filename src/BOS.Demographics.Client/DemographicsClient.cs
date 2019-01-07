using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using BOS.Demographics.Client.ClientModels;
using BOS.Demographics.Client.Responses;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BOS.Demographics.Client
{
    public class DemographicsClient : IDemographicsClient
    {
        private readonly HttpClient _httpClient;

        public DemographicsClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        /// <summary>
        /// Adds a person with the provided structure.
        /// </summary>
        /// <typeparam name="T">Your class that implements and can extend the person interface. All extensions are key/value.</typeparam>
        /// <param name="person"></param>
        /// <returns></returns>
        public async Task<AddPersonResponse<T>> AddPerson<T>(IPerson person) where T : IPerson
        {
            var response = await _httpClient.PostAsJsonAsync("People?api-version=1.0", person).ConfigureAwait(false);
            var addPersonResponse = new AddPersonResponse<T>(response.StatusCode);

            if (addPersonResponse.IsSuccessStatusCode)
            {
                addPersonResponse.Person = JsonConvert.DeserializeObject<T>(response.Content.ReadAsStringAsync().Result);
            }

            if (addPersonResponse.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                addPersonResponse.Errors.Add(new DemographicsError(101, "The format of the data that was provided was invalid. Check the structure of you object."));
            }

            return addPersonResponse;
        }

        /// <summary>
        /// Deletes the person with the provided Id.
        /// </summary>
        /// <param name="id">The Id of the eprson to delete.</param>
        /// <returns></returns>
        public async Task<DeletePersonResponse> DeletePersonById(Guid id)
        {
            // Current hacky wacky method used to get the user to set the property for deleted for
            // Should be changed to call an Delete method once it is available.
            var personToDelete = await _httpClient.GetAsync($"People({id.ToString()})?api-version=1.0").ConfigureAwait(false);
            var personPayload = JsonConvert.DeserializeObject<JObject>(personToDelete.Content.ReadAsStringAsync().Result);
            personPayload["deleted"] = true;

            var response = await _httpClient.PutAsJsonAsync($"People({id.ToString()})?api-version=1.0", personPayload);
            return new DeletePersonResponse(response.StatusCode);
        }

        /// <summary>
        /// Get all people that have been saved.
        /// </summary>
        /// <typeparam name="T">Your implementation of a BOS Person, with any additional properties.</typeparam>
        /// <returns></returns>
        public async Task<GetPeopleResponse<T>> GetPeople<T>(bool filterDeleted = true) where T : IPerson
        {
            var httpUrl = filterDeleted ? "People?api-version=1.0" : "People?$filter=Deleted eq false&api-version=1.0";
            var response = await _httpClient.GetAsync(httpUrl).ConfigureAwait(false);
            var jsonProfiles = JsonConvert.DeserializeObject<JObject>(response.Content.ReadAsStringAsync().Result);
            var people = JsonConvert.DeserializeObject<List<T>>(jsonProfiles["value"].ToString()) as List<T>;

            if (people == null)
            {
                 people = new List<T>();
            }

            return new GetPeopleResponse<T>(response.StatusCode) { People = people };
        }

        /// <summary>
        /// Gets a person with the specified Id.
        /// </summary>
        /// <typeparam name="T">Your implementation of a BOS Person, with any additional properties.</typeparam>
        /// <param name="id">The Id of the person to retrieve.</param>
        /// <returns></returns>
        public async Task<GetPersonResponse<T>> GetPersonById<T>(Guid id) where T : IPerson
        {
            var response = await _httpClient.GetAsync($"People({id.ToString()})?api-version=1.0").ConfigureAwait(false);

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return new GetPersonResponse<T>(response.StatusCode);
            }

            var person = JsonConvert.DeserializeObject<T>(response.Content.ReadAsStringAsync().Result);
            return new GetPersonResponse<T>(response.StatusCode) { Person = person };
        }

        /// <summary>
        /// Update a person. This fully updated all properties of the person, so pass the fully updated object. Creates them if they are not there.
        /// </summary>
        /// <typeparam name="T">Your implementation of a BOS Person, with any additional properties.</typeparam>
        /// <param name="person">The person object with all properties you want to ensure are saved.</param>
        /// <returns></returns>
        public async Task<UpdatePersonResponse> UpdatePerson<T>(IPerson person) where T : IPerson
        {
            var response = await _httpClient.PutAsJsonAsync($"People({person.Id.ToString()})?api-version=1.0", person).ConfigureAwait(false);

            return new UpdatePersonResponse(response.StatusCode);
        }
    }
}
