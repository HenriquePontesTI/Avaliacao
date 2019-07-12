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
    public class TurmaController : Controller
    {
        // GET: Turma
        private static Turma turma = new Turma();
        public ActionResult Index()
        {
            return View(turma.listaTurmas);
        }

        public ActionResult AdicionaTurma()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdicionaTurma(TurmaModel _TurmaModel)
        {
            turma.CriaTurma(_TurmaModel);
            return RedirectToAction("Index");
        }

        public ActionResult EditaTurma(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TurmaModel turmaAtt = turma.listaTurmas.Where(x=>x.NumeroTurma == id).FirstOrDefault();
            if (turmaAtt == null)
            {
                return HttpNotFound();
            }
            return View(turmaAtt);
        }
        [HttpPost]
        public ActionResult EditaTurma(TurmaModel model)
        {
            if (ModelState.IsValid)
            {
                var turmaAtt = turma.listaTurmas.Where(x=>x.NumeroTurma == model.NumeroTurma).FirstOrDefault();
                if (turmaAtt == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                turmaAtt.NomeTurma = model.NomeTurma;
                turmaAtt.NumeroTurma = model.NumeroTurma;

                return RedirectToAction("Index");
            }
            return View(model);
        }


        public ViewResult DeletaTurma(int id)
        {
            return View(turma.GetTurma(id));

        }

        [HttpPost]
        public RedirectToRouteResult DeletaTurma(int id, FormCollection collection)
        {
            turma.DeletarTurma(id);
            return RedirectToAction("Index");
        }
    }
}
