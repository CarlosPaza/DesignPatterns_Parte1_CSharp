using CursoDesignPatterns.ImpostoTemplate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoDesignPatterns.ImpostoStrategy
{
    public class IHIT : TemplateDeImpostoCondicional
    {
        public IHIT(Imposto outroImposto) : base(outroImposto) { }

        public IHIT() : base() { }

        public override bool DeveUsarMaximaTaxacao(Orcamento orcamento)
        {
            return DoisItensComMesmoNome(orcamento);
        }
        public override double MaximaTaxacao(Orcamento orcamento)
        {
            return orcamento.Valor * 0.13 + 100;
        }
        public override double MinimaTaxacao(Orcamento orcamento)
        {
            return orcamento.Valor * (0.01 * orcamento.Itens.Count);
        }

        private bool DoisItensComMesmoNome(Orcamento orcamento)
        {
            foreach (Item item in orcamento.Itens)
            {
                if (orcamento.Itens.Where(i => i.Nome == item.Nome).Count() >= 2) return true;
            }
            return false;
        }
    }
}
