using Interface.DTO;
using Logic.Containers;
using Logic.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Stubs;

namespace Test.UnitTest
{
    [TestClass]
    public class UserTests
    {
        [TestMethod]
        public void CreateUserSuccesful()
        {
            //Arrange
            string username = "test123";
            string email = "test@hotmail.com";
            string password = "Test1234";
            string verpass = "Test1234";
            string hashedPass = "ad92ffcdd50c43a948946af548a752978fcbe65fc1c2fb2d25d649e9494f7241";
            UserDalStub stub = new UserDalStub();
            UserContainer userContainer = new UserContainer(stub);
            User user = new User(username, email, password, verpass);
            List<string> errors = new List<string>();

            //Act
            bool state = userContainer.Register(user, out errors);

            //Assert
            Assert.AreEqual(true, state);
            Assert.AreEqual(username, stub.UserDTOs[stub.UserDTOs.Count - 1].Username);
            Assert.AreEqual(email, stub.UserDTOs[stub.UserDTOs.Count - 1].Email);
            Assert.AreEqual(hashedPass, stub.UserDTOs[stub.UserDTOs.Count - 1].Password);
        }

        [TestMethod]
        public void CreateUserNullEmail()
        {
            //Arrange
            string username = "test123";
            string email = "";
            string password = "Test1234";
            string verpass = "Test1234";
            string hashedPass = "767b4972babfe7918b1441ccd807b77d81c1429462c12e8baccc63f0e344801e";
            UserDalStub stub = new UserDalStub();
            UserContainer userContainer = new UserContainer(stub);
            User user = new User(username, email, password, verpass);
            List<string> errors = new List<string>();

            //Act
            bool state = userContainer.Register(user, out errors);

            //Assert
            Assert.AreEqual(false, state);
            Assert.AreEqual("email is required", errors[0]);
        }

        [TestMethod]
        public void CreateUserNullUsername()
        {
            //Arrange
            string username = "";
            string email = "test@hotmail.com";
            string password = "Test1234";
            string verpass = "Test1234";
            string hashedPass = "767b4972babfe7918b1441ccd807b77d81c1429462c12e8baccc63f0e344801e";
            UserDalStub stub = new UserDalStub();
            UserContainer userContainer = new UserContainer(stub);
            User user = new User(username, email, password, verpass);
            List<string> errors = new List<string>();

            //Act
            bool state = userContainer.Register(user, out errors);

            //Assert
            Assert.AreEqual(false, state);
            Assert.AreEqual("username is required", errors[0]);
        }

        [TestMethod]
        public void CreateUserNullPassword()
        {
            //Arrange
            string username = "test123";
            string email = "test@hotmail.com";
            string password = "";
            string verpass = "Test1234";
            string hashedPass = "767b4972babfe7918b1441ccd807b77d81c1429462c12e8baccc63f0e344801e";
            UserDalStub stub = new UserDalStub();
            UserContainer userContainer = new UserContainer(stub);
            User user = new User(username, email, password, verpass);
            List<string> errors = new List<string>();

            //Act
            bool state = userContainer.Register(user, out errors);

            //Assert
            Assert.AreEqual(false, state);
            Assert.AreEqual("password is required", errors[0]);
        }

        [TestMethod]
        public void CreateUserNullVerifiedPassword()
        {
            //Arrange
            string username = "test123";
            string email = "test@hotmail.com";
            string password = "Test1234";
            string verpass = "";
            string hashedPass = "767b4972babfe7918b1441ccd807b77d81c1429462c12e8baccc63f0e344801e";
            UserDalStub stub = new UserDalStub();
            UserContainer userContainer = new UserContainer(stub);
            User user = new User(username, email, password, verpass);
            List<string> errors = new List<string>();

            //Act
            bool state = userContainer.Register(user, out errors);

            //Assert
            Assert.AreEqual(false, state);
            Assert.AreEqual("password confirmation is required", errors[0]);
        }

