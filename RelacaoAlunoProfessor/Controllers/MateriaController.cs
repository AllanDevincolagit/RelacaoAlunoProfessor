using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RelacaoAlunoProfessor.Entidades;
using System.Linq;

namespace RelacaoAlunoProfessor.Controllers
{
    public class MateriaController : Controller
    {
        private readonly Contexto db;
        public MateriaController(Contexto contexto)
        {
            db = contexto;
        }
        // GET: MateriaController
        public ActionResult Index(string pesquisamat, string TipoPesquisaMat)
        {
            if (string.IsNullOrEmpty(pesquisamat))
            {
                return View(db.MATERIA.ToList());
            }
            else if(TipoPesquisaMat == "Todos")
            {
                return View(db.MATERIA.Where(x=>x.Nome.Contains(pesquisamat) || x.Area.Contains(pesquisamat)));
            }else if(TipoPesquisaMat == "Nome")
            {
                return View(db.MATERIA.Where(x => x.Nome.Contains(pesquisamat)));
            }else if(TipoPesquisaMat == "Area")
            {
                return View(db.MATERIA.Where(x => x.Area.Contains(pesquisamat)));
            }
            else
            {
                return View(db.MATERIA.ToList());
            }
            
        }

        // GET: MateriaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MateriaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MateriaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Materia collection)
        {
            try
            {
                db.MATERIA.Add(collection);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MateriaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(db.MATERIA.Where(x=>x.ID == id).FirstOrDefault());
        }

        // POST: MateriaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Materia collection)
        {
            try
            {
                db.MATERIA.Update(collection);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MateriaController/Delete/5
        public ActionResult Delete(int id)
        {
            db.MATERIA.Remove(db.MATERIA.Where(x => x.ID == id).FirstOrDefault());
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
