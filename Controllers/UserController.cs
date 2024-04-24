using CRUD_application_2.Models;    
using System.Linq;
using System.Web.Mvc;
 
namespace CRUD_application_2.Controllers
{
    public class UserController : Controller
    {
        public static System.Collections.Generic.List<User> userlist = new System.Collections.Generic.List<User>();
        // GET: User
        public ActionResult Index()
        {
            // This method is responsible for displaying the list of users.
            // It retrieves the list of users from the userlist and passes it to the Index view.
            return View(userlist);
        }
 
        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            // This method is responsible for displaying the details of a specific user with the specified ID.
            // It retrieves the user from the userlist based on the provided ID and passes it to the Details view.
            return View(userlist.FirstOrDefault(x => x.Id == id));
        }
 
        // GET: User/Create
        // GET: User/Create
        public ActionResult Create()
        {
            // This method simply returns the Create view, which should contain a form for creating a new user.
            return View();
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(User user)
        {
            // This method handles the form submission. The form data is automatically bound to the 'user' parameter.

            // First, check if the model state is valid. This checks if the submitted data satisfies all validation rules.
            if (ModelState.IsValid)
            {
                // If the model state is valid, add the new user to the userlist.
                userlist.Add(user);

                // Then, redirect to the Index action to display the updated list of users.
                return RedirectToAction("Index");
            }

            // If the model state is not valid, return the Create view again to display any validation errors.
            return View(user);
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            // Find the user in the list with the given id
            var user = userlist.FirstOrDefault(u => u.Id == id);

            // If the user doesn't exist, return a HttpNotFoundResult
            if (user == null)
            {
                return HttpNotFound();
            }

            // If the user exists, pass the user to the Edit view
            return View(user);
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, User user)
        {
            // This method handles the form submission. The form data is automatically bound to the 'user' parameter.

            // First, check if the model state is valid. This checks if the submitted data satisfies all validation rules.
            if (ModelState.IsValid)
            {
                // If the model state is valid, find the user in the list with the given id
                var existingUser = userlist.FirstOrDefault(u => u.Id == id);

                // If the user doesn't exist, return a HttpNotFoundResult
                if (existingUser == null)
                {
                    return HttpNotFound();
                }

                // If the user exists, update the user's details
                existingUser.Name = user.Name;
                existingUser.Email = user.Email;
                // ... update other properties as needed ...

                // Then, redirect to the Index action to display the updated list of users.
                return RedirectToAction("Index");
            }

            // If the model state is not valid, return the Edit view again to display any validation errors.
            return View(user);
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            // Find the user in the list with the given id
            var user = userlist.FirstOrDefault(u => u.Id == id);

            // If the user doesn't exist, return a HttpNotFoundResult
            if (user == null)
            {
                return HttpNotFound();
            }

            // If the user exists, pass the user to the Delete view
            return View(user);
        }
 
        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            // Find the user in the list with the given id
            var user = userlist.FirstOrDefault(u => u.Id == id);

            // If the user doesn't exist, return a HttpNotFoundResult
            if (user == null)
            {
                return HttpNotFound();
            }

            // If the user exists, remove the user from the list
            userlist.Remove(user);

            // Then, redirect to the Index action to display the updated list of users.
            return RedirectToAction("Index");
        }
    }
}
