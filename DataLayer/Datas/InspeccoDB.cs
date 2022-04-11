using CoreLayer.Entitys;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Datas
{
   public class InspeccoDB:IdentityDbContext<User,IdentityRole,string>
    {
        public InspeccoDB(DbContextOptions<InspeccoDB> options) : base(options)
        {

        }
        public DbSet<Invitation> Invitations { get; set; }
        public DbSet<Business> Businesses { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);//IEntityTypeConfiguration<> den türeyenleri bul
            base.OnModelCreating(modelBuilder);
        }
    }
}
