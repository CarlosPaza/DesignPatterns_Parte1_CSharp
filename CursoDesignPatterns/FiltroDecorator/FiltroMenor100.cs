using CursoDesignPatterns.RelatorioTemplate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoDesignPatterns.FiltroDecorator
{
    public class FiltroMenor100 : Filtro
    {
        public FiltroMenor100(Filtro outroFiltro) : base(outroFiltro) { }

        public FiltroMenor100() : base() { }

        public override IList<ContaReal> Filtra(IList<ContaReal> contas)
        {
            IList<ContaReal> lista = contas.Where(c => c.Saldo < 100).ToList();
            return lista.Union(ListaOutroFiltro(contas)).ToList();
        }
    }
}
