using Auth.ModelsCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

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



            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.MapControllers();


            app.Run();
        }
    }
}