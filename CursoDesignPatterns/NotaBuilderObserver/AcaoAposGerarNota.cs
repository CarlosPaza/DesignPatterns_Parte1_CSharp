using CursoDesignPatterns.NotaBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoDesignPatterns.NotaBuilderObserver
{
    public interface AcaoAposGerarNota
    {
        void Executa(NotaFiscal notaFiscal);
    }
}
