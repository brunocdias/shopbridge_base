using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Microsoft.Identity.Web;
using Microsoft.OpenApi.Models;
using Shopbridge_base.Application.Commands.PostProduct;
using Shopbridge_base.Application.Queries.GetProduct;
using Shopbridge_base.Data;
using Shopbridge_base.Data.Repository;
using Shopbridge_base.Domain.Models;
using Shopbridge_base.Domain.Services;
using Shopbridge_base.Domain.Services.Interfaces;
using Shopbridge_base.Infrastructure.Extensions;
using Shopbridge_base.Infrastructure.Utils;
using System.Reflection;


namespace Shopbridge_base
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
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddMicrosoftIdentityWebApi(Configuration.GetSection("AzureAd"));

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Shopbridge_base", Version = "v1" });
            });

            
            /*services.AddDbContext<Shopbridge_Context>(options =>
                    options.UseSqlServer("Server=.\\BRUNOTESTE;Initial Catalog=testeproduct;MultipleActiveResultSets=true;User ID=sa; Password:Bruno1994;"));
            */
            services.AddDbContext<Shopbridge_Context>(option =>
                option.UseSqlServer(Configuration.GetConnectionString("Shopbridge_Context")));

            services.AddScoped<IProductService, ProductService>();

            services.AddAutoMapper(Assembly.GetAssembly(typeof(ApplicationProfile)));
            services.AddFluentValidation(typeof(FluentValidationExtension));
            services.AddTransient<IRepository<Product>, Repository<Product>>();
            services.AddMediatR(typeof(Startup));
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Shopbridge_base v1"));
            }

            app.UseHttpsRedirection();

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
