using Interface.DTO;
using Interface.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Stubs
{
    public class UserDalStub : IUserContainer
    {
        public List<UserDTO> UserDTOs { get; set; } = new List<UserDTO>()
        {
            new UserDTO(){ UserID = 1, Username = "yassir", Email = "yassirhabek@hotmail.com"},
            new UserDTO(){ UserID = 2, Username = "xyz456", Email = "Test321@hotmail.com", Password = "d969a0ba0fbbac959f09720dd7fb41bbd2692f409434d89db418a845d2088208"},
            new UserDTO(){ UserID = 34, Username = "abc123", Email = "ddddd@hotmail.com" }
        };

        public bool checkIfEmailExists(string email)
        {
            return UserDTOs.Where(x => x.Email == email).Any();
        }

        public UserDTO Login(UserDTO userDTO)
        {
            if (!UserDTOs.Where(x => x.Username == userDTO.Username).Any())
                return null;

            if (!UserDTOs.Where(x => x.Password == userDTO.Password).Any())
                return null;

            return UserDTOs.Where(x => x.Username == userDTO.Username).FirstOrDefault();
        }

        public bool Register(UserDTO userDTO)
        {
            UserDTOs.Add(userDTO);
            return true;
        }

        public UserDTO GetSingleUser(int id)
        {
            return UserDTOs.SingleOrDefault(x => x.UserID == id);
        }

        public bool UpdateUser(UserDTO userDTO)
        {
            if(UserDTOs.Remove(UserDTOs.SingleOrDefault(x => x.UserID == userDTO.UserID)))
            {
                UserDTOs.Add(userDTO);
                return true;
            }
            return false;
        }

        public bool DeleteUser(int id)
        {
            if (UserDTOs.Remove(UserDTOs.SingleOrDefault(x => x.UserID == id)))
                return true;
            return false;
        }
    }
}