using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoDesignPatterns.ChainRequisicaoWeb
{
    public class RespostaEmPorcento : Resposta
    {
        public Resposta OutraResposta { get; set; }

        public RespostaEmPorcento(Resposta resp)
        {
            this.OutraResposta = resp;
        }


        public void Responde(Requisicao req, Conta conta)
        {
            if (req.Formato == Formato.PORCENTO)
            {
                Console.WriteLine(conta.Titular + "%" + conta.Saldo);
            }
            else
            {
                OutraResposta.Responde(req, conta);
            }
        }
    }
}
