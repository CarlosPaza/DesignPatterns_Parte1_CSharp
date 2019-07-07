using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoDesignPatterns.RelatorioTemplate
{
    public class RelatorioComplexo : TemplateRelatorio
    {
        protected override void ImprimeCabecalho()
        {
            Console.WriteLine("Banco ByteBank - Fone: 3355 6547");
            Console.WriteLine("Endereço: Rua dos Palmares 574, Brusque/SC");
            Console.WriteLine("Fone: 3355 6547");
        }
        protected override void ImprimeCorpo(IList<ContaReal> contas)
        {
            foreach (var conta in contas)
            {
                Console.WriteLine($"Nome: {conta.Titular} - Conta: {conta.Agencia}/{conta.Numero} - Saldo: {conta.Saldo}");
            }
        }
        protected override void ImprimeRodape()
        {
            Console.WriteLine("Email: contato@bytebank.com.br");
            Console.WriteLine($"Data: {DateTime.Now}");
        }
    }
}
