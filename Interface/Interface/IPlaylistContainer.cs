using Interface.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.Interface
{
    public interface IPlaylistContainer
    {
        public Task<List<PlaylistDTO>> GetAllPlaylists();
        public Task<List<PlaylistDTO>> GetPlaylistFromUser(int userId);
        public Task<PlaylistDTO> GetPlaylistById(int id);
        public bool CreatePlaylist(PlaylistDTO playlist);
        public bool UpdatePlaylist(PlaylistDTO playlist);
        public bool DeletePlaylist(int id);
        bool AddSongToPlayList(int playListID, int songID);
        bool RemoveSongFromPlayList(int playListID, int songID);
        bool CheckSongInPlaylist(int playListID, int songID);
    }
}
