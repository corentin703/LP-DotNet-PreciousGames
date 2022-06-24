using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VerotMorin.PreciousGames.BusinessLayer.Managers;
using VerotMorin.PreciousGames.ModelLayer.Entities;
using VerotMorin.PreciousGames.Web.Models.KindModels;

namespace VerotMorin.PreciousGames.Web.Controllers
{
    public class KindController : Controller
    {
        // GET: Kind
        public ActionResult Index()
        {
            IEnumerable<Kind> kinds = BusinessManager.Instance.GetAllKindsOrderedByName();
            IEnumerable<KindViewModel> kindViewModels = kinds.Select(kind => new KindViewModel(kind));

            return View(new IndexViewModel()
            {
                Kinds = kindViewModels,
                KindCount= BusinessManager.Instance.CountKinds(),
            });
        }

        // GET: Kind/Details/5
        public ActionResult Details(int id)
        {
            Kind kind = BusinessManager.Instance.GetKindById(id);
            if (kind == null) 
                throw new HttpException(404, "Genre introuvable");

            return View(new KindViewModel(kind));
        }

        // GET: Kind/Create
        public ActionResult Create()
        {
            return View(new KindViewModel());
        }

        // POST: Kind/Create
        [HttpPost]
        public ActionResult Create(KindViewModel kindViewModel)
        {
            if (!ModelState.IsValid)
                return View(kindViewModel);

            try
            {
                BusinessManager.Instance.AddKind(new Kind()
                {
                    Name = kindViewModel.Name,
                });
                BusinessManager.Instance.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View(kindViewModel);
            }
        }

        // GET: Kind/Edit/5
        public ActionResult Edit(int id)
        {
            Kind kind = BusinessManager.Instance.GetKindById(id);
            if (kind == null) 
                throw new HttpException(404, "Genre introuvable");

            return View(new KindViewModel(kind));
        }

        // POST: Kind/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, KindViewModel kindViewModel)
        {
            if (!ModelState.IsValid)
                return View(kindViewModel);

            Kind kind = BusinessManager.Instance.GetKindById(id);
            if (kind == null) 
                throw new HttpException(404, "Genre introuvable");

            try
            {
                kind.Name = kindViewModel.Name;
                BusinessManager.Instance.UpdateKind(kind);
                BusinessManager.Instance.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View(kindViewModel);
            }
        }

        // GET: Kind/Delete/5
        public ActionResult Delete(int id)
        {
            Kind kind = BusinessManager.Instance.GetKindById(id);
            if (kind == null) 
                throw new HttpException(404, "Genre introuvable");

            return View(new KindViewModel(kind));
        }

        // POST: Kind/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, KindViewModel kindViewModel)
        {
            Kind kind = BusinessManager.Instance.GetKindById(id);
            if (kind == null) 
                throw new HttpException(404, "Genre introuvable");

            if (!ModelState.IsValid)
                return View(kindViewModel);

            try
            {
                BusinessManager.Instance.DeleteKind(id);
                BusinessManager.Instance.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
