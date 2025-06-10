
using kol2.DAL;
using kol2.Services;
using Microsoft.EntityFrameworkCore;

namespace kol2;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        
        // Connection string:
        string? connectionString = builder.Configuration.GetConnectionString("Default");

        // Add services to the container.
        builder.Services.AddAuthorization();
        builder.Services.AddControllers();
        
        // Wstrzyknięcie zależności:
        builder.Services.AddScoped<IService, Service>();
        
        // DbContext:
        builder.Services.AddDbContext<DatabaseContext>(opt =>
        {
            opt.UseSqlServer(connectionString);
        });

        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

        var app = builder.Build();

        app.UseHttpsRedirection();

        app.UseAuthorization();
        
        app.MapControllers();

        app.Run();
    }
}
