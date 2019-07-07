using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoDesignPatterns.RelatorioTemplate
{
    public class RelatorioSimples : TemplateRelatorio
    {
        protected override void ImprimeCabecalho()
        {
            Console.WriteLine("Banco ByteBank");
        }
        protected override void ImprimeCorpo(IList<ContaReal> contas)
        {
            foreach (var conta in contas)
            {
                Console.WriteLine($"Nome: {conta.Titular} - Saldo: {conta.Saldo}");
            }
        }
        protected override void ImprimeRodape()
        {
            Console.WriteLine("Fone: 3355 6547");
        }
    }
}
