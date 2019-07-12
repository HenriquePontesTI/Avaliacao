using ASC.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AvaliacaoASC.Models
{
    public class Aluno
    {
        public List<AlunoModel> listaAlunos = new List<AlunoModel>();

        public Aluno()
        {

        }
        public void CriaAluno(AlunoModel AlunoModelo)
        {
            listaAlunos.Add(AlunoModelo);
        }

        public void AtualizaAluno(AlunoModel AlunoModelo)
        {
            foreach (AlunoModel Aluno in listaAlunos)
            {
                if (Aluno.Matricula == AlunoModelo.Matricula)
                {
                    listaAlunos.Remove(Aluno);
                    listaAlunos.Add(AlunoModelo);
                    break;
                }
            }
        }
        public AlunoModel GetAluno(int Matricula)
        {
            AlunoModel _AlunoModel = null;

            foreach (AlunoModel _Aluno in listaAlunos)
                if (_Aluno.Matricula == Matricula)
                    _AlunoModel = _Aluno;

            return _AlunoModel;
        }

        public void DeletarAluno(int Matricula)
        {
            foreach (AlunoModel _Aluno in listaAlunos)
            {
                if (_Aluno.Matricula == Matricula)
                {
                    listaAlunos.Remove(_Aluno);

                    break;
                }
            }
        }
    }
}

