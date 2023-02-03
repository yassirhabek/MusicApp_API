using Interface.DTO;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class SurroundDbContext : DbContext
    {   
        public DbSet<UserDTO> Users { get; set; } = null!;
        public DbSet<SongDTO> Songs { get; set; } = null!;
        public DbSet<PlaylistDTO> Playlists { get; set; } = null!;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=mssqlstud.fhict.local;Database=dbi485050;User Id=dbi485050;Password=Vredeoord123;TrustServerCertificate=True;");
        }
    }
}
