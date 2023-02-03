using Interface.DTO;
using Interface.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DAL
{
    public class SongDAL : ISongContainer
    {
        public bool AddSong(SongDTO songDTO)
        {
            using (var db = new SurroundDbContext())
            {
                db.Songs.Add(songDTO);
                db.SaveChanges();
                return true;
            }
        }
        public bool DeleteSong(SongDTO songDTO)
        {
            using (var db = new SurroundDbContext())
            {
                db.Songs.Remove(songDTO);
                db.SaveChanges();
                return true;
            }
        }
        public bool UpdateSong(SongDTO songDTO)
        {
            using (var db = new SurroundDbContext())
            {
                db.Songs.Update(songDTO);
                db.SaveChanges();
                return true;
            }
        }
        public SongDTO GetSingleSong(int id)
        {
            using (var db = new SurroundDbContext())
            {
                var song = db.Songs.FirstOrDefault(s => s.SongID == id);
                return song;
            }
        }
        public List<SongDTO> GetAllSongs()
        {
            using (var db = new SurroundDbContext())
            {
                var songs = db.Songs.ToList();
                return songs;
            }
        }
    }
}
