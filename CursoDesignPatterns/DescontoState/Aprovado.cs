using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoDesignPatterns.DescontoState
{
    public class Aprovado : EstadoDeUmOrcamento
    {
        private int descontoAplicado = 0;

        public void AplicaDescontoExtra(Orcamento orcamento)
        {
            if (descontoAplicado == 0)
            {
                orcamento.Valor -= orcamento.Valor * 0.02;
                descontoAplicado++;
            }                
            else
                throw new Exception("Desconto já foi aplicado");
        }

        public void Aprova(Orcamento orcamento)
        {
            // jah estou em aprovacao
            throw new Exception("Orçamento já está em estado de aprovação");
        }

        public void Reprova(Orcamento orcamento)
        {
            // nao pode ser reprovado agora!
            throw new Exception("Orçamento está em estado de aprovação e não pode ser reprovado");
        }

        public void Finaliza(Orcamento orcamento)
        {
            // daqui posso ir para o estado de finalizado
            orcamento.EstadoAtual = new Finalizado();
        }
    }
}
