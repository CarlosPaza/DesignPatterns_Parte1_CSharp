using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoDesignPatterns.RelatorioTemplate
{
    public abstract class TemplateRelatorio : Relatorio
    {
        public void ImprimeRelatorio(IList<ContaReal> contas)
        {
            ImprimeCabecalho();
            Console.WriteLine();
            ImprimeCorpo(contas);
            Console.WriteLine();
            ImprimeRodape();
        }

        protected abstract void ImprimeCabecalho();
        protected abstract void ImprimeCorpo(IList<ContaReal> contas);
        protected abstract void ImprimeRodape();
    }
}
