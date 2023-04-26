using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions;
using OrderWeb.models;

namespace OrderWeb { 
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

            builder.Services.AddDbContext<OrderContext>(opt => opt.UseMySQL(
                            "Server=localhost;Database=OrderDB;User=root;Password=3306"));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseDefaultFiles(); //启用缺省静态页面（index.html或index.htm）
            app.UseStaticFiles(); //启用静态文件（页面、js、图片等各种前端文件）

            app.UseHttpsRedirection(); //启动http到https的重定向
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}