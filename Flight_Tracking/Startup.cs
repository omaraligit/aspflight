using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flight_Tracking
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            var db = new FlightContext();
            Configuration = configuration;
            Console.WriteLine("db testing ===== ");
            // Note: This sample requires the database to be created before running.
            Console.WriteLine($"Database path: {db.DbPath}.");
            // deleting the database if exits
            db.Database.EnsureDeleted();
            // recreating the database to contain the new scheema if somthing changed
            db.Database.EnsureCreated();
            Console.WriteLine("db creating record ===== ");
            // Create
            Console.WriteLine("Inserting a new Avion");
            db.Add(new Models.Avion { code="BWNG", libelle="boweing" });
            db.SaveChanges();
            Console.WriteLine("db reading record ===== ");
            // Read
            Console.WriteLine("Querying for a Avion");
            var avion = db.Avions
                .OrderBy(b => b.Id)
                .First();
            Console.WriteLine($"found this: {avion.Id} - {avion.libelle}.");

        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
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
            });
        }
    }
}
