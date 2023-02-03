using Interface.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Model
{
    public class Song
    {
        public int SongID { get; set; }
        public string Title { get; set; } = null!;
        public string Artist { get; set; } = null!;
        public string Link { get; set; } = null!;
        [JsonIgnore]
        public ICollection<Playlist> Playlists { get; set; } = null!;

        public Song()
        {
                
        }
        
        public Song(string title, string artist, string link)
        {
            Title = title;
            Link = link;
            Artist = artist;
        }

        public Song(int id, string title, string artist, string link)
        {
            SongID = id;
            Title = title;
            Link = link;
            Artist = artist;
        }

        public Song(SongDTO songDTO)
        {
            SongID = songDTO.SongID;
            Title = songDTO.Title;
            Link = songDTO.Link;
            Artist = songDTO.Artist;
        }

        public SongDTO ToDTO()
        {
            SongDTO songDTO = new SongDTO();
            songDTO.SongID = SongID;
            songDTO.Title = Title;
            songDTO.Link = Link;
            songDTO.Artist = Artist;
            if (Playlists != null)
            {
                songDTO.PlayLists = Playlists.Select(p => p.ToDTO()).ToList();
            }

            return songDTO;
        }

    }
}
