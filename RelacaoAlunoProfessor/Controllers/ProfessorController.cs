using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RelacaoAlunoProfessor.Entidades;
using System.Linq;

namespace RelacaoAlunoProfessor.Controllers
{
    public class ProfessorController : Controller
    {
        private readonly Contexto db;
        public ProfessorController(Contexto contexto)
        {
            db = contexto;
        }
        // GET: ProfessorController
        public ActionResult Index(string pesquisaprof, string TipoPesquisaProf)
        {
            if (string.IsNullOrEmpty(pesquisaprof))
            {
                return View(db.PROFESSOR.ToList());
            }
            else if (TipoPesquisaProf == "Todos")
            {
                return View(db.PROFESSOR.Where(x => x.Nome.Contains(pesquisaprof) || x.CPF.Contains(pesquisaprof)));
            } else if (TipoPesquisaProf == "Nome"){
                return View(db.PROFESSOR.Where(x => x.Nome.Contains(pesquisaprof)));
            }else if(TipoPesquisaProf == "CPF")
            {
                return View(db.PROFESSOR.Where(x => x.CPF.Contains(pesquisaprof)));
            }
            else
            {
                return View(db.PROFESSOR.ToList());
            }
           
        }

        // GET: ProfessorController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProfessorController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProfessorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Professor collection)
        {
            try
            {
                db.PROFESSOR.Add(collection);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProfessorController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(db.PROFESSOR.Where(x=>x.ID == id).FirstOrDefault());
        }

        // POST: ProfessorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Professor collection)
        {
            try
            {
                db.PROFESSOR.Update(collection);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProfessorController/Delete/5
        public ActionResult Delete(int id)
        {
            db.PROFESSOR.Remove(db.PROFESSOR.Where(x => x.ID == id).FirstOrDefault());
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
