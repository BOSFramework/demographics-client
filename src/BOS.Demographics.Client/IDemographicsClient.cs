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
        Task<AddPersonResponse<T>> AddPerson<T>(IPerson person) where T : IPerson;
        Task<GetPersonResponse<T>> GetPersonById<T>(Guid id) where T : IPerson;
        Task<UpdatePersonResponse> UpdatePerson<T>(IPerson person) where T : IPerson;
        Task<GetPeopleResponse<T>> GetPeople<T>(bool filterDeleted = true) where T : IPerson;
        Task<DeletePersonResponse> DeletePersonById(Guid id);
    }
}
