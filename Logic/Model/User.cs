using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Interface.DTO;
using Interface.Enum;
using System.Text.Json.Serialization;

namespace Logic.Model
{
    public class User
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        [JsonIgnore]
        public string Password { get; set; }
        [JsonIgnore]
        public string VerPass { get; set; }
        public DateTime CreatedDate { get; set; }

        public User()
        {

        }

        public User(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public User(string username, string email, string password, string verpass)
        {
            Username = username;
            Password = password;
            Email = email;
            VerPass = verpass;
            CreatedDate = DateTime.Now;
        }

        public User(int id, string username, string email, string password)
        {
            UserID = id;
            Username = username;
            Password = password;
            Email = email;
        }

        public User(UserDTO userDTO)
        {
            if (userDTO == null)
            {
                return;
            }
            UserID = userDTO.UserID;
            Username = userDTO.Username;
            Email = userDTO.Email;
            Password = userDTO.Password;
            VerPass = userDTO.VerPass;
            CreatedDate = userDTO.CreatedDate;
        }

        public UserDTO ToDTO()
        {
            UserDTO userDTO = new UserDTO();
            userDTO.UserID = UserID;
            userDTO.Username = Username;
            userDTO.Email = Email;
            userDTO.Password = Password;
            userDTO.VerPass = VerPass;
            userDTO.CreatedDate = CreatedDate;
            return userDTO;
        }
    }
}
