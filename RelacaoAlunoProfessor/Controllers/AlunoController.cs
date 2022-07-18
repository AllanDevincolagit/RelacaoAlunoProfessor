using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RelacaoAlunoProfessor.Entidades;
using System.Linq;

namespace RelacaoAlunoProfessor.Controllers
{
    public class AlunoController : Controller
    {
        private readonly Contexto db;
        public AlunoController(Contexto contexto)
        {
            db = contexto;
        }
        // GET: AlunoController
        public ActionResult Index(string pesquisa, string TipoPesquisa)
        {
            if (string.IsNullOrEmpty(pesquisa))
            {
                return View(db.ALUNO.ToList());
            }
            else if(TipoPesquisa == "Todos")
            {
                return View(db.ALUNO.Where(x => x.Nome.Contains(pesquisa) || x.CPF.Contains(pesquisa)));

            }else if(TipoPesquisa == "Nome")
            {
                return View(db.ALUNO.Where(x => x.Nome.Contains(pesquisa)));
            }else if(TipoPesquisa == "CPF")
            {
                return View(db.ALUNO.Where(x => x.CPF.Contains(pesquisa)));
            }
            else
            {
                return View(db.ALUNO.ToList());
            }
        }

        // GET: AlunoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AlunoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AlunoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Aluno collection)
        {
            try
            {
                db.ALUNO.Add(collection);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AlunoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(db.ALUNO.Where(x => x.ID == id).FirstOrDefault());

        }

        // POST: AlunoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Aluno collection)
        {
            try { 


                db.ALUNO.Update(collection);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AlunoController/Delete/5
        public ActionResult Delete(int id)
        {
            db.ALUNO.Remove(db.ALUNO.Where(x => x.ID == id).FirstOrDefault());
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
