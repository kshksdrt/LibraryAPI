using Microsoft.EntityFrameworkCore.Design;
using MySql.EntityFrameworkCore.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<ApplicationDbContext>();
builder.Services.AddSingleton<IDesignTimeServices, MysqlEntityFrameworkDesignTimeServices>();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

public class MysqlEntityFrameworkDesignTimeServices : IDesignTimeServices
{
  public void ConfigureDesignTimeServices(IServiceCollection serviceCollection)
  {
    serviceCollection.AddEntityFrameworkMySQL();
    new EntityFrameworkRelationalDesignServicesBuilder(serviceCollection)
        .TryAddCoreServices();
  }
}
