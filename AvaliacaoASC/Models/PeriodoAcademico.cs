using ASC.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AvaliacaoASC.Models
{
    public class PeriodoAcademico
    {
        public List<PeriodoAcademicoModel> listaPeriodoAcademicos = new List<PeriodoAcademicoModel>();
        public PeriodoAcademicoModel _periodoAcademicos = new PeriodoAcademicoModel();

        public PeriodoAcademico()
        {

        }
        public void CriaPeriodoAcademico(PeriodoAcademicoModel periodoAcademicoModelo)
        {

            foreach(var materia in periodoAcademicoModelo.Materias)
            {
                var turmas = new Turma();
                var alunos = new Aluno();
                for (int x = 1; x <= periodoAcademicoModelo.QtdTurma; x++)
                {
                    var turma = new TurmaModel();
                    turma.NomeTurma = "T " + x;
                    turma.NumeroTurma = 1000 + x;
                    turmas.CriaTurma(turma);
                }

                materia.Turmas = turmas.listaTurmas;
                foreach(var itemTurma in materia.Turmas)
                {
                    for (int x = 1; x <= periodoAcademicoModelo.QtdAluno; x += 3)
                    {
                        var aluno = new AlunoModel();
                        aluno.Nome = "A " + x;
                        aluno.Matricula = 102030 + x;
                        aluno.Nota1 = new Random().Next(10);
                        aluno.Nota2 = new Random().Next(10);
                        aluno.Nota3 = new Random().Next(10);

                        var media = (aluno.Nota1 + aluno.Nota2 + aluno.Nota3) / 3;

                        if (media >= 6)
                            aluno.Resultado = "Aprovado";
                        else if (media <= 4)
                            aluno.Resultado = "Reprovado";
                        else
                        {
                            var provafinal = new Random().Next(10);
                            var mediaFinal = (media + provafinal) / 2;
                            if (mediaFinal >= 5)
                                aluno.Resultado = "Aprovado com prova final";
                            else
                                aluno.Resultado = "Reprovado";
                        }
                        alunos.CriaAluno(aluno);
                    }
                    itemTurma.Alunos = alunos.listaAlunos;
                }
            }
            _periodoAcademicos = periodoAcademicoModelo;
        }

        public void AtualizaPeriodoAcademico(PeriodoAcademicoModel PeriodoAcademicoModelo)
        {
            foreach (PeriodoAcademicoModel PeriodoAcademico in listaPeriodoAcademicos)
            {
                if (PeriodoAcademico.ID == PeriodoAcademicoModelo.ID)
                {
                    listaPeriodoAcademicos.Remove(PeriodoAcademico);
                    listaPeriodoAcademicos.Add(PeriodoAcademicoModelo);
                    break;
                }
            }
        }
        public PeriodoAcademicoModel GetPeriodoAcademico(int ID)
        {
            PeriodoAcademicoModel _PeriodoAcademicoModel = null;

            foreach (PeriodoAcademicoModel _PeriodoAcademico in listaPeriodoAcademicos)
                if (_PeriodoAcademico.ID == ID)
                    _PeriodoAcademicoModel = _PeriodoAcademico;

            return _PeriodoAcademicoModel;
        }

        public void DeletarPeriodoAcademico(int ID)
        {
            foreach (PeriodoAcademicoModel _PeriodoAcademico in listaPeriodoAcademicos)
            {
                if (_PeriodoAcademico.ID == ID)
                {
                    listaPeriodoAcademicos.Remove(_PeriodoAcademico);

                    break;
                }
            }
        }
    }
}

