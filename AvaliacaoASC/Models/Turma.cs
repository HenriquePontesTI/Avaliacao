using ASC.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AvaliacaoASC.Models
{
    public class Turma
    {
        public List<TurmaModel> listaTurmas = new List<TurmaModel>();

        public Turma()
        {

        }
        public void CriaTurma(TurmaModel TurmaModelo)
        {
            listaTurmas.Add(TurmaModelo);
        }

        public void AtualizaTurma(TurmaModel TurmaModelo)
        {
            foreach (TurmaModel Turma in listaTurmas)
            {
                if (Turma.NumeroTurma == TurmaModelo.NumeroTurma)
                {
                    listaTurmas.Remove(Turma);
                    listaTurmas.Add(TurmaModelo);
                    break;
                }
            }
        }
        public TurmaModel GetTurma(int NumeroTurma)
        {
            TurmaModel _TurmaModel = null;

            foreach (TurmaModel _Turma in listaTurmas)
                if (_Turma.NumeroTurma == NumeroTurma)
                    _TurmaModel = _Turma;

            return _TurmaModel;
        }

        public void DeletarTurma(int NumeroTurma)
        {
            foreach (TurmaModel _Turma in listaTurmas)
            {
                if (_Turma.NumeroTurma == NumeroTurma)
                {
                    listaTurmas.Remove(_Turma);

                    break;
                }
            }
        }
    }
}

