using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoDesignPatterns.DescontoState
{
    public class EmAprovacao : EstadoDeUmOrcamento
    {
        private int descontoAplicado = 0;

        public void AplicaDescontoExtra(Orcamento orcamento)
        {
            if (descontoAplicado == 0)
            {
                orcamento.Valor -= orcamento.Valor * 0.05;
                descontoAplicado++;
            }
            else
                throw new Exception("Desconto já foi aplicado");
        }

        public void Aprova(Orcamento orcamento)
        {
            // desse estado posso ir para o estado de aprovado
            orcamento.EstadoAtual = new Aprovado();
        }

        public void Reprova(Orcamento orcamento)
        {
            // desse estado posso ir para o estado de reprovado tambem
            orcamento.EstadoAtual = new Reprovado();
        }

        public void Finaliza(Orcamento orcamento)
        {
            // daqui não posso ir direto para finalizado
            throw new Exception("Orcamento em aprovação não podem ir para finalizado diretamente");
        }
    }
}
