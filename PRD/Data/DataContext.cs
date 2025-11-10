using Microsoft.EntityFrameworkCore;
using PRD.Model;

namespace PRD.Data
{
    public class DataContext: DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        { 
        }


        public DbSet<BaseLNcs> BaseRec { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
          
        }
    }


}
