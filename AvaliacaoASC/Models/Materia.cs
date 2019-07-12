using ASC.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AvaliacaoASC.Models
{
    public class Materia
    {
        public List<MateriaModel> listaMaterias = new List<MateriaModel>();

        public Materia()
        {

        }
        public void CriaMateria(MateriaModel MateriaModelo)
        {
            listaMaterias.Add(MateriaModelo);
        }

        public void AtualizaMateria(MateriaModel MateriaModelo)
        {
            foreach (MateriaModel Materia in listaMaterias)
            {
                if (Materia.NumeroMateria == MateriaModelo.NumeroMateria)
                {
                    listaMaterias.Remove(Materia);
                    listaMaterias.Add(MateriaModelo);
                    break;
                }
            }
        }
        public MateriaModel GetMateria(int NumeroMateria)
        {
            MateriaModel _MateriaModel = null;

            foreach (MateriaModel _Materia in listaMaterias)
                if (_Materia.NumeroMateria == NumeroMateria)
                    _MateriaModel = _Materia;

            return _MateriaModel;
        }

        public void DeletarMateria(int NumeroMateria)
        {
            foreach (MateriaModel _Materia in listaMaterias)
            {
                if (_Materia.NumeroMateria == NumeroMateria)
                {
                    listaMaterias.Remove(_Materia);

                    break;
                }
            }
        }
    }
}

