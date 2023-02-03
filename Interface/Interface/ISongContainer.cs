using Interface.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.Interface
{
    public interface ISongContainer
    {
        bool AddSong(SongDTO songDTO);
        bool DeleteSong(SongDTO songDTO);
        bool UpdateSong(SongDTO songDTO);
        SongDTO GetSingleSong(int id);
        List<SongDTO> GetAllSongs();
    }
}
