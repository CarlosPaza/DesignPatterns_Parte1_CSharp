using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoDesignPatterns.ChainRequisicaoWeb
{
    public class RespostaEmCsv : Resposta
    {
        public Resposta OutraResposta { get; set; }

        public RespostaEmCsv(Resposta resp)
        {
            this.OutraResposta = resp;
        }

        public void Responde(Requisicao req, Conta conta)
        {
            if (req.Formato == Formato.CSV)
            {
                Console.WriteLine(conta.Titular + ";" + conta.Saldo);
            }
            else
            {
                OutraResposta.Responde(req, conta);
            }
        }
    }
}
