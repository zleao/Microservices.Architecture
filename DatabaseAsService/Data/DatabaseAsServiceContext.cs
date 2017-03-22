using DatabaseAsService.Models;
using Microsoft.EntityFrameworkCore;

namespace DatabaseAsService.Data
{
    public class DatabaseAsServiceContext : DbContext
    {
        public DatabaseAsServiceContext(DbContextOptions<DatabaseAsServiceContext> options)
            : base(options)
        {
        }

        public DbSet<Session> Sessions { get; set; }
        public DbSet<Keyword> Keywords { get; set; }
        public DbSet<SessionKeywordMapping> SessionKeywordMappings { get; set; }
    }
}
