using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("[controller]")]
public class LibraryController
{
  private readonly ApplicationDbContext _dbContext;

  public LibraryController(ApplicationDbContext dbContext)
  {
    _dbContext = dbContext;
  }

  [HttpGet(Name = "GetWeatherForecast")]
  [Route("authors")]
  public List<Author> GetAuthors()
  {
    using (var context = new ApplicationDbContext())
    {
      return context.Authors.Include(a => a.Books).ToList();
    }
  }

  [HttpGet(Name = "Seed")]
  [Route("seed")]
  public void SeedDatabase()
  {
    Seeder.AddAuthors();
  }

  [HttpGet(Name = "Unseed")]
  [Route("unseed")]
  public void UnseedDatabase()
  {
    Seeder.RemoveAuthors();
  }
}