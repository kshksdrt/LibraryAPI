public static class Seeder
{
  public static void AddAuthors()
  {
    using (var context = new ApplicationDbContext())
    {
      context.Database.EnsureCreated();
      Author Jane = new Author
      {
        Name = "Jane Jackson",
        Books = new List<Book>
        {
            new Book
            {
              Name = "A book",
            },
            new Book
            {
              Name = "Another book",
            }
        }
      };
      context.Authors.Add(Jane);

      context.SaveChanges();
    }
  }
  public static void RemoveAuthors()
  {
    using (var context = new ApplicationDbContext())
    {
      context.Authors.RemoveRange(context.Authors);
      context.Books.RemoveRange(context.Books);

      context.SaveChanges();
    }
  }
}
