using Interface.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.Interface
{
    public interface IUserContainer
    {
        UserDTO Login(UserDTO userDTO);
        bool Register(UserDTO userDTO);
        bool checkIfEmailExists(string email);
        bool UpdateUser(UserDTO user);
        bool DeleteUser(int id);
        UserDTO GetSingleUser(int id);
    }
}
