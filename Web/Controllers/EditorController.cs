using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using VerotMorin.PreciousGames.BusinessLayer.Managers;
using VerotMorin.PreciousGames.ModelLayer.Entities;
using VerotMorin.PreciousGames.Web.Models.EditorModels;

namespace VerotMorin.PreciousGames.Web.Controllers
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
        public ActionResult Create(EditorViewModel editorViewModel)
        {
            if (!ModelState.IsValid)
                return View(editorViewModel);

            try
            {
                BusinessManager.Instance.AddEditor(new Editor()
                {
                    Name = editorViewModel.Name,
                });
                BusinessManager.Instance.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View(editorViewModel);
            }
        }

        // GET: Editor/Edit/5
        public ActionResult Edit(int id)
        {
            Editor editor = BusinessManager.Instance.GetEditorById(id);
            return View(new EditorViewModel(editor));
        }

        // POST: Editor/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, EditorViewModel editorViewModel)
        {
            if (!ModelState.IsValid)
                return View(editorViewModel);

            Editor editor = BusinessManager.Instance.GetEditorById(id);

            try
            {
                editor.Name = editorViewModel.Name;
                BusinessManager.Instance.UpdateEditor(editor);
                BusinessManager.Instance.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View(editorViewModel);
            }
        }

        // GET: Editor/Delete/5
        public ActionResult Delete(int id)
        {
            Editor editor = BusinessManager.Instance.GetEditorById(id);
            return View(new EditorViewModel(editor));
        }

        // POST: Editor/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, EditorViewModel editorViewModel)
        {
            if (!ModelState.IsValid)
                return View(editorViewModel);

            try
            {
                BusinessManager.Instance.DeleteEditor(id);
                BusinessManager.Instance.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(editorViewModel);
            }
        }
    }
}
