using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.DTO
{
    public class SongDTO
    {
        [Key]
        public int SongID { get; set; }
        public string Title { get; set; } = null!;
        public string Artist { get; set; } = null!;
        public string Link { get; set; } = null!;
        public virtual ICollection<PlaylistDTO> PlayLists { get; set; } = null!;
    }
}
