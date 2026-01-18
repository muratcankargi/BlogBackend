
using BlogBackend.AppContext;
using BlogBackend.Repostories;
using BlogBackend.Repostories.Interfaces;
using BlogBackend.Services;
using Microsoft.EntityFrameworkCore;

namespace BlogBackend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            var conn = builder.Configuration.GetConnectionString("DefaultConn");
            builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseOracle(conn));

            builder.Services.AddScoped(typeof(IRepository<>), typeof(EFRepository<>));

            builder.Services.AddScoped<IBlogRepository, BlogRepository>();

            builder.Services.AddScoped<BlogService>();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAngular",
                    policy =>
                    {
                        policy
                            .WithOrigins("http://localhost:4200")
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            
            app.UseCors("AllowAngular");
            app.UseHttpsRedirection();


            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
