using Interface.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Model
{
    public class Playlist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Song> Songs { get; set; }
        public int CreatorId { get; set; }
        public virtual User Creator { get; set; }

        public Playlist()
        {

        }

        public Playlist(string name, User creator)
        {
            Name = name;
            Creator = creator;
        }

        public Playlist(int id, string name, User creator)
        {
            Id = id;
            Name = name;
            Creator = creator;
        }

        public Playlist(PlaylistDTO playlistDTO)
        {
            if (playlistDTO == null)
            {
                return;
            }

            Id = playlistDTO.Id;
            Name = playlistDTO.Name;
            CreatorId = playlistDTO.CreatorId;
            if (playlistDTO.Creator != null)
            {
                Creator = new User(playlistDTO.Creator);
            }
            if (playlistDTO.Songs != null)
            {
                Songs = playlistDTO.Songs.Select(s => new Song(s)).ToList();
            }
        }
        
        public PlaylistDTO ToDTO()
        {
            PlaylistDTO playlistDTO = new PlaylistDTO();
            playlistDTO.Id = Id;
            playlistDTO.Name = Name;
            playlistDTO.CreatorId = CreatorId;
            if (Creator != null)
            {
                playlistDTO.Creator = Creator.ToDTO();
            }
            if (Songs != null)
            {
                playlistDTO.Songs = Songs.Select(s => s.ToDTO()).ToList();
            }

            return playlistDTO;       
        }
    }
}
