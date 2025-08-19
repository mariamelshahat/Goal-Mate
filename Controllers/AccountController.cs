using Goal_Mate.Models;
using Goal_Mate.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Goal_Mate.Controllers
{
    public class AccountController : Controller
    {
        //Inject.
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController ( SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager )
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }
        /// <summary>
        /// Displays the registration page for creating a new user account.
        /// </summary>
        /// <returns>The registration view.</returns>
        
        [HttpGet]
        public async Task<IActionResult> Register ()
        {
            return View ();
        }

        /// <summary>
        /// Handles user registration by creating a new account.
        /// </summary>
        /// <param name="user">
        /// The registration model containing <c>UserName</c>, <c>Email</c>, and <c>Password</c>.
        /// </param>
        /// <returns>
        /// If registration succeeds, the new user is signed in and redirected to the <c>Index</c> action of the <c>Home</c> controller.  
        /// If registration fails, validation errors are added to the model state and the registration view is returned.
        /// </returns>
        
        [HttpPost]
        public async Task<IActionResult> Register ( RegisterUser user )
        {
            //Create Account.
            ApplicationUser usermodel = new ApplicationUser ();
            usermodel.UserName = user.UserName;
            usermodel.Email = user.Email;
            usermodel.PasswordHash = user.Password;

            IdentityResult result = await _userManager.CreateAsync ( usermodel, user.Password );
            if (result.Succeeded == true)
            {
                await _signInManager.SignInAsync ( usermodel, isPersistent: true );
                return RedirectToAction ( "Index", "Home" );
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError ( "", error.Description );
                }
            }
            return View ();

        }

        /// <summary>
        /// Displays the login page to the user.
        /// </summary>
        /// <returns>The login view.</returns>

        [HttpGet]
        public async Task<IActionResult> Login ()
        {
            return View ();
        }

        /// <summary>
        /// Handles the login process for a user.
        /// </summary>
        /// <param name="user">
        /// The login model containing <c>UserName</c>, <c>Password</c>, and <c>RememberMe</c>.
        /// </param>
        /// <returns>
        /// Returns the login view.  
        /// If the credentials are correct, the user will be signed in;  
        /// otherwise, an error message is added to the model state.
        /// </returns>
        /// 

        [HttpPost]
        public async Task<IActionResult> Login ( LoginUser user )
        {
            ApplicationUser usermodel = await _userManager.FindByNameAsync ( user.UserName );
            if (usermodel != null)
            {
                bool found = await _userManager.CheckPasswordAsync ( usermodel, user.Password );
                if (found)
                {
                    await _signInManager.SignInAsync ( usermodel, user.RememberMe );
                }
                else
                {
                    ModelState.AddModelError ( "", "Password is not correct" );
                }
            }
            else
            {
                ModelState.AddModelError ( "", "User is not found" );
            }
            return View ();
        }

        /// <summary>
        /// Logs out the currently signed-in user and ends the authentication session.
        /// </summary>
        /// <returns>
        /// Redirects the user to the <c>Index</c> action of the <c>Home</c> controller after logout.
        /// </returns>
        
        [HttpGet]
        public async Task<IActionResult> Logout ()
        {
            await _signInManager.SignOutAsync ();
            return RedirectToAction ("Index","Home");
        }
    }
}
