
using Contracts;
using DAL;
using Microsoft.EntityFrameworkCore;
using Services.Database;
using Services.Memory;

namespace WebAPI_Sekcja1
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

            builder.Services.AddDbContext<PeopleContext>();

            //builder.Services.AddTransient<IPeopleService, PeopleMemoryRepository>();
            //builder.Services.AddScoped<IPeopleService, PeopleMemoryRepository>();
            builder.Services.AddScoped<IPeopleService, PeopleDatabaseRepository>();
            //builder.Services.AddSingleton<IPeopleService, PeopleMemoryRepository>();

            const string CORS_POLICY_NAME = "myCORS";

            builder.Services.AddCors(corsBuilder => corsBuilder
                .AddPolicy(CORS_POLICY_NAME, policyBuilder => policyBuilder
                    .WithOrigins("http://localhost:4200")
                    .AllowAnyHeader()
                    .AllowAnyMethod()));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors(CORS_POLICY_NAME);
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
