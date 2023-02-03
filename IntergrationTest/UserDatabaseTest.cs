

using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace IntergrationTest
{
    public class UserDatabaseTest
    {
        SurroundDbContext _context;
        
        [Fact]
        public void Test1()
        {
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkSqlServer()
                .BuildServiceProvider();

            var builder = new DbContextOptionsBuilder<SurroundDbContext>();

            builder.UseSqlServer("Server=localhost;Database=test;User Id=root;Password=student;TrustServerCertificate=True;")
                .UseInternalServiceProvider(serviceProvider);

            //_context = new SurroundDbContext(builder.Options);
            _context.Database.Migrate();
        }
    }
}