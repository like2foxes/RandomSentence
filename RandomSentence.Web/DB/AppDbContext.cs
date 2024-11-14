using Microsoft.EntityFrameworkCore;

namespace RandomSentence.Web;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Sentence> Sentences { get; set; }

}
