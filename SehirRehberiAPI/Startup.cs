using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using SehirRehberiAPI.Data;
using SehirRehberiAPI.Helper;
using System.Text;

namespace SehirRehberiAPI
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
            //jwt konfigürasyonu ile alakalı
            var key = Encoding.ASCII.GetBytes(Configuration.GetSection("Appsettings:Token").Value);

            //appconfig içindeki cloudinarysettings ile helper içinde class olan cloudinarysettings
            services.Configure<CloudinarySettings>(Configuration.GetSection("CloudinarySettings"));


            services.AddMvc().AddJsonOptions(opt=>
            {
                opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });
            services.AddCors();
            services.AddScoped<IAppRepository,AppRepository>();
            services.AddScoped<IAuthRepository, AuthRepository>();
            services.AddAutoMapper(typeof(Startup));
            //jwt konfigürasyonu ile alakalı
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            services.AddDbContext<DataContext>(x => x.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseCors(x=>x.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin().AllowCredentials());
            app.UseHttpsRedirection();
            app.UseAuthentication();
            _ = app.UseMvc();
        }
    }
}
