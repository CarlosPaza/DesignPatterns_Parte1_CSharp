using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoDesignPatterns
{
    public class ICCC : Imposto
    {
        public ICCC(Imposto outroImposto) : base(outroImposto) { }

        public ICCC() : base() { }

        public override double Calcula(Orcamento orcamento)
        {
            if (orcamento.Valor < 1000)
                return orcamento.Valor * 0.05 + CalculoDoOutroImposto(orcamento);
            if (orcamento.Valor > 3000)
                return orcamento.Valor * 0.08 + 30 + CalculoDoOutroImposto(orcamento);

            return orcamento.Valor * 0.07 + CalculoDoOutroImposto(orcamento);
        }
    }
}
