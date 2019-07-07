using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoDesignPatterns.RelatorioTemplate
{
    public interface Relatorio
    {
        void ImprimeRelatorio(IList<ContaReal> contas);
    }
}
