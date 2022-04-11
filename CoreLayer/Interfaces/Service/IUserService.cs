using CoreLayer.Dtos;
using CoreLayer.Entitys;
using SharedLayer.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Interfaces.Service
{
   public interface IUserService:IService<User>
    {
        Task<string> LoginUser(string Email, string password);
        Task<List<BusinessDto>> userBusinessGet(string id);
        Task<UserInvitationsDto> UserbyIdWithInvitation(string id);
        Task<Response<UserDto>> CreateUserAsync(UserSignUpDto userSignUpDto);
        Task<Response<UserDto>> GetUserByNameAsync(string userName);
    }
}
