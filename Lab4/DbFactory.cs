using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Lab3.Database
{
    public class PeopleDbFactory : IDesignTimeDbContextFactory<PeopleDb>
        {
            public PeopleDb CreateDbContext(string[] args)
            {
                var optionsBuilder = new DbContextOptionsBuilder<PeopleDb>();
                optionsBuilder.UseSqlServer("Server=tcp:cdvnhserver.database.windows.net,1433;Initial Catalog=CDV-2023;Persist Security Info=False;User ID=natalia;Password=#cdvnhserver2001;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

                return new PeopleDb(optionsBuilder.Options);
            }
        }
    }