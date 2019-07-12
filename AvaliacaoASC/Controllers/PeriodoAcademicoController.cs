using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASC.Dominio;
using AvaliacaoASC.Models;

namespace AvaliacaoASC.Controllers
{
    public class PeriodoAcademicoController : Controller
    {
        private static PeriodoAcademico periodoAcademico = new PeriodoAcademico();
        public ActionResult Index()
        {
            ViewBag.AlunosLista = periodoAcademico._periodoAcademicos.Alunos == null? 
                    new List<AlunoModel>() : 
                        periodoAcademico._periodoAcademicos.Alunos;
            ViewBag.TurmasLista = periodoAcademico._periodoAcademicos.Turmas == null ?
                    new List<TurmaModel>() :
                        periodoAcademico._periodoAcademicos.Turmas;

            ViewBag.MateriasLista = periodoAcademico._periodoAcademicos.Materias == null ?
                    new List<MateriaModel>() :
                        periodoAcademico._periodoAcademicos.Materias;


            return View(periodoAcademico._periodoAcademicos);
        }

        public ActionResult AdicionaPeriodoAcademico()
        {
            return View();

        }

        public ActionResult AdicionaMateria()
        {
            return RedirectToAction("AdicionaMateria", "Materia");

        }

        [HttpPost]
        public ActionResult AdicionaPeriodoAcademico(PeriodoAcademicoModel _PeriodoAcademicoModel)
        {
            _PeriodoAcademicoModel.Materias = (List<MateriaModel>)TempData["ListaMaterias"];
            periodoAcademico.CriaPeriodoAcademico(_PeriodoAcademicoModel);
            return RedirectToAction("Index");
        }
        public ViewResult DeletaPeriodoAcademico(int id)
        {
            return View(periodoAcademico.GetPeriodoAcademico(id));

        }

        [HttpPost]
        public RedirectToRouteResult DeletaPeriodoAcademico(int id, FormCollection collection)
        {
            periodoAcademico.DeletarPeriodoAcademico(id);
            return RedirectToAction("Index");
        }
    }
}
