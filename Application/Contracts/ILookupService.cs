using Domain.Dtos.Appointment;
using Domain.Dtos.User;
using Domain.Entities;
using Domain.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts
{
    public interface ILookupService
    {
        public Task<Response<string>> AddGender(Gender request);
        public Task<Response<List<Gender>>> GetGenders();
    }
}
