using CoreLayer.Dtos;
using CoreLayer.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Interfaces.Service
{
   public interface IBusinessService:IService<Business>
    {
        Task<BusinessInvitationsDto> BusinessGetByIdwithUsers(int id);
    }
}
