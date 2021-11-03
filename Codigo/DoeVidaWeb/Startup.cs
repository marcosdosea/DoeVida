using AutoMapper;
using Core;
using Core.Service;
using Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DoeVidaWeb
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

            // dependency injection DbContext
            services.AddDbContext<DoeVidaDbContext>(options =>
                options.UseMySQL(
                    Configuration.GetConnectionString("DoeVidaDatabase")));

            // dependency injection Services
            services.AddTransient<IOrganizacaoService, OrganizacaoService>();
            services.AddTransient<IDoadorService, DoadorService>();
            services.AddTransient<IItemService, ItemService>();
            services.AddTransient<IAgendamentoService, AgendamentoService>();

            // dependency injection Mappers
            services.AddAutoMapper(typeof(Startup).Assembly);

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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(
                    name: "Doador",
                    pattern: "{controller=Doador}/{action=Index}/{id?}");
            });
        }
    }
}
