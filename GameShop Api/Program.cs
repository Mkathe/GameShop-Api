
using GameShop_Api.Data;
using GameShop_Api.Interfaces;
using GameShop_Api.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GameShop_Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();
            builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString")));
            builder.Services.AddScoped<IGameRepository, GameRepository>();
            builder.Services.AddScoped<ISystemRepository, SystemRequirementRepository>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddSwaggerGen();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.MapOpenApi();
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseHttpsRedirection();
            app.MapControllers();
            app.UseCors();
            app.Run();
        }
    }
}
