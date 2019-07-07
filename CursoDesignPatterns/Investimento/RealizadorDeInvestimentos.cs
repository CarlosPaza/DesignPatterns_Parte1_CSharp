using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoDesignPatterns
{
    public class RealizadorDeInvestimentos
    {
        public void RealizaInvestimento(ContaBancaria conta, Investimento investimento)
        {
            double valor = investimento.Calcula(conta);
            conta.Deposita(valor * 0.75);
            Console.WriteLine("Novo saldo: " + conta.Saldo);
        }
    }
}
