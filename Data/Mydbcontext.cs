using Goal_Mate.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Goal_Mate.Data
{
    public class Mydbcontext : IdentityDbContext
    {
       public DbSet<User> Users { get; set; }
        public Mydbcontext(DbContextOptions<Mydbcontext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
