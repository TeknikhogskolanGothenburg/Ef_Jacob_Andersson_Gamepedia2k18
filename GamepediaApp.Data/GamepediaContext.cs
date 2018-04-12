using GamepediaApp.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;

namespace GamepediaApp.Data
{
    public class GamepediaContext : DbContext
    {
        public DbSet<Country> Countries { get; set; }
        public DbSet<Map> Maps { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<TeamPlayer> TeamPlayers { get; set; }
        public DbSet<Tournament> Tournaments { get; set; }
        public DbSet<TournamentMap> TournamentMaps { get; set; }

        public static readonly LoggerFactory GamepediaLoggerFactory
            = new LoggerFactory(new[]
            {
                new ConsoleLoggerProvider((category, level)
                    => category == DbLoggerCategory.Database.Command.Name
                    && level == LogLevel.Information, true)
            });

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TeamPlayer>().HasKey(m => new { m.PlayerId, m.TeamId });
            modelBuilder.Entity<TournamentMap>().HasKey(m => new { m.TournamentId, m.MapId });
            modelBuilder.Entity<Team>().Property(p => p.TeamLogo).HasColumnType("image");
            modelBuilder.Entity<Country>().Property(p => p.FlagImage).HasColumnType("image");
            modelBuilder.Entity<Tournament>().Property(m => m.TeamId).HasColumnName("TeamWinnerId");
            modelBuilder.Entity<Country>().Property(m => m.CountryCode).HasMaxLength(2);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .EnableSensitiveDataLogging()
                .UseLoggerFactory(GamepediaLoggerFactory)
                .UseSqlServer("Server = (localdb)\\mssqllocaldb; Database = GamepediaDb3; Trusted_Connection = True;");
        }
    }
}
