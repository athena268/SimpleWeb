using System.Data.Entity;

namespace Task1.Models
{
    public class MbrContext : DbContext
    {
        public DbSet<Data> Data { get; set; }

        public MbrContext() : base("name=DbConnection")
        {
        }
        
    }
}