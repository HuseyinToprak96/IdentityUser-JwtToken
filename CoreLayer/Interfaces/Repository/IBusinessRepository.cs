using CoreLayer.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Interfaces.Repository
{
   public interface IBusinessRepository:IRepository<Business>
    {
        Task<Business> BusinessGetByIdwithInvitations(int id);//Firma id'sine göre davetlileri getirme.
        Task<Business> BusinessGetByIdwithSubstribers(int id);
        Task<Business> BusinessGetByIdwithBuilder(int id);
        Task<Business> GetByIdBusiness(int id);
        
    }
}
