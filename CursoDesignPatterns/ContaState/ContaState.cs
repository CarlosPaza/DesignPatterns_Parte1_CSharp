using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoDesignPatterns.ContaState
{
    public class ContaState
    {
        public EstadoConta EstadoAtual { get; set; }
        public string Titular { get; private set; }
        public double Saldo { get; set; }

        public ContaState(string titular, double saldo)
        {
            this.Titular = titular;
            this.Saldo = saldo;
            if (saldo > 0)
                EstadoAtual = new Positivo();
            else
                EstadoAtual = new Negativo();
        }

        public void Sacar(double valor)
        {
            EstadoAtual.Sacar(this, valor);
        }

        public void Depositar(double valor)
        {
            EstadoAtual.Depositar(this, valor);
        }
    }
}
