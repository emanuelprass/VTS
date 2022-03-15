using AutoMapper;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Serialization;
using SceletonAPI.Application.Infrastructures;
using SceletonAPI.Application.Infrastructures.AutoMapper;
using SceletonAPI.Application.Interfaces;
using SceletonAPI.Application.Misc;
using SceletonAPI.Application.UseCases.RegisterUser;
using SceletonAPI.Infrastructure.Authorization;
using SceletonAPI.Infrastructure.ErrorHandler;
using SceletonAPI.Infrastructure.FileManager;
using SceletonAPI.Infrastructure.Notifications.Email;
using SceletonAPI.Infrastructure.Persistences;
using System.IO;
using System.Linq;
using System.Reflection;


namespace SceletonAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddHttpClient();
            services.AddRazorPages();

            services.AddDbContext<IDBContext, DBContext>(options =>
               options
               .UseLazyLoadingProxies()
               .UseSqlServer(Configuration.GetConnectionString("MasterData")));
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
                endpoints.MapRazorPages();
            });
        }
    }
}