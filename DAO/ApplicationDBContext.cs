using BusinessObject;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DAO
{
    public class ApplicationDbContext : IdentityDbContext<Account, IdentityRole<string>, string>
    {
        public DbSet<Flower> Flowers { get; set; }
        public DbSet<FlowerMedia> FlowerMedia { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Account> Users { get; set; }
        public ApplicationDbContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Flower>()
                .HasOne(f => f.Account)
                .WithMany(a => a.Flowers)
                .HasForeignKey(f => f.AccountId);

            modelBuilder.Entity<Flower>()
                .HasMany(f => f.FlowerMedia)
                .WithOne(fm => fm.Flower)
                .HasForeignKey(fm => fm.FlowerId);
        }
    }
}
