using System;
using System.Collections.Generic;
using System.Text;

namespace ASC.Dominio
{
    public class PeriodoAcademicoModel
    {
        public int ID { get; set; }
        public List<AlunoModel> Alunos { get; set; }
        public int QtdAluno { get; set; }
        public List<TurmaModel> Turmas { get; set; }
        public int QtdTurma { get; set; }
        public List<MateriaModel> Materias { get; set; }
    }
}
