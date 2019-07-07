using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoDesignPatterns.ContaState
{
    public abstract class EstadoConta
    {
        public abstract void Sacar(ContaState conta, double valor);
        public abstract void Depositar(ContaState conta, double valor);

        protected void VerificaSaldo(ContaState conta)
        {
            if (conta.Saldo > 0)
                conta.EstadoAtual = new Positivo();
            else
                conta.EstadoAtual = new Negativo();
        }
    }
}
