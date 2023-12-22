using Lab4.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lab3.Database
{
    public class PeopleDb : DbContext
    {
        public PeopleDb(DbContextOptions<PeopleDb> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ConfigurePersonEntity(modelBuilder.Entity<PersonEntity>());
            ConfigureAddressEntity(modelBuilder.Entity<AddressEntity>());
            base.OnModelCreating(modelBuilder);
        }
        private void ConfigurePersonEntity(EntityTypeBuilder<PersonEntity> entity)
        {
            entity.ToTable("Person");
            entity.Property(p => p.FirstName).IsRequired().HasMaxLength(200);
            entity.Property(p => p.LastName).IsRequired().HasMaxLength(200);

            entity.HasOne(a => a.address)
            .WithMany(m => m.people)
            .HasForeignKey(fk => fk.AddressId);
        }
        private void ConfigureAddressEntity(EntityTypeBuilder<AddressEntity> entity)
        {
            entity.ToTable("Address");
            entity.Property(a => a.City).IsRequired().HasMaxLength(200);
            entity.Property(a => a.Street).IsRequired().HasMaxLength(200);
            entity.Property(a => a.HomeNumber).IsRequired().HasMaxLength(200);;
            entity.Property(a => a.ZipCode).IsRequired().HasMaxLength(5);
        }
        public DbSet<PersonEntity> People {get; set;}
         public DbSet<AddressEntity> Address {get; set;}
    }
}