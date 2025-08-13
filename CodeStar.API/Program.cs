
using AutoMapper;
using CodeStar.API.DI;
using CodeStar.Application.Interfaces;
using CodeStar.Infrastructure.Data;
using CodeStar.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CodeStar.API
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

            //builder.Services.AddDbContext<CodeStarDbContext>(options =>
            //options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))

            //);

            builder.Services.AddDbContext<CodeStarDbContext>(options =>
            options.UseSqlServer(
            builder.Configuration.GetConnectionString("DefaultConnection"),
            sqlOptions => sqlOptions.CommandTimeout(60)));

            #region DI

            builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());


            builder.Services.AddAutoMapper(typeof(CodeStar.Application.Common.Mappings.MappingProfile));
            builder.Services.AddDependency();
            #endregion

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}