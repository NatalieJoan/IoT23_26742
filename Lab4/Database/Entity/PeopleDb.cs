// using Microsoft.EntityFrameworkCore;
// using Microsoft.EntityFrameworkCore.Metadata.Builders;
// using Lab4.Database.Entities;

// namespace Lab4.Database.People
// {
//     public class PeopleDb : DbContext
//     {
//         public PeopleDb(DbContextOptions<PeopleDb> options) : base(options)
//         {
//         }

//         protected override void OnModelCreating(ModelBuilder modelBuilder)
//         {
//             ConfigurePersonEntity(modelBuilder.Entity<PersonEntity>());
//         }

//         private void ConfigurePersonEntity(EntityTypeBuilder<PersonEntity> entity)
//         {
//             entity.ToTable("Person");
//             entity.Property(p => p.FirstName).IsRequired().HasMaxLength(200);
//             entity.Property(p => p.LastName).IsRequired().HasMaxLength(200);
//         }

//         public DbSet<PersonEntity> People { get; set; }
//     }
// }