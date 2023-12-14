using Lab4.DTO;
using Lab4.Rest.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lab4.Rest.Database
{
    public class AddressesDb : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            ConfigurePersonEntity(modelBuilder.Entity<PersonEntity>());
            ConfigureAddressEntity(modelBuilder.Entity<AddressEntity>());
        }
        private void ConfigureAddressEntity(EntityTypeBuilder<AddressEntity> entity)
        {
            entity.ToTable("Address");

            entity.Property(p => p.AddressLine1).HasMaxLength(200).IsRequired();
            entity.Property(p => p.AddressLine2).HasMaxLength(500).IsRequired(false);
            entity.Property(p => p.City).HasMaxLength(100).IsRequired();

            entity.HasMany(p => p.People)
            .WithOne(o => o.Address)
            .HasForeignKey(fk => fk.AddressId);
        }

        private void ConfigurePersonEntity(EntityTypeBuilder<PersonEntity> entity)
        {
            entity.ToTable("Person");

            entity.Property(p => p.FirstName).HasMaxLength(200).IsRequired();
            entity.Property(p => p.LastName).HasMaxLength(200).IsRequired();

            entity.HasOne(object => object.Address)
            .WithMany(m => m.People)
            .HasForeignKey(fk => fk.AddressId);
        }

        public DbSet<AddressEntity> Addresses { get; set; }
    }
}