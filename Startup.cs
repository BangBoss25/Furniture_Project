using Furniture_Project.Data;
using Furniture_Project.Models;
using Furniture_Project.Repositories.AkunRepository;
using Furniture_Project.Repositories.BarangRepository;
using Furniture_Project.Repositories.PesananRepository;
using Furniture_Project.Services;
using Furniture_Project.Services.AkunService;
using Furniture_Project.Services.BarangService;
using Furniture_Project.Services.PesananService;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Furniture_Project
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
            services.AddDbContext<AppDbContext>(o =>
            {
                o.UseMySQL(Configuration.GetConnectionString("mysql"));
            });

            services.AddAuthentication("CookieAuth")
                .AddCookie("CookieAuth", options =>
                {
                    options.LoginPath = "/Akun/SignIn";
                    options.AccessDeniedPath = "/Home/Dilarang";
                });

            services.AddScoped<IAkunRepository, AkunRepository>();
            services.AddScoped<IAkunService, AkunService>();

            services.AddScoped<IBarangRepository, BarangRepository>();
            services.AddScoped<IBarangService, BarangService>();

            services.AddScoped<IPesananRepository, PesananRepository>();
            services.AddScoped<IPesananService, PesananService>();

            services.AddTransient<FileService>();

            services.AddTransient<EmailService>();

            services.Configure<Email>(Configuration.GetSection("AturEmail"));

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");

                app.UseHsts();
            }
            
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapAreaControllerRoute(
                    name: "AreaAdmin",
                    areaName: "Admin",
                    pattern: "Admin/{controller=Home}/{action=Index}/{id?}"
                    );
                endpoints.MapAreaControllerRoute(
                    name: "AreaUser",
                    areaName: "User",
                    pattern: "User/{controller=Home}/{action=Index}/{id?}"
                    );
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
