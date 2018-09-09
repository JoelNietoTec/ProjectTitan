using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Cors.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebAPI.Filters;
using WebAPI.Models.Assignments;
using WebAPI.Models.Financial;
using WebAPI.Models.Params;
using WebAPI.Models.Participants;
using WebAPI.Models.Settings;
using WebAPI.Models.Users;

namespace WebAPI
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

            services.AddCors(options =>
            {
                options.AddPolicy("AllowOrigin",
                    builder => builder
                    .AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod());
            });

            services.Configure<MvcOptions>(options =>
            {
                options.Filters.Add(new CorsAuthorizationFilterFactory("AllowOrigin"));
            });

            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddJsonOptions(options =>
                {
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                });
            var connection = Configuration.GetConnectionString("ProjectDB");
            services.AddDbContext<AssignmentsContext>(options => options
                .UseLazyLoadingProxies()
                .UseSqlServer(connection));
            services.AddDbContext<ParticipantsContext>(options => options
                .UseSqlServer(connection));
            services.AddDbContext<ParamsContext>(options => options
                .UseLazyLoadingProxies()
                .UseSqlServer(connection));
            services.AddDbContext<SettingsContext>(options => options
                .UseLazyLoadingProxies()
                .UseSqlServer(connection));
            services.AddDbContext<FinancialContext>(options => options
                .UseLazyLoadingProxies()
                .UseSqlServer(connection));
            services.AddDbContext<UsersContext>(options => options
                .UseLazyLoadingProxies()
                .UseSqlServer(connection));

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(ApiActionFilter));
            })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddJsonOptions(options =>
                {
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                });

            services.AddScoped<ApiActionFilter>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            app.UseCors("AllowOrigin");
        }
    }
}
