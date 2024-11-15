using Domain.Dtos.User;
using Domain.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts
{
    public interface IUserService
    {
        public Response<GetUserResponse> Add(AddUserRequest request);
        public Response<GetUserResponse[]> GetAll();
        public Response<GetUserResponse> Get(int id);
        public Response<GetUserResponse> Update(int id, UpdateUserRequest request);
    }
}
