using E_Commerce.Web.Helpers;
using E_CommerceApi.Authentication;
using E_CommerceApi.Handlers;
using E_CommerceApi.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.Web
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
            services.AddControllersWithViews();
            services.AddScoped<HttpHandler>();
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ConnStr")));
            // register services
            services.AddScoped<IAttributeService, AttributeService>();   
            services.AddScoped<IAttributeTypeService,AttributeTypeService>();

            //register services
            /* services.AddScoped<AttributeService>();
            services.AddScoped<BrandService>();
            services.AddScoped<BrandImageService>();
            services.AddScoped<CategoryMainService>();
            services.AddScoped<CartMainService>();
            services.AddScoped<CategoryMainService>();
            services.AddScoped<ColorService>();
            services.AddScoped<Countrieservice>();
            services.AddScoped<ProductImageService>();
            services.AddScoped<ShippingProfileService>();*/
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
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
