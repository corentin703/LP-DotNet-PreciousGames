using System.Web.Mvc;

namespace VerotMorin.PreciousGames.Web.Controllers
{
    public class KindController : Controller
    {
        // GET: Kind
        public ActionResult Index()
        {
            return View();
        }

        // GET: Kind/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Kind/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Kind/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Kind/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Kind/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Kind/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Kind/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
