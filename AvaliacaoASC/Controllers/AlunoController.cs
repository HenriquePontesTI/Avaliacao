using ASC.Dominio;
using AvaliacaoASC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace AvaliacaoASC.Controllers
{
    public class AlunoController : Controller
    {
        // GET: Aluno
        private static Aluno aluno = new Aluno();
        public ActionResult Index()
        {
            return View(aluno.listaAlunos);
        }

        public ActionResult AdicionaAluno()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdicionaAluno(AlunoModel _AlunoModel)
        {
            aluno.CriaAluno(_AlunoModel);
            return RedirectToAction("Index");
        }

        public ActionResult EditaAluno(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AlunoModel alunoAtt = aluno.listaAlunos.Where(x => x.Matricula == id).FirstOrDefault();
            if (alunoAtt == null)
            {
                return HttpNotFound();
            }
            return View(alunoAtt);
        }
        [HttpPost]
        public ActionResult EditaAluno(AlunoModel model)
        {
            if (ModelState.IsValid)
            {
                var alunoAtt = aluno.listaAlunos.Where(x => x.Matricula == model.Matricula).FirstOrDefault();
                if (alunoAtt == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                alunoAtt.Matricula = model.Matricula;
                alunoAtt.Nome = model.Nome;

                return RedirectToAction("Index");
            }
            return View(model);
        }

        public ViewResult DeletaAluno(int id)
        {
            return View(aluno.GetAluno(id));

        }

        [HttpPost]
        public RedirectToRouteResult DeletaAluno(int id, FormCollection collection)
        {
            aluno.DeletarAluno(id);
            return RedirectToAction("Index");
        }
    }
}
