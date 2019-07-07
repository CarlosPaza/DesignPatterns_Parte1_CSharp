using CursoDesignPatterns.ChainRequisicaoWeb;
using CursoDesignPatterns.FiltroDecorator;
using CursoDesignPatterns.ImpostoStrategy;
using CursoDesignPatterns.ImpostoStrategyDecorator;
using CursoDesignPatterns.RelatorioTemplate;
using CursoDesignPatterns.ContaState;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CursoDesignPatterns.NotaBuilder;
using CursoDesignPatterns.NotaBuilderObserver;

namespace CursoDesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            TestaNotaBuilder();

            Console.ReadLine();
        }

        static void TestaImposto() //Strategy
        {
            Imposto iss = new ISS();
            Imposto icms = new ICMS();
            Imposto iccc = new ICCC();
            Orcamento orcamento = new Orcamento(1500.0);
            orcamento.AdicionaItem(new Item("CANETA", 250.0));
            orcamento.AdicionaItem(new Item("LAPIS", 250.0));
            orcamento.AdicionaItem(new Item("CANETA", 250.0));
            CalculadorDeImposto calculador = new CalculadorDeImposto();

            // Calculando o ISS
            calculador.RealizaCalculo(orcamento, iss);

            // Calculando o ICMS        
            calculador.RealizaCalculo(orcamento, icms);

            calculador.RealizaCalculo(orcamento, iccc);

            calculador.RealizaCalculo(orcamento, new ICPP());

            calculador.RealizaCalculo(orcamento, new IHIT());
        }

        static void TestaInvestimento() //Strategy
        {
            Investimento conservador = new Conservador();
            Investimento moderado = new Moderado();
            Investimento arrojado = new Arrojado();
            ContaBancaria conta = new ContaBancaria();
            conta.Deposita(5000);
            var realiza = new RealizadorDeInvestimentos();

            // Calculando o ISS
            realiza.RealizaInvestimento(conta, conservador);

            // Calculando o ICMS        
            //calculador.RealizaCalculo(orcamento, icms);

            //calculador.RealizaCalculo(orcamento, iccc);
        }

        static void TestaDesconto() //Chain of responsability
        {
            CalculadorDeDescontos calculador = new CalculadorDeDescontos();

            Orcamento orcamento = new Orcamento(500.0);
            orcamento.AdicionaItem(new Item("CANETA", 250.0));
            orcamento.AdicionaItem(new Item("LAPIS", 250.0));

            double desconto = calculador.Calcula(orcamento);

            Console.WriteLine(desconto);
        }

        static void TestaRequisicao() //Chain of Responsability
        {
            var conta = new Conta("Carlos", 500);

            var req = new Requisicao(Formato.PORCENTO);

            Resposta reqporc = new RespostaEmPorcento(null);
            Resposta reqcsv = new RespostaEmCsv(reqporc);
            Resposta reqxml = new RespostaEmXml(reqcsv);

            //reqxml.OutraResposta = reqcsv;
            //reqcsv.OutraResposta = reqporc;

            reqxml.Responde(req, conta);
        }

        static void TestaRelatorio() //Template
        {
            var contas = new List<RelatorioTemplate.ContaReal>()
            {
                new ContaReal("Carlos", 1414, 5896, 500),
                new ContaReal("Jose", 1414, 5895, 900),
                new ContaReal("Maria", 1414, 4563, 100)
            };

            Relatorio relSimples = new RelatorioSimples();
            Relatorio relComplexo = new RelatorioComplexo();

            //relSimples.ImprimeRelatorio(contas);
            relComplexo.ImprimeRelatorio(contas);
        }

        static void TestaImpostoDecorator() //Decorator
        {
            Imposto impostoComplexo = new ImpostoMuitoAlto(new ICMS(new ISS()));

            Orcamento orcamento = new Orcamento(500.0);

            double valor = impostoComplexo.Calcula(orcamento);

            Console.WriteLine(valor);
        }

        static void TestaFiltro() //Decorator
        {
            var contas = new List<ContaReal>()
            {
                new ContaReal("Carlos", 1414, 5896, 500),
                new ContaReal("Jose", 1414, 5895, 900),
                new ContaReal("Maria", 1414, 4563, 80)
            };

            Filtro filtro = new FiltroMenor100(new FiltroMais500Mil(new FiltroDataAbertura()));

            var contasAnalisadas = filtro.Filtra(contas);

            foreach (var conta in contasAnalisadas)
            {
                Console.WriteLine($"{conta.Titular} - {conta.Saldo} - {conta.DataAbertura}");
            }
        }

        private static void TestaDescontoExtra() //State
        {
            Orcamento reforma = new Orcamento(500.0);

            reforma.AplicaDescontoExtra();
            Console.WriteLine(reforma.Valor); // imprime 475,00 pois descontou 5%
            reforma.Aprova(); // aprova nota!

            reforma.AplicaDescontoExtra();
            Console.WriteLine(reforma.Valor); // imprime 465,50 pois descontou 2%
            reforma.AplicaDescontoExtra();

            reforma.Finaliza();

            //reforma.AplicaDescontoExtra();
        }

        private static void TestaContaState() //State
        {
            var conta = new ContaState.ContaState("Carlos", 500.0);

            conta.Sacar(300);
            Console.WriteLine(conta.Saldo);
            conta.Sacar(400);
            Console.WriteLine(conta.Saldo);
            //conta.Sacar(100);
            conta.Depositar(500);
            Console.WriteLine(conta.Saldo); 
            conta.Depositar(100);
            Console.WriteLine(conta.Saldo);
        }

        private static void TestaNotaBuilder() //Builder
        {
            var listaAcoes = new List<AcaoAposGerarNota>()
            {
                new EnviadorDeEmail(),
                new NotaFiscalDao(),
                new EnviadorDeSms(),
                new Impressora(),
                new Multiplicador(2)
            };

            NotaFiscalBuilder builder = new NotaFiscalBuilder(listaAcoes);

            NotaFiscal nf = builder.ParaEmpresa("Caelum")
                          .ComCnpj("123.456.789/0001-10")
                          .Com(new ItemDaNotaBuilder()
                                  .ComNome("item 1")
                                  .ComValor(100.0)
                                  .Constroi())
                          .Com(new ItemDaNotaBuilder()
                                  .ComNome("item 2")
                                  .ComValor(200.0)
                                  .Constroi())
                          .Com(new ItemDaNotaBuilder()
                                  .ComNome("item 3")
                                  .ComValor(300.0)
                                  .Constroi())
                          .ComObservacoes("entregar nf pessoalmente")
                          .Constroi();

            Console.WriteLine(nf.ValorBruto);
            Console.WriteLine(nf.Impostos);
        }
    }
}
