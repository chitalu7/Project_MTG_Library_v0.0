using Microsoft.EntityFrameworkCore;
using MTGArenaWebAPI.Data.Entities;

namespace MTGArenaWebAPI.Data

{
    public class MTGArenaCardLibraryContext : DbContext
    {
        public MTGArenaCardLibraryContext(DbContextOptions<MTGArenaCardLibraryContext> options) : base(options)
        {

        }
        public DbSet<MTGArenaCards> MTGArenaCards { get; set; }
    }
}
