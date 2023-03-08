using ApplicationCore.Services;
using ApplicationCore;
using Infrastructure.Services;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using ApplicationCore.Filters;
using ApplicationCore.Models;
using ApplicationCore.Repositories;
using Infrastructure.Repositories;

namespace WebAPI
{
    public class Startup
    {
        readonly string debugOrigin = "_debugOrigins";
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {

            #region CORS
            services.AddCors(options =>
            {
                options.AddPolicy(name: debugOrigin,
                    builder =>
                    {
                        builder.WithOrigins("http://localhost/",
                                  "http://localhost:3000/", "http://localhost:3001/");
                    });
            });
            #endregion

            #region Controller
            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.PropertyNamingPolicy = null;
            });
            #endregion

            #region Services
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            
            services.AddScoped<IUserService, UserService>();
            #endregion

            #region DbContext
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultLocal"), x => x.MigrationsAssembly("Infrastructure"));
            });
            #endregion
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();

            #region Auth
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = Configuration["Jwt:Issuer"],
                    ValidAudience = Configuration["Jwt:Audience"],
                    IssuerSigningKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(Configuration["Jwt:key"]))
                };
            });
            services.AddAuthorization();
            #endregion

            #region Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1.0", new OpenApiInfo { Title = "Template", Version = "v1.0" });
                c.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                {
                    Description = "Jwt Authorization",
                    Name = "Authorization",
                    In = Microsoft.OpenApi.Models.ParameterLocation.Header,
                    Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });
                c.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[]{}
                    }
                });
                c.EnableAnnotations();
            });
            #endregion
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IHttpContextAccessor ctxAccessor)
        {
            #region Use Developer Page
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

            }
            #endregion

            #region User Swagger
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1.0/swagger.json", "Template v1.0"));
            #endregion

            app.UseHttpsRedirection();

            #region Use CORS
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseCors(debugOrigin);
            #endregion

            app.UseAuthentication();

            app.UseRouting();
            app.UseAuthorization();


            app.UseEndpoints(endpoint => endpoint.MapControllers());
        }
    }
}
