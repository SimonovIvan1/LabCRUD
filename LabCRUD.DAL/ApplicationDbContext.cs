using LabCRUD.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace LabCRUD.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
            Database.EnsureCreated();
        }
        
        public DbSet<Bakery> Bakery { get; set; }
        public DbSet<Works> Works { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=WIN-P4PAK711HQL\SQLEXPRESS;Database=Bakery2;Trusted_Connection=True;");
        }

         protected override void OnModelCreating(ModelBuilder modelBuilder)
          {
              modelBuilder.Entity<Bakery>(builder =>
              {
                  builder.ToTable("Bakery")
                      .HasKey(k => k.Id);

                  builder.Property(k => k.Id)
                      .ValueGeneratedNever()
                      .HasColumnName("Id");

                  builder.Property(k => k.Name)
                      .HasColumnName("Name");

                  builder.Property(k => k.Number)
                      .HasColumnName("Number");

                  builder.Property(k => k.Street)
                     .HasColumnName("Street");

                  builder.Property(k => k.House)
                     .HasColumnName("House");
              });

              modelBuilder.Entity<Works>(builder =>
              {
                  builder.ToTable("Works")
                      .HasKey(k => k.Id);

                  builder.Property(k => k.Id)
                      .ValueGeneratedNever()
                      .HasColumnName("Id");

                  builder.Property(k => k.Worker)
                      .HasColumnName("Worker");

                  builder.Property(k => k.Actions)
                      .HasColumnName("Actions");

                  builder.Property(k => k.BakeryId)
                      .HasColumnName("BakeryId");
              });
          }
    }
}