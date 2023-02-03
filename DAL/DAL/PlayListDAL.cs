using Interface.DTO;
using Interface.Interface;
using Microsoft.EntityFrameworkCore;

namespace DAL.DAL
{
    public class PlaylistDAL : IPlaylistContainer
    {
        public bool CreatePlaylist(PlaylistDTO playlist)
        {
            using (var db = new SurroundDbContext())
            {
                db.Playlists.Add(playlist);
                if (playlist.Creator != null)
                {
                    db.Users.Attach(playlist.Creator);
                }
                return db.SaveChanges() > 0;

            }
        }

        public bool DeletePlaylist(int playListID)
        {
            using (var db = new SurroundDbContext())
            {
                var playlist = db.Playlists.FirstOrDefault(p => p.Id == playListID);
                if (playlist != null)
                {
                    db.Playlists.Remove(playlist);
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        public bool UpdatePlaylist(PlaylistDTO playlist)
        {
            using (var db = new SurroundDbContext())
            {
                var playlistToUpdate = db.Playlists.FirstOrDefault(p => p.Id == playlist.Id);
                if (playlistToUpdate != null)
                {
                    playlistToUpdate.Name = playlist.Name;
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        public bool AddSongToPlayList(int playListID, int songID)
        {
            using (var db = new SurroundDbContext())
            {
                var playlist = db.Playlists.Include(p => p.Songs).FirstOrDefault(p => p.Id == playListID);
                var song = db.Songs.Include(s => s.PlayLists).FirstOrDefault(s => s.SongID == songID);
                if (playlist != null && song != null)
                {
                    playlist.Songs.Add(song);
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        public bool RemoveSongFromPlayList(int playListID, int songID)
        {
            using (var db = new SurroundDbContext())
            {
                var playlist = db.Playlists.Include(p => p.Songs).FirstOrDefault(p => p.Id == playListID);
                var song = db.Songs.Include(s => s.PlayLists).FirstOrDefault(s => s.SongID == songID);
                if (playlist != null && song != null)
                {
                    playlist.Songs.Remove(song);
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        public bool CheckSongInPlaylist(int playListID, int songID)
        {
            using (var db = new SurroundDbContext())
            {
                var playlist = db.Playlists.Include(p => p.Songs).FirstOrDefault(p => p.Id == playListID);
                var song = db.Songs.Include(s => s.PlayLists).FirstOrDefault(s => s.SongID == songID);
                if (playlist != null && song != null)
                {
                    return playlist.Songs.Contains(song);
                }
                return false;
            }
        }

        public async Task<PlaylistDTO> GetPlaylistById(int playListID)
        {
            using (var db = new SurroundDbContext())
            {
                PlaylistDTO playlist = new PlaylistDTO();
                playlist = db.Playlists.Include(p => p.Songs).Include(p => p.Creator).FirstOrDefault(p => p.Id == playListID);
                return playlist;
            }
        }

        public async Task<List<PlaylistDTO>> GetAllPlaylists()
        { 
            using (var db = new SurroundDbContext())
            {
                List<PlaylistDTO> playlistDTOs = await db.Playlists.Include(p => p.Songs).Include(p => p.Creator).ToListAsync();
                return playlistDTOs;
            }
        }
        
        public async Task<List<PlaylistDTO>> GetPlaylistFromUser(int userId)
        {
            using (var db = new SurroundDbContext())
            {
                List<PlaylistDTO> playlists = await db.Playlists.Where(p => p.CreatorId == userId).Include(p => p.Songs).Include(p => p.Creator).ToListAsync();
                return playlists;
            }
        }
        
        
    }
}
