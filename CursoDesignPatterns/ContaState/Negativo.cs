using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoDesignPatterns.ContaState
{
    public class Negativo : EstadoConta
    {
        public override void Sacar(ContaState conta, double valor)
        {
            throw new Exception("Conta está negativa e não permite saques.");
        }

        public override void Depositar(ContaState conta, double valor)
        {
            conta.Saldo += valor * 0.95;
            VerificaSaldo(conta);
        }
    }
}
