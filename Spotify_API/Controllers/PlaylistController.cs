using DAL.DAL;
using Logic.Container;
using Logic.Containers;
using Logic.Helpers;
using Logic.Model;
using Microsoft.AspNetCore.Mvc;

namespace Spotify_API.Controllers
{
    [ApiController]
    [Route("controller")]
    public class PlaylistController : Controller
    {
        [HttpGet]
        [Route("/Playlist/{id}")]
        public ActionResult GetPlaylist(int id)
        {
            JwtHelper jwtHelper = new JwtHelper();
            var jwt = Request.Cookies["jwt"];
            var token = jwtHelper.Verify(jwt);
            if (token == null)
            {
                return Unauthorized();
            }
            int userId = int.Parse(token.Issuer);

            PlaylistContainer PlaylistContainer = new PlaylistContainer(new PlaylistDAL());
            Playlist playlist = PlaylistContainer.GetPlaylistById(id);
            if (playlist.Id != 0)
            {
                return Ok(playlist);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("/Playlist")]
        public ActionResult GetAllPlaylists()
        {
            JwtHelper jwtHelper = new JwtHelper();
            var jwt = Request.Cookies["jwt"];
            if (jwt == null)
            {
                return Unauthorized();
            }
            var token = jwtHelper.Verify(jwt);
            int userId = int.Parse(token.Issuer);

            PlaylistContainer PlaylistContainer = new PlaylistContainer(new PlaylistDAL());
            List<Playlist> playlists = PlaylistContainer.GetAllPlaylists();
            if (playlists.Count > 0)
            {
                return Ok(playlists);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpPost]
        [Route("/Playlist")]
        public ActionResult CreatePlaylist(string title)
        {
            JwtHelper jwtHelper = new JwtHelper();
            var jwt = Request.Cookies["jwt"];
            var token = jwtHelper.Verify(jwt);
            if (token == null)
            {
                return Unauthorized();
            }        
            int userId = int.Parse(token.Issuer);


            if (string.IsNullOrEmpty(title))
            {
                return BadRequest("no title");
            }
            
            UserContainer userContainer = new UserContainer(new UserDAL());
            
            Playlist playlist = new Playlist()
            {
                Name = title,
                Creator = userContainer.GetSingleUser(userId)
            };

            PlaylistContainer PlaylistContainer = new PlaylistContainer(new PlaylistDAL());
            if (PlaylistContainer.CreatePlaylist(playlist))
            {
                return Ok();
            }
            else
            {
                return BadRequest("playlist already exists or internal server error");
            }
        }

        [HttpGet]
        [Route("/Playlist/User")]
        public ActionResult GetPlaylistsFromUser()
        {
            JwtHelper jwtHelper = new JwtHelper();
            var jwt = Request.Cookies["jwt"];
            var token = jwtHelper.Verify(jwt);

            if (token == null)
            {
                return Unauthorized();
            }

            PlaylistContainer PlaylistContainer = new PlaylistContainer(new PlaylistDAL());
            int userId = int.Parse(token.Issuer);

            List<Playlist> playlists = PlaylistContainer.GetPlaylistsFromUser(userId);
            if (playlists.Count > 0)
            {
                return Ok(playlists);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpDelete]
        [Route("/Playlist/{id}")]
        public ActionResult DeletePlaylist(int id)
        {
            JwtHelper jwtHelper = new JwtHelper();
            var jwt = Request.Cookies["jwt"];
            var token = jwtHelper.Verify(jwt);
            if (token == null)
            {
                return Unauthorized();
            }
            int userId = int.Parse(token.Issuer);

            PlaylistContainer PlaylistContainer = new PlaylistContainer(new PlaylistDAL());
            
            if (PlaylistContainer.DeletePlaylist(id))
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut]
        [Route("/Playlist/{id}")]
        public ActionResult UpdatePlaylist(int id, string title)
        {
            JwtHelper jwtHelper = new JwtHelper();
            var jwt = Request.Cookies["jwt"];
            var token = jwtHelper.Verify(jwt);
            if (token == null)
            {
                return Unauthorized();
            }
            int userId = int.Parse(token.Issuer);

            if (string.IsNullOrEmpty(title))
            {
                return BadRequest("no title");
            }

            Playlist playlist = new Playlist()
            {
                Id = id,
                Name = title
            };

            PlaylistContainer PlaylistContainer = new PlaylistContainer(new PlaylistDAL());
            if (PlaylistContainer.UpdatePlaylist(playlist))
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        [Route("/Playlist/{id}/Song/{songID}")]
        public ActionResult AddSongToPlaylist(int id, int songID)
        {
            JwtHelper jwtHelper = new JwtHelper();
            var jwt = Request.Cookies["jwt"];
            var token = jwtHelper.Verify(jwt);
            if (token == null)
            {
                return Unauthorized();
            }
            int userId = int.Parse(token.Issuer);

            PlaylistContainer PlaylistContainer = new PlaylistContainer(new PlaylistDAL());
            if (PlaylistContainer.AddSongToPlayList(id, songID))
            {
                return Ok();
            }
            else
            {
                return BadRequest("song already exists or internal server error");
            }
        }

        [HttpDelete]
        [Route("/Playlist/{id}/Song/{songID}")]
        public ActionResult RemoveSongFromPlaylist(int id, int songID)
        {
            JwtHelper jwtHelper = new JwtHelper();
            var jwt = Request.Cookies["jwt"];
            var token = jwtHelper.Verify(jwt);
            if (token == null)
            {
                return Unauthorized();
            }
            int userId = int.Parse(token.Issuer);

            PlaylistContainer PlaylistContainer = new PlaylistContainer(new PlaylistDAL());
            if (PlaylistContainer.RemoveSongFromPlayList(id, songID))
            {
                return Ok();
            }
            else
            {
                return BadRequest("song does not exist or internal server error");
            }
        }

        /*[HttpGet]
        [Route("/Playlist/User/{userID}")]
        public ActionResult GetPlaylistsByUser(int userID)
        {
            JwtHelper jwtHelper = new JwtHelper();
            var jwt = Request.Cookies["jwt"];
            var token = jwtHelper.Verify(jwt);
            if (token == null)
            {
                return Unauthorized();
            }
            int userId = int.Parse(token.Issuer);

            PlaylistContainer PlaylistContainer = new PlaylistContainer(new PlaylistDAL());
            List<Playlist> playlists = PlaylistContainer.GetAllPlayListsFromUser(userID);
            if (playlists.Count > 0)
            {
                return Ok(playlists);
            }
            else
            {
                return NoContent();
            }
        }*/
    }
}