        [TestMethod]
        public void CreateUserWrongEmailFormat()
        {
            //Arrange
            string username = "test123";
            string email = "test";
            string password = "Test1234";
            string verpass = "Test1234";
            string hashedPass = "767b4972babfe7918b1441ccd807b77d81c1429462c12e8baccc63f0e344801e";
            UserDalStub stub = new UserDalStub();
            UserContainer userContainer = new UserContainer(stub);
            User user = new User(username, email, password, verpass);
            List<string> errors = new List<string>();

            //Act
            bool state = userContainer.Register(user, out errors);

            //Assert
            Assert.AreEqual(false, state);
            Assert.AreEqual("email must be valid", errors[0]);
        }

        [TestMethod]
        public void CreateUserExistingEmail()
        {
            //Arrange
            string username = "test123";
            string email = "yassirhabek@hotmail.com";
            string password = "Test1234";
            string verpass = "Test1234";
            string hashedPass = "767b4972babfe7918b1441ccd807b77d81c1429462c12e8baccc63f0e344801e";
            UserDalStub stub = new UserDalStub();
            UserContainer userContainer = new UserContainer(stub);
            User user = new User(username, email, password, verpass);
            List<string> errors = new List<string>();

            //Act
            bool state = userContainer.Register(user, out errors);

            //Assert
            Assert.AreEqual(false, state);
            Assert.AreEqual("account already linked to this email", errors[0]);
        }

        [TestMethod]
        public void CreateUserShortPasswordFormat()
        {
            //Arrange
            string username = "test123";
            string email = "test@hotmail.com";
            string password = "Test1";
            string verpass = "Test1";
            string hashedPass = "767b4972babfe7918b1441ccd807b77d81c1429462c12e8baccc63f0e344801e";
            UserDalStub stub = new UserDalStub();
            UserContainer userContainer = new UserContainer(stub);
            User user = new User(username, email, password, verpass);
            List<string> errors = new List<string>();

            //Act
            bool state = userContainer.Register(user, out errors);

            //Assert
            Assert.AreEqual(false, state);
            Assert.AreEqual("password must be at least 8 characters", errors[0]);
        }

        [TestMethod]
        public void CreateUserNoCapPasswordFormat()
        {
            //Arrange
            string username = "test123";
            string email = "test@hotmail.com";
            string password = "test1234";
            string verpass = "test1234";
            string hashedPass = "767b4972babfe7918b1441ccd807b77d81c1429462c12e8baccc63f0e344801e";
            UserDalStub stub = new UserDalStub();
            UserContainer userContainer = new UserContainer(stub);
            User user = new User(username, email, password, verpass);
            List<string> errors = new List<string>();

            //Act
            bool state = userContainer.Register(user, out errors);

            //Assert
            Assert.AreEqual(false, state);
            Assert.AreEqual("password must contain at least 1 uppercase letter", errors[0]);
        }

        [TestMethod]
        public void CreateUserNoLowerPasswordFormat()
        {
            //Arrange
            string username = "test123";
            string email = "test@hotmail.com";
            string password = "TEST1234";
            string verpass = "TEST1234";
            string hashedPass = "767b4972babfe7918b1441ccd807b77d81c1429462c12e8baccc63f0e344801e";
            UserDalStub stub = new UserDalStub();
            UserContainer userContainer = new UserContainer(stub);
            User user = new User(username, email, password, verpass);
            List<string> errors = new List<string>();

            //Act
            bool state = userContainer.Register(user, out errors);

            //Assert
            Assert.AreEqual(false, state);
            Assert.AreEqual("password must contain at least 1 lowercase letter", errors[0]);
        }

        [TestMethod]
        public void CreateUserNoDigitPasswordFormat()
        {
            //Arrange
            string username = "test123";
            string email = "test@hotmail.com";
            string password = "Testtest";
            string verpass = "Testtest";
            string hashedPass = "767b4972babfe7918b1441ccd807b77d81c1429462c12e8baccc63f0e344801e";
            UserDalStub stub = new UserDalStub();
            UserContainer userContainer = new UserContainer(stub);
            User user = new User(username, email, password, verpass);
            List<string> errors = new List<string>();

            //Act
            bool state = userContainer.Register(user, out errors);

            //Assert
            Assert.AreEqual(false, state);
            Assert.AreEqual("password must contain at least 1 symbol/digit", errors[0]);
        }

