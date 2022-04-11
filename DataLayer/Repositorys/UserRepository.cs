using CoreLayer.Entitys;
using CoreLayer.Interfaces.Repository;
using DataLayer.Datas;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositorys
{
   public class UserRepository:Repository<User>,IUserRepository
    {
        public UserRepository(InspeccoDB context) : base(context)//base classtan gelen DB
        {
        }

        public async Task<string> LoginUser(string username, string password)
        {
            var user =await _Context.Users.Where(u => u.LastName == username && u.Password == password).SingleOrDefaultAsync();
            if (user != null)
                return "";
            return "";
        }

        public async Task<List<Invitation>> UserbyIdWithInvitation(string id)
        {
           var user= await _Context.Users.Include(u => u.Invitations).Where(u=>u.Id==id).SingleOrDefaultAsync();
            return user.Invitations;
        }

        public async Task<List<Business>> UsergetByIdWithBusinesses(string id)
        {
            var user= await _Context.Users.Include(u => u.Businesses).Where(u => u.Id == id).SingleOrDefaultAsync();
            return user.Businesses;
        }
    }
}
