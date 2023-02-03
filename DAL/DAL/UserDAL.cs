using Interface.DTO;
using Interface.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DAL
{
    public class UserDAL : IUserContainer
    {
        public UserDTO Login(UserDTO userDTO)
        {
            using (var db = new SurroundDbContext())
            {
                var user = db.Users.FirstOrDefault(u => u.Username == userDTO.Username && u.Password == userDTO.Password);
                if (user != null)
                {
                    return user;
                }
                return null;
            }
        }
        public bool Register(UserDTO userDTO)
        {
            using (var db = new SurroundDbContext())
            {
                var user = db.Users.FirstOrDefault(u => u.Email == userDTO.Email);
                if (user == null)
                {
                    db.Users.Add(userDTO);
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        public bool checkIfEmailExists(string email)
        {
            using (var db = new SurroundDbContext())
            {
                var user = db.Users.FirstOrDefault(u => u.Email == email);
                if (user != null)
                {
                    return true;
                }
                return false;
            }
        }
        public bool UpdateUser(UserDTO user)
        {
            using (var context = new SurroundDbContext())
            {
                context.Users.Update(user);
                context.SaveChanges();
                return true;
            }
        }

        public UserDTO GetSingleUser(int id)
        {
            using (var db = new SurroundDbContext())
            {
                var user = db.Users.FirstOrDefault(u => u.UserID == id);
                if (user != null)
                {
                    return user;
                }
                return null;
            }
        }


        public bool DeleteUser(int id)
        {
            using (var context = new SurroundDbContext())
            {
                var user = context.Users.FirstOrDefault(u => u.UserID == id);
                if (user != null)
                {
                    context.Users.Remove(user);
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
        }
    }
}

#region Unnused
/*public List<UserDTO> GetAllUsers()
{
    using (var context = new SurroundDbContext())
    {
        return context.Users.ToList();
    }
}

public UserDTO GetUserOnUsername(string username, string password)
{
    using (var context = new SurroundDbContext())
    {
        return context.Users.FirstOrDefault(u => u.Username == username && u.Password == password);
    }
}

public UserDTO GetUserOnId(int id)
{
    using (var context = new SurroundDbContext())
    {
        return context.Users.FirstOrDefault(u => u.UserID == id);
    }
}

public void AddUser(UserDTO user)
{
    using (var context = new SurroundDbContext())
    {
        context.Users.Add(user);
        context.SaveChanges();
    }
}
#endregion
}
}
*/
#endregion