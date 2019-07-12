using System;
using System.Collections.Generic;
using System.Text;

namespace ASC.Dominio
{
    public class MateriaModel
    {
        public int NumeroMateria{ get; set; }

        public string NomeMateria { get; set; }

        public int PesoProva1 { get; set; }

        public int PesoProva2 { get; set; }

        public int PesoProva3 { get; set; }

        public virtual List<TurmaModel> Turmas { get; set; }

    }
}