        [TestMethod]
        public void CreateUserPasswordAndVerPasswordDontMatch()
        {
            //Arrange
            string username = "test123";
            string email = "test@hotmail.com";
            string password = "Test1234";
            string verpass = "Test5678";
            string hashedPass = "767b4972babfe7918b1441ccd807b77d81c1429462c12e8baccc63f0e344801e";
            UserDalStub stub = new UserDalStub();
            UserContainer userContainer = new UserContainer(stub);
            User user = new User(username, email, password, verpass);
            List<string> errors = new List<string>();

            //Act
            bool state = userContainer.Register(user, out errors);

            //Assert
            Assert.AreEqual(false, state);
            Assert.AreEqual("two passwords must match", errors[0]);
        }

        [TestMethod]
        public void SuccesfulLogin()
        {
            //Arrange
            int id = 2;
            string username = "xyz456";
            string password = "Tester1421";
            string hashedPass = "d969a0ba0fbbac959f09720dd7fb41bbd2692f409434d89db418a845d2088208";
            UserDalStub stub = new UserDalStub();
            UserContainer userContainer = new UserContainer(stub);
            User user = new User(username, password);
            List<string> errors = new List<string>();

            //Act
            User userFromDb = userContainer.Login(user, out errors);

            //Assert
            Assert.AreEqual(username, userFromDb.Username);
            Assert.AreEqual(hashedPass, userFromDb.Password);
            Assert.AreEqual(id, userFromDb.UserID);
        }

        [TestMethod]
        public void LoginNullUsername()
        {
            //Arrange
            string username = "";
            string password = "Tester1421";
            UserDalStub stub = new UserDalStub();
            UserContainer userContainer = new UserContainer(stub);
            User user = new User(username, password);
            List<string> errors = new List<string>();

            //Act
            User userFromDb = userContainer.Login(user, out errors);

            //Assert
            Assert.AreEqual(null, userFromDb);
            Assert.AreEqual("username is required", errors[0]);
        }

        [TestMethod]
        public void LoginNullPassword()
        {
            //Arrange
            string username = "xyz456";
            string email = "Test321@hotmail.com";
            string password = "";
            UserDalStub stub = new UserDalStub();
            UserContainer userContainer = new UserContainer(stub);
            User user = new User(username, password);
            List<string> errors = new List<string>();

            //Act
            User userFromDb = userContainer.Login(user, out errors);

            //Assert
            Assert.AreEqual(null, userFromDb);
            Assert.AreEqual("password is required", errors[0]);
        }

        [TestMethod]
        public void UnsuccesfulLogin()
        {
            //Arrange
            string username = "xyz456";
            string email = "Test321@hotmail.com";
            string password = "Tester133";
            UserDalStub stub = new UserDalStub();
            UserContainer userContainer = new UserContainer(stub);
            User user = new User(username, password);
            List<string> errors = new List<string>();

            //Act
            User userFromDb = userContainer.Login(user, out errors);

            //Assert
            Assert.AreEqual(null, userFromDb);
            Assert.AreEqual("wrong email/password", errors[0]);
        }

        [TestMethod]
        public void GetSingleUser()
        {
            //Arrange
            string username = "xyz456";
            string email = "Test321@hotmail.com";
            int userId = 2;
            UserDalStub stub = new UserDalStub();
            UserContainer userContainer = new UserContainer(stub);

            //Act
            User fullUser = userContainer.GetSingleUser(userId);

            //Assert
            Assert.AreEqual(email, fullUser.Email);
            Assert.AreEqual(username, fullUser.Username);
            Assert.AreEqual(userId, fullUser.UserID);
        }

