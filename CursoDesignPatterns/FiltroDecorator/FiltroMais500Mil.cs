using CursoDesignPatterns.RelatorioTemplate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoDesignPatterns.FiltroDecorator
{
    public class FiltroMais500Mil : Filtro
    {
        public FiltroMais500Mil(Filtro outroFiltro) : base(outroFiltro) { }

        public FiltroMais500Mil() : base() { }

        public override IList<ContaReal> Filtra(IList<ContaReal> contas)
        {
            IList<ContaReal> lista = contas.Where(c => c.Saldo > 500000).ToList();
            return lista.Union(ListaOutroFiltro(contas)).ToList();
        }
    }
}
