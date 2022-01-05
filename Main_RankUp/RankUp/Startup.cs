using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MySqlConnector;
using RankUp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RankUp
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

            services.AddDbContextPool<AppDBContext>(options => options.UseSqlServer(Configuration.GetConnectionString("RankUpConnectionString")));
            services.AddTransient<MySqlConnection>(_ => new MySqlConnection(Configuration["ConnectionStrings:RankUpRemoteConnectionString"]));
            services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<AppDBContext>().AddDefaultTokenProviders();
            services.AddControllersWithViews();
            services.AddScoped<IUserRepository, UsersRepository>();
            services.AddScoped<ICritiqueRepository, CritiqueRepository>();

            services.AddScoped<ICVReview, CVReview>();
            services.AddScoped<IFormSection, FormSection>();
            services.AddScoped<IFormQuestion, FormQuestion>();
            services.AddScoped<IFormOption, FormOption>();
            services.AddScoped<IForm, Form>();

            services.AddScoped<ICvReviewRequest, CvReviewRequest>();
            services.AddScoped<IBoardUserRepository, BoardUserRepository>();
            services.AddScoped<IReviewRequestsRepository, ReviewRequestsRepository>();
            services.AddScoped<ITaskRepository, TaskRepository>();
            services.AddScoped<IStatisticalDataRepository, StatisticalDataRepository>();

            services.Configure<MailSettings>(Configuration.GetSection("MailSettings"));
            services.AddTransient<IMailService, MailService>();

            services.AddMvc(options =>
            {
                var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
                options.Filters.Add(new AuthorizeFilter(policy));
            });
            //services.AddAuthentication().AddGoogle(options=> { options.ClientId = Configuration["Authentication:Google:ClientId"]; options.ClientSecret = Configuration["Authentication:Google:ClientSecret"]; });
            //services.AddAuthentication().AddLinkedIn(options => { options.ClientId = Configuration["Authentication:LinkedIn:ClientId"]; options.ClientSecret = Configuration["Authentication:LinkedIn:ClientSecret"]; options.Events = new OAuthEvents() { OnRemoteFailure = loginFailureHandler => { var authProperties = options.StateDataFormat.Unprotect(loginFailureHandler.Request.Query["state"]); loginFailureHandler.Response.Redirect("/Account/login"); loginFailureHandler.HandleResponse(); return Task.FromResult(0); } }; });

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

            app.UseAuthentication();
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
