using Auth.ModelsCore;
using Microsoft.EntityFrameworkCore;
using MediatR;
using System.Reflection;
using Auth.WebAPI.Common.Behavior.Middlewares;
using FluentValidation;
using System.Globalization;

namespace Auth.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            

            // Setting up data contex
            var connectionString = builder.Configuration.GetConnectionString("AuthApp");

            if(connectionString == null)
            {
                throw new Exception("No connection string in appsettings.json read documentation and use example to fix it");
            }

            builder.Services.AddDbContext<AuthDB>(opt => {
                opt.UseMySQL(connectionString, b => b.MigrationsAssembly("Auth.WebAPI"));
            });


            builder.Services.AddMediatR(cfg => {
                cfg.RegisterServicesFromAssembly(Assembly.Load("Auth.ModelsManipulations"));
                
            });

            var app = builder.Build();
            
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            // Exception Handler
            app.UseMiddleware<CustomExceptionHandlerMiddleware>();

            ValidatorOptions.Global.LanguageManager.Culture = new CultureInfo("en");

            app.MapControllers();


            app.Run();
        }
    }
}