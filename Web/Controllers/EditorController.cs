using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using PreciousGames.Verot.Morin.BusinessLayer.Managers;
using PreciousGames.Verot.Morin.ModelLayer.Entities;
using Web.Models.EditorModels;

namespace Web.Controllers
{
    public class EditorController : Controller
    {
        // GET: Editor
        public ActionResult Index()
        {
            IEnumerable<Editor> editors = BusinessManager.Instance.GetAllEditors();
            IEnumerable<EditorViewModel> editorViewModels = editors.Select(editor => new EditorViewModel(editor));

            return View(new IndexViewModel()
            {
                Editors = editorViewModels,
                EditorCount = BusinessManager.Instance.CountEditors(),
            });
        }

        // GET: Editor/Details/5
        public ActionResult Details(int id)
        {
            return View(new EditorViewModel(
                BusinessManager.Instance.GetEditorById(id)
            ));
        }

        // GET: Editor/Create
        public ActionResult Create()
        {
            return View(new EditorViewModel());
        }

        // POST: Editor/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View(new EditorViewModel());
            }
        }

        // GET: Editor/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Editor/Edit/5
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

        // GET: Editor/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Editor/Delete/5
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
