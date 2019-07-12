using System;
using System.Collections.Generic;
using System.Text;

namespace ASC.Dominio
{
    public class TurmaModel
    {
        public int NumeroTurma { get; set; }
        public string NomeTurma { get; set; }

        public List<AlunoModel> Alunos { get; set; }
    }
}
