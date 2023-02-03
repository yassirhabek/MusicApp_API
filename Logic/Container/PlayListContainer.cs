using Interface.Interface;
using Logic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Container
{
    public class PlaylistContainer
    {
        private IPlaylistContainer _playlistContainer;
        
        public PlaylistContainer(IPlaylistContainer playlistContainer)
        {
            _playlistContainer = playlistContainer;
        }

        public bool AddSongToPlayList(int playListID, int songID)
        {
            if (_playlistContainer.CheckSongInPlaylist(playListID, songID))
            {
                return false;
            }
            
            return _playlistContainer.AddSongToPlayList(playListID, songID);
        }

        public bool RemoveSongFromPlayList(int playListID, int songID)
        {
            if (!_playlistContainer.CheckSongInPlaylist(playListID, songID))
            {
                return false;
            }
            
            return _playlistContainer.RemoveSongFromPlayList(playListID, songID);
        }

        public List<Playlist> GetAllPlaylists()
        {
            List<Playlist> playlists = new List<Playlist>();
            foreach (var playlist in _playlistContainer.GetAllPlaylists().Result)
            {
                playlists.Add(new Playlist(playlist));
            }
            return playlists;
        }

        public Playlist GetPlaylistById(int id)
        {
            Playlist playlist = new Playlist(_playlistContainer.GetPlaylistById(id).Result);
            return playlist;
        }

        public List<Playlist> GetPlaylistsFromUser(int userId)
        {
            List<Playlist> playlists = new List<Playlist>();
            foreach (var playlist in _playlistContainer.GetPlaylistFromUser(userId).Result)
            {
                playlists.Add(new Playlist(playlist));
            }
            return playlists;
        }

        public bool CreatePlaylist(Playlist playlist)
        {
            return _playlistContainer.CreatePlaylist(playlist.ToDTO());
        }

        public bool UpdatePlaylist(Playlist playlist)
        {
            return _playlistContainer.UpdatePlaylist(playlist.ToDTO());
        }

        public bool DeletePlaylist(int id)
        {
            return _playlistContainer.DeletePlaylist(id);
        }
        
        

    }
}
