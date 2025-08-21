using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Goal_Mate.Controllers
{
    public class SubTaskController : Controller
    {
        // GET: SubTaskController
        public ActionResult Index ()
        {
            return View ();
        }

        // GET: SubTaskController/Details/5
        public ActionResult Details ( int id )
        {
            return View ();
        }

        // GET: SubTaskController/Create
        public ActionResult Create ()
        {
            return View ();
        }

        // POST: SubTaskController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create ( IFormCollection collection )
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

        // GET: SubTaskController/Edit/5
        public ActionResult Edit ( int id )
        {
            return View ();
        }

        // POST: SubTaskController/Edit/5
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

        // GET: SubTaskController/Delete/5
        public ActionResult Delete ( int id )
        {
            return View ();
        }

        // POST: SubTaskController/Delete/5
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
