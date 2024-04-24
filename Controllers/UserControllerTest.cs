using CRUD_application_2.Controllers;
using CRUD_application_2.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;


namespace CRUD_application_2.Tests.Controllers
{
    [TestClass]
    public class UserControllerTest
    {
        [TestMethod]
        public void TestCreatePostAction()
        {
            // Arrange
            var controller = new UserController();
            var user = new User { Id = 1, Name = "New User", Email = "newuser@example.com" };

            // Act
            var result = controller.Create(user) as RedirectToRouteResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.RouteValues["action"]);

            // Assert that the user was added to the list
            var newUser = UserController.userlist.Find(u => u.Id == user.Id);
            Assert.IsNotNull(newUser);
            Assert.AreEqual(user.Name, newUser.Name);
            Assert.AreEqual(user.Email, newUser.Email);

            // Clean up
            UserController.userlist.Remove(newUser);
        }

        [TestMethod]
        public void TestIndexAction()
        {
            // Arrange
            var controller = new UserController();

            // Act
            var result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestDetailsAction()
        {
            // Arrange
            var controller = new UserController();
            var user = new User { Id = 1, Name = "Test User", Email = "test@example.com" };
            UserController.userlist.Add(user);

            // Act
            var result = controller.Details(1) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(user, result.Model);

            // Clean up
            UserController.userlist.Remove(user);
        }

        [TestMethod]
        public void TestEditGetAction()
        {
            // Arrange
            var controller = new UserController();
            var user = new User { Id = 1, Name = "Test User", Email = "test@example.com" };
            UserController.userlist.Add(user);

            // Act
            var result = controller.Edit(1) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(user, result.Model);

            // Clean up
            UserController.userlist.Remove(user);
        }

        [TestMethod]
        public void TestEditPostAction()
        {
            // Arrange
            var controller = new UserController();
            var user = new User { Id = 1, Name = "Test User", Email = "test@example.com" };
            UserController.userlist.Add(user);
            var updatedUser = new User { Id = 1, Name = "Updated User", Email = "updated@example.com" };

            // Act
            var result = controller.Edit(1, updatedUser) as RedirectToRouteResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.RouteValues["action"]);
            var savedUser = UserController.userlist.Find(u => u.Id == 1);
            Assert.AreEqual(updatedUser.Name, savedUser.Name);
            Assert.AreEqual(updatedUser.Email, savedUser.Email);

            // Clean up
            UserController.userlist.Remove(savedUser);
        }
    }
}
