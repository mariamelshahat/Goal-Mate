using Goal_Mate.Interface;
using Goal_Mate.Models;
using Goal_Mate.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Goal_Mate.Controllers
{
    [Authorize]
    public class TaskController : Controller
    {
        private readonly ITaskRepository _taskRepository;
        private readonly UserManager<ApplicationUser> _userManager;

        public TaskController ( ITaskRepository taskRepository, UserManager<ApplicationUser> userManager)
        {
            _taskRepository = taskRepository;
            _userManager = userManager;
        }

        // GET: TaskController
        public async Task<ActionResult> Index ()
        {
            var user = await _userManager.GetUserAsync ( User );
            if (user == null)
                return RedirectToAction ( "Login", "Account" );
            var tasks = await _taskRepository.GetAllAsync ( user.Id );
            return View (tasks);
        }

        // GET: TaskController/Details/5
        public async Task<ActionResult> Details ( int id )
        {
            var task = await _taskRepository.GetByIdAsync ( id );
            if (task != null)
            {
                return View ( task );
            }
            return View ();
        }

        // GET: TaskController/Create
        public ActionResult Create ()
        {
            return View ();
        }

        // POST: TaskController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create ( UserTask task )
        {
            try
            {
                return RedirectToAction ( nameof ( Index ) );
            }
            catch
            {
                return View ();
            }
        }

        // GET: TaskController/Edit/5
        public ActionResult Edit ( int id )
        {
            return View ();
        }

        // POST: TaskController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit ( int id, IFormCollection collection )
        {
            try
            {
                return RedirectToAction ( nameof ( Index ) );
            }
            catch
            {
                return View ();
            }
        }

        // GET: TaskController/Delete/5
        public ActionResult Delete ( int id )
        {
            return View ();
        }

        // POST: TaskController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete ( int id, IFormCollection collection )
        {
            try
            {
                return RedirectToAction ( nameof ( Index ) );
            }
            catch
            {
                return View ();
            }
        }
    }
}
