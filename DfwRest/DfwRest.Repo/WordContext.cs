using Microsoft.EntityFrameworkCore;

namespace DfwRest.Repo
{
    public sealed class WordContext : DbContext
    {
        public WordContext(DbContextOptions<WordContext> options) : base(options)
        {
        }

        public DbSet<WordModel> Texts { get; set; }
    }
}
