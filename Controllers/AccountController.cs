using Goal_Mate.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Goal_Mate.Controllers
{
    public class AccountController : Controller
    {
        //Inject.
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController ( SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager )
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Register ()
        {
                       return View ();
        }
        [HttpPost]
        public async Task<IActionResult> Register ( RegisterUser user)
        {
            //Create Account.
            IdentityUser usermodel = new IdentityUser ();
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
    }
}
