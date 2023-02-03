using Interface.DTO;
using Interface.Interface;
using Logic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Container
{
    public class SongContainer
    {
        private ISongContainer _iSongContainer;
        public SongContainer(ISongContainer songContainer)
        {
            _iSongContainer = songContainer;
        }

        public bool AddSong(Song song)
        {
            return _iSongContainer.AddSong(song.ToDTO());
        }
        public bool DeleteSong(Song song)
        {
            return _iSongContainer.DeleteSong(song.ToDTO());
        }
        public bool UpdateSong(Song song)
        {
            return _iSongContainer.UpdateSong(song.ToDTO());
        }
        public Song GetSingleSong(int id)
        {
            Song song = new Song(_iSongContainer.GetSingleSong(id));
            return song;
        }
        public List<Song> GetAllSongs()
        {
            List<Song> songs = new List<Song>();
            foreach (SongDTO songDTO in _iSongContainer.GetAllSongs())
            {
                songs.Add(new Song(songDTO));
            }
            return songs;
        }
    }
}
