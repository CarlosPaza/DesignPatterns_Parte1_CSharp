using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoDesignPatterns.RelatorioTemplate
{
    public class ContaReal
    {
        public string Titular { get; private set; }
        public double Saldo { get; private set; }
        public int Agencia { get; private set; }
        public int Numero { get; private set; }
        public DateTime DataAbertura { get; set; }

        public ContaReal(string titular, int agencia, int numero, double saldo)
        {
            this.Titular = titular;
            this.Saldo = saldo;
            this.Agencia = agencia;
            this.Numero = numero;
            this.DataAbertura = DateTime.Now;
        }
    }
}
