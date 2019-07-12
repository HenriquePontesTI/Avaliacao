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
    public class MateriaController : Controller
    {
        // GET: Materia
        private static Materia materia = new Materia();
        public static PeriodoAcademicoModel _periodoAcademicos = new PeriodoAcademicoModel();
        public ActionResult Index()
        {
            return View(materia.listaMaterias);
        }

        public ActionResult AdicionaMateria()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdicionaMateria(MateriaModel _MateriaModel)
        {
            materia.CriaMateria(_MateriaModel);
            TempData["ListaMaterias"] = materia.listaMaterias;
            return View();
            
        }

        public ActionResult AdicionaPeriodoAcademico()
        {
            return RedirectToAction("AdicionaPeriodoAcademico", "PeriodoAcademico");
        }

        public ActionResult EditaMateria(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MateriaModel materiaAtt = materia.listaMaterias.Where(x => x.NumeroMateria == id).FirstOrDefault();
            if (materiaAtt == null)
            {
                return HttpNotFound();
            }
            return View(materiaAtt);
        }
        [HttpPost]
        public ActionResult EditaMateria(MateriaModel model)
        {
            if (ModelState.IsValid)
            {
                var materiaAtt = materia.listaMaterias.Where(x => x.NumeroMateria == model.NumeroMateria).FirstOrDefault();
                if (materiaAtt == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                materiaAtt.NomeMateria = model.NomeMateria;
                materiaAtt.NumeroMateria = model.NumeroMateria;

                return RedirectToAction("Index");
            }
            return View(model);
        }

        public ViewResult DeletaMateria(int id)
        {
            return View(materia.GetMateria(id));

        }

        [HttpPost]
        public RedirectToRouteResult DeletaMateria(int id, FormCollection collection)
        {
            materia.DeletarMateria(id);
            return RedirectToAction("Index");
        }
    }
}
