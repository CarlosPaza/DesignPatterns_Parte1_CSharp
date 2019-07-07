using CursoDesignPatterns.RelatorioTemplate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoDesignPatterns.FiltroDecorator
{
    public abstract class Filtro
    {
        private readonly Filtro OutroFiltro;

        public Filtro(Filtro outroFiltro)
        {
            this.OutroFiltro = outroFiltro;
        }

        public Filtro()
        {
            this.OutroFiltro = null;
        }

        protected IList<ContaReal> ListaOutroFiltro(IList<ContaReal> contas)
        {
            // tratando o caso do proximo imposto nao existir!
            if (OutroFiltro == null) return new List<ContaReal>();
            return OutroFiltro.Filtra(contas);
        }

        public abstract IList<ContaReal> Filtra(IList<ContaReal> contas);
    }
}
