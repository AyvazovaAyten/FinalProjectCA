using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SushiStore.DAL;
using SushiStore.Models;
using System;
using System.Globalization;
using Microsoft.AspNetCore.Localization;

namespace SushiStore
{
    public class Startup
    {
        public IConfiguration _configuration;
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(_configuration.GetConnectionString("Default"))
            );

            services.AddIdentity<User, IdentityRole>(identityOptions =>
            {
                identityOptions.Password.RequireDigit = true;
                identityOptions.Password.RequireNonAlphanumeric = false;
                identityOptions.Password.RequiredLength = 8;
                identityOptions.Password.RequireLowercase = true;
                identityOptions.Password.RequireUppercase = true;

                identityOptions.User.RequireUniqueEmail = true;

                identityOptions.Lockout.AllowedForNewUsers = true;
                identityOptions.Lockout.MaxFailedAccessAttempts = 3;
                identityOptions.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(20);

                

            }
             ).AddDefaultTokenProviders().AddEntityFrameworkStores<AppDbContext>();


            services.AddDistributedMemoryCache();
            services.AddSession();

            services.AddAutoMapper(typeof(Startup));


            services.AddLocalization(options => options.ResourcesPath = "Resources");
            services.AddControllersWithViews()
                .AddDataAnnotationsLocalization()
                .AddViewLocalization();

            services.Configure<RequestLocalizationOptions>(options =>
            {
                var supportedCultures = new[]
                {
                    new CultureInfo("en"),
                    new CultureInfo("az-Latn"),
                };

                options.DefaultRequestCulture = new RequestCulture("az-Latn");
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
            });



        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            var supportedCultures = new[]
           {
                new CultureInfo("en"),
                new CultureInfo("az-Latn"),
            };
            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("az-Latn"),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures
            });

            app.UseStaticFiles();
            app.UseRouting();


            app.UseAuthentication();   
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "Admin",
                    pattern: "{area:exists}/{Controller=Dashboard}/{Action=Index}/{id?}"
                    );

                endpoints.MapControllerRoute(
                    name:"default",
                    pattern:"{controller=Home}/{action=Index}/{id?}"
                    );
            });
        }
    }
}