        [TestMethod]
        public void ConstructorUserLogin()
        {
            //Arrange
            string username = "TestUsername";
            string password = "Test1234";
            //Act
            User user = new User(username, password);

            //Assert
            Assert.AreEqual(username, user.Username);
            Assert.AreEqual(password, user.Password);
        }

        [TestMethod]
        public void ConstructorUserRegister()
        {
            //Arrange
            string username = "test123";
            string email = "Test123@hotmail.com";
            string password = "Test1234";
            string verPass = "Test1234";
            //Act
            User user = new User(username, email, password, verPass);

            //Assert
            Assert.AreEqual(email, user.Email);
            Assert.AreEqual(username, user.Username);
            Assert.AreEqual(password, user.Password);
            Assert.AreEqual(verPass, user.VerPass);
        }

        [TestMethod]
        public void ConstructorUserFull()
        {
            //Arrange
            string username = "test123";
            string email = "Test123@hotmail.com";
            string password = "Test1234";
            int uid = 34;
            //Act
            User user = new User(uid, username, email, password);

            //Assert
            Assert.AreEqual(uid, user.UserID);
            Assert.AreEqual(email, user.Email);
            Assert.AreEqual(username, user.Username);
            Assert.AreEqual(password, user.Password);
        }

        [TestMethod]
        public void ConstructorUserDTO()
        {
            //Arrange
            string username = "test123";
            string email = "Test123@hotmail.com";
            string password = "Test1234";
            string verPass = "Test1234";
            int uid = 34;
            UserDTO userDTO = new UserDTO()
            {
                UserID = uid,
                Email = email,
                Username = username,
                Password = password,
                VerPass = verPass,
            };

            //Act
            User user = new User(userDTO);

            //Assert
            Assert.AreEqual(uid, user.UserID);
            Assert.AreEqual(username, user.Username);
            Assert.AreEqual(email, user.Email);
            Assert.AreEqual(password, user.Password);
            Assert.AreEqual(verPass, user.VerPass);
        }

        [TestMethod]
        public void UpdateUser()
        {
            //Arrange 
            string username = "test123";
            string email = "Test444@hotmail.com";
            int uid = 34;
            User user = new User()
            {
                Username = username,
                Email = email,
                UserID = uid
            };
            UserDalStub stub = new UserDalStub();
            UserContainer userContainer = new UserContainer(stub);
            
            //Act
            bool state = userContainer.UpdateUser(user);

            //Assert
            Assert.AreEqual(true, state);
            Assert.AreEqual(username, stub.UserDTOs[stub.UserDTOs.Count - 1].Username);
            Assert.AreEqual(email, stub.UserDTOs[stub.UserDTOs.Count - 1].Email);
            Assert.AreEqual(username, stub.UserDTOs[stub.UserDTOs.Count - 1].Username);

        }

        [TestMethod]
        public void UpdateUserFailed()
        {
            //Arrange 
            string username = "test123";
            string email = "Test444@hotmail.com";
            int uid = 32;
            User user = new User()
            {
                Username = username,
                Email = email,
                UserID = uid
            };
            UserDalStub stub = new UserDalStub();
            UserContainer userContainer = new UserContainer(stub);

            //Act
            bool state = userContainer.UpdateUser(user);

            //Assert
            Assert.AreEqual(false, state);
        }

        [TestMethod]
        public void DeleteUser()
        {
            //Arrange 
            int uid = 34;
            UserDalStub stub = new UserDalStub();
            UserContainer userContainer = new UserContainer(stub);

            //Act
            bool state = userContainer.DeleteUser(uid);

            //Assert
            Assert.AreEqual(true, state);
        }

        [TestMethod]
        public void DeleteUserFailed()
        {
            //Arrange
            int uid = 32;
            UserDalStub stub = new UserDalStub();
            UserContainer userContainer = new UserContainer(stub);

            //Act
            bool state = userContainer.DeleteUser(uid);

            //Assert
            Assert.AreEqual(false, state);
        }
    }
}