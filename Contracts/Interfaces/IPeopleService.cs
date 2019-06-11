using Entities.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Interfaces
{
    public interface IPeopleService
    {
        Task<PeopleResponse> GetPeople();
    }
}
