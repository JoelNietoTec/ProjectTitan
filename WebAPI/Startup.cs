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
using WebAPI.Models.Pendings;
using WebAPI.Models.Settings;
using WebAPI.Models.Users;
using WebAPI.Models.Permissions;
using WebAPI.Models.Discards;
using Swashbuckle.AspNetCore.Swagger;

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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
            });

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
                .UseSqlServer(connection));
            services.AddDbContext<PendingsContext>(options => options
                .UseSqlServer(connection));
            services.AddDbContext<PermissionsContext>(options => options
                .UseSqlServer(connection));
            services.AddDbContext<DiscardsContext>(options => options
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
            app.UseSwagger();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseMvc();

            app.UseCors("AllowOrigin");
        }
    }
}
