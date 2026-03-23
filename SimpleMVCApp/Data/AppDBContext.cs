using Microsoft.EntityFrameworkCore;
using SimpleMVCApp.Models;

namespace SimpleMVCApp.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
    }
}
