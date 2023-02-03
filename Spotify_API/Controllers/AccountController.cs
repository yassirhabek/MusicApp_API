using DAL.DAL;
using Logic.Containers;
using Logic.Model;
using Logic.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace Spotify_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : Controller
    {
        [HttpGet]
        [Route("/Credentials/{id}")]
        public ActionResult GetUser(int id)
        {
            UserContainer userContainer = new UserContainer(new UserDAL());
            User user = userContainer.GetSingleUser(id);
            if (user.UserID != 0)
            {
                return Ok(user);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("/Credentials")]
        public ActionResult GetUserFromJwt()
        {
            try
            {
                UserContainer userContainer = new UserContainer(new UserDAL());
                JwtHelper jwtHelper = new JwtHelper();
                var jwt = Request.Cookies["jwt"];
                var token = jwtHelper.Verify(jwt);

                int userId = int.Parse(token.Issuer);

                User user = userContainer.GetSingleUser(userId);
                if (user.UserID != 0)
                {
                    return Ok(user);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch
            {
                return Unauthorized();
            }
        }

        [HttpPost]
        [Route("/Credentials/Register")]
        public ActionResult Register(string email, string userName, string password, string verPass)
        {
            UserContainer userContainer = new UserContainer(new UserDAL());
            User user = new User(userName, email, password, verPass);
            List<string> errors = new List<string>();
            if (userContainer.Register(user, out errors))
            {
                return Ok("Succesfully registered");
            }
            else
            {
                return BadRequest(errors);
            }
        }

        [HttpPost]
        [Route("/Credentials/Login")]
        public ActionResult Login(string username, string password)
        {
            UserContainer userContainer = new UserContainer(new UserDAL());
            User user = new User(username, password);
            List<string> errors = new List<string>();
            User userFromDb = userContainer.Login(user, out errors);
            if (userFromDb != null)
            {
                JwtHelper jwtGenerator = new JwtHelper();
                string token = jwtGenerator.Generate(userFromDb.UserID);
                Response.Cookies.Append("jwt", token, new CookieOptions
                {
                    HttpOnly = true,
                    SameSite = SameSiteMode.None,
                    Secure = true
                });
                
                return Ok("succes");
            }
            else
            {
                return BadRequest(errors);
            }
        }

        [HttpPost]
        [Route("/Credentials/Logout")]
        public ActionResult Logout()
        {
            Response.Cookies.Delete("jwt", new CookieOptions
            {
                HttpOnly = true,
                SameSite = SameSiteMode.None,
                Secure = true
            });
            return Ok("succes");
        }

        [HttpPatch]
        [Route("/Credentials/{id}")]
        public ActionResult Account(int id, string email, string userName, string password)
        {
            UserContainer userContainer = new UserContainer(new UserDAL());
            User user = new User(id, userName, email, password);
            List<string> errors = new List<string>();
            if (userContainer.UpdateUser(user))
            {
                return Ok("Succesfully updated");
            }
            else
            {
                return BadRequest(errors);
            }
        }

        [HttpDelete]
        [Route("/Credentials/{id}")]
        public ActionResult Account(int id)
        {
            UserContainer userContainer = new UserContainer(new UserDAL());
            if (userContainer.DeleteUser(id))
            {
                return Ok("Succesfully deleted");
            }
            else
            {
                return BadRequest("User not found");
            }
        }
    }
}

