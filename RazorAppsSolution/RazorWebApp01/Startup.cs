using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Knowledge;
using RazorWebApp01.Data;
using Microsoft.AspNetCore.Identity;

namespace RazorWebApp01
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
            services.AddRazorPages();
            //services.AddDbContextPool<KnowledgeContext>(optionsA => optionsA.UseSqlite("Data Source=knowledge.db"));
            //services.AddDbContext<CustomerDbContext>(options => options.UseInMemoryDatabase("namedb"));
            //services.AddScoped<IKnowrepo, SliteRepo>();
          

            services.AddDbContext<RazorPagesKnowContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("RazorPagesKnowContext")));

            services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 1;
                options.Password.RequiredUniqueChars = 1;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireDigit = false;
            })
            .AddEntityFrameworkStores<RazorPagesKnowContext>();

            services.AddSingleton<Knowledge.UserOptions>();
            //services.AddScoped<Nt>();
            //services.AddDbContext<RazorPagesKnowContext>(options =>
            //        options.UseSqlServer(Configuration.GetConnectionString("RazorPagesKnowContext")));

            services.AddRazorPages().AddRazorRuntimeCompilation();
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
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();    // аутентификация
            app.UseAuthorization();     // авторизация

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
