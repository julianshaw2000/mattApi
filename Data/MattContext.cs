using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore;
using api.Models;

namespace api.Data
{
    public class MattContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder
        )
        {
            var host =
                Environment.GetEnvironmentVariable("DBHOST") ?? "localhost";
            var port = Environment.GetEnvironmentVariable("DBPORT") ?? "3306";
            var password =
                Environment.GetEnvironmentVariable("DBPASSWORD") ?? "Gloria100";

            // Replace with your connection string.
            var connectionString =
                $"server={host};user=root;password={password};database=ef";

            // Replace with your server version and type.
            // Use 'MariaDbServerVersion' for MariaDB.
            // Alternatively, use 'ServerVersion.AutoDetect(connectionString)'.
            // For common usages, see pull request #1233.
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 27));

            optionsBuilder
                .UseMySql(connectionString, serverVersion) // The following three options help with debugging, but should // be changed or removed for production.
                .LogTo(Console.WriteLine, LogLevel.Information)
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors();
        }
    }
}
