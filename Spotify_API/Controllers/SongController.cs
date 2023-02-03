using DAL.DAL;
using Logic.Container;
using Logic.Containers;
using Logic.Model;
using Microsoft.AspNetCore.Mvc;

namespace Spotify_API.Controllers
{
    [ApiController]
    [Route("controller")]
    public class SongController : Controller
    {
        [HttpGet]
        [Route("/Song/{id}")]
        public ActionResult GetSong(int id)
        {
            SongContainer songContainer = new SongContainer(new SongDAL());
            Song song = songContainer.GetSingleSong(id);
            if (song.SongID != 0)
            {
                return Ok(song);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("/Song")]
        public ActionResult GetAllSongs()
        {
            SongContainer songContainer = new SongContainer(new SongDAL());
            List<Song> songs = songContainer.GetAllSongs();
            if(songs.Count > 0)
            {
                return Ok(songs);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpPost]
        [Route("/Song")]
        public ActionResult CreateSong(string title, string artist, string songLink)
        {
            if (string.IsNullOrEmpty(title))
            {
                return BadRequest("no title");
            }

            if (string.IsNullOrEmpty(artist))
            {
                return BadRequest("no artist");
            }

            if (string.IsNullOrEmpty(songLink))
            {
                return BadRequest("no songLink");
            }

            SongContainer songContainer = new SongContainer(new SongDAL());      
            Song song = new Song(title, artist, songLink);

            if (songContainer.AddSong(song))
            {
                return Ok("Succesfully added");
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        [Route("/Song/{id}")]
        public ActionResult DeleteSong(int id)
        {
            SongContainer songContainer = new SongContainer(new SongDAL());
            Song song = songContainer.GetSingleSong(id);

            if (song == null)
                return NotFound();
            
            if (songContainer.DeleteSong(song))
            {
                return Ok("Succesfully deleted");
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
    