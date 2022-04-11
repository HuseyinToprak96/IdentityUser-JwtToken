using CoreLayer.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Interfaces.Repository
{
   public interface IUserRepository:IRepository<User>
    {
        Task<List<Business>> UsergetByIdWithBusinesses(string id);//Kullanıcının Oluşturduğu Firmalar
        //Task<User> UserbyIdWithSubstribers(int id);//kullanıcının abone olduğu firmalar ve rolleri için
        Task<List<Invitation>> UserbyIdWithInvitation(string id);//Aldığı davetler için...
        Task<string> LoginUser(string username, string password);
    }
}
