using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoDesignPatterns.ContaState
{
    public class Positivo : EstadoConta
    {
        public override void Sacar(ContaState conta, double valor)
        {
            conta.Saldo -= valor;
            VerificaSaldo(conta);
        }

        public override void Depositar(ContaState conta, double valor)
        {
            conta.Saldo += valor * 0.98;
            VerificaSaldo(conta);
        }
    }
}
