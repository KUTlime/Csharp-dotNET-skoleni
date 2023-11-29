using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var dbContext = new MyDbContext();

await dbContext.Database.EnsureCreatedAsync();

await dbContext.Persons.AddAsync(new Person(1, "Test", "TestLastName"));
_ = dbContext.SaveChangesAsync();

Console.ReadLine(); 

public class MyDbContext : DbContext
{
    public DbSet<Person> Persons { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlite("Data Source=LocalDatabase.db");
    }
}

public record Person(int Id, string FirstName, string LastName);