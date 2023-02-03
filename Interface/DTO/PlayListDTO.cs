using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.DTO
{
    public class PlaylistDTO
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public ICollection<SongDTO> Songs { get; set; } = null!;
        [ForeignKey("UserId")]
        public int CreatorId { get; set; }
        public virtual UserDTO Creator { get; set; } = null!;
    }
}
