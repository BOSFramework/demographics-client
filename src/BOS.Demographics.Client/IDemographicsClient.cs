using BOS.Demographics.Client.ClientModels;
using BOS.Demographics.Client.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BOS.Demographics.Client
{
    public interface IDemographicsClient
    {
        Task<AddPersonResponse<T>> AddPersonAsync<T>(IPerson person) where T : IPerson;
        Task<GetPersonResponse<T>> GetPersonByIdAsync<T>(Guid id) where T : IPerson;
        Task<UpdatePersonResponse> UpdatePersonAsync<T>(IPerson person) where T : IPerson;
        Task<GetPeopleResponse<T>> GetPeopleAsync<T>(bool filterDeleted = true) where T : IPerson;
        Task<DeletePersonResponse> DeletePersonByIdAsync(Guid id);
    }
}
