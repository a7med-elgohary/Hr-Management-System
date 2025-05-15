using HR_System.Application.Services;
using HR_System.Domain.Models;
using HR_System.Infrastructure.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using HR_System.Application.intrfaces;
using HR_System.Infrastructure.Intefaces;

namespace HR_System
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            // Register AutoMapper and scan for MappingProfile
            builder.Services.AddAutoMapper(typeof(HR_System.Api.Mappings.MappingProfile));
            // enable CORS
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", policy =>
                    policy.WithOrigins("https://yourdomain.com", "http://localhost:3000", "https://system-e-bussiness.vercel.app")
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });
            //Context
            builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            #region Swagger/OpenAPI Configuration
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "HR System API", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    In = ParameterLocation.Header,
                    Scheme = "Bearer"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
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
                        new string[] {}
                    }
                });
            });
            #endregion

            #region Add JWT Authentication
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                // options.RequireHttpsMetadata = false;  
                // options.Authority = "https://your-auth-server.com"; 
                // options.Audience = "your-api-audience"; 
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = builder.Configuration["Jwt:Issuer"],
                    ValidAudience = builder.Configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
                };
                // فقط للتطوير المحلي، لا تستخدم في الإنتاج
                options.RequireHttpsMetadata = false;
            });
            builder.Services.AddAuthorization();
            #endregion

            #region DB Context

            #endregion

            #region dependency injection
            builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            builder.Services.AddScoped<IEmployeeService, EmployeeService>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IAuthService, AuthService>();
            builder.Services.AddScoped<IEventRepository, EventsRepository>();
            builder.Services.AddScoped<IProjectRepository, ProjectRepository>(); 
            builder.Services.AddScoped<IProjectService, ProjectServices>();
            builder.Services.AddScoped<IEventRepository, EventsRepository>();
            builder.Services.AddScoped<IEventService, EventService>();
            #endregion



            var app = builder.Build();

            // Enforce HTTPS
            app.UseHttpsRedirection();
            app.UseHsts();
            app.UseStaticFiles();
            app.UseRouting();

            //Configure the HTTP request pipeline.
          //  if (app.Environment.IsDevelopment())
          // {
                app.UseSwagger();
                app.UseSwaggerUI(
                    c =>
                    {
                        // تأكد من أن swagger UI يفتح على الفور
                        c.SwaggerEndpoint("/swagger/v1/swagger.json", "HR System API v1");
                        c.RoutePrefix = string.Empty; 
                    });
            //}


            app.UseStaticFiles();
            app.UseRouting();
            app.UseCors("AllowAll");
            app.UseAuthentication();  
            app.UseAuthorization();   
            app.MapControllers();
            // root health-check endpoint
            app.MapGet("/", context => {
                context.Response.Redirect("/swagger");
                return Task.CompletedTask;
            });
            app.Run();
        }
    }

}