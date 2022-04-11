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
    public class BusinessRepository : Repository<Business>, IBusinessRepository
    {
        public BusinessRepository(InspeccoDB context) : base(context)//base classtan gelen DB
        {
        }

        public async Task<Business> BusinessGetByIdwithBuilder(int id)
        {
            return await _Context.Businesses.Include(b => b.user).Where(b => b.BusinessId == id).SingleOrDefaultAsync();
        }

        public async Task<Business> BusinessGetByIdwithInvitations(int id)
        {
            return await _Context.Businesses.Include(x=>x.Invitations).Where(b=>b.BusinessId==id).SingleOrDefaultAsync();
        }

        public async Task<Business> BusinessGetByIdwithSubstriber(int id)
        {
            return await _Context.Businesses.Where(b => b.BusinessId == id).SingleOrDefaultAsync();
        }

        public Task<Business> BusinessGetByIdwithSubstribers(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Business> GetByIdBusiness(int id)//Bütün bilgiler için...
        {
            return await _Context.Businesses.Include(b => b.user).Include(b => b.Invitations).Where(b => b.BusinessId == id).SingleOrDefaultAsync();
        }
    }
}
