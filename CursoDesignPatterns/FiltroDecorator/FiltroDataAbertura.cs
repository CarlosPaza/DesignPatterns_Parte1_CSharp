using CursoDesignPatterns.RelatorioTemplate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoDesignPatterns.FiltroDecorator
{
    public class FiltroDataAbertura : Filtro
    {
        public FiltroDataAbertura(Filtro outroFiltro) : base(outroFiltro) { }

        public FiltroDataAbertura() : base() { }

        public override IList<ContaReal> Filtra(IList<ContaReal> contas)
        {
            IList<ContaReal> lista = contas.Where(c => c.DataAbertura.Month == DateTime.Now.Month && c.DataAbertura.Year == DateTime.Now.Year).ToList();
            return lista.Union(ListaOutroFiltro(contas)).ToList();
        }
    }
}
