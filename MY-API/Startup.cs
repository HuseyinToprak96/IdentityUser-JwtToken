using CoreLayer.Configuration;
using CoreLayer.Entitys;
using CoreLayer.Interfaces;
using CoreLayer.Interfaces.Repository;
using CoreLayer.Interfaces.Service;
using DataLayer.Datas;
using DataLayer.Repositorys;
using DataLayer.UnitOfWorks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using ServisLayer.Map;
using ServisLayer.Services;
using SharedLayer.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace MY_API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<InspeccoDB>(Options =>
Options.UseSqlServer(Configuration.GetConnectionString("SqlConnection"), sqlOption =>
{
sqlOption.MigrationsAssembly("DataLayer");
})
);
            services.Configure<CustomTokenOptions>(Configuration.GetSection("TokenOption"));
            var tokenOption = Configuration.GetSection("TokenOption").Get<CustomTokenOptions>();          
            services.Configure<List<Client>>(Configuration.GetSection("Clients"));
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped(typeof(IService<>), typeof(Service<>));
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IBusinessRepository, BusinessRepository>();
            services.AddScoped<IBusinessService, BusinessService>();
            services.AddAutoMapper(typeof(DtoMapper));
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            //!IDENTITYUSER!!
            services.AddIdentity<User,IdentityRole>(
               opt =>
              {
               opt.User.RequireUniqueEmail = true;//Unique olsun
               opt.Password.RequireNonAlphanumeric = false;//alphanumeric karakter zorunlu deðil
              }
              ).AddEntityFrameworkStores<InspeccoDB>().AddDefaultTokenProviders();//Þifre sýfýrmalama iþlemleri için token üretmek için
                                                                                  //gerekli

            services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, opts =>
            {
                var tokenOption = Configuration.GetSection("TokenOption").Get<CustomTokenOptions>();

                opts.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                {
                    ValidIssuer = tokenOption.Issuer,
                    ValidAudience=tokenOption.Audience[0],
                    IssuerSigningKey=SignService.GetSymmetricSecurityKey(tokenOption.SecurityKey),

                    ValidateIssuerSigningKey=true,
                    ValidateAudience=true,
                    ValidateIssuer=true,
                    ValidateLifetime=true,
                    ClockSkew=TimeSpan.Zero//server lar ayný zamanlý çalýþacak..

                };

            });

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MY_API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MY_API v1"));
            }

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
