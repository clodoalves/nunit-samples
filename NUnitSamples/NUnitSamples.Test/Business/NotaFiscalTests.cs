using NUnit.Framework;
using NUnitSamples.Model.Business;
using NUnitSamples.Model.Exceptions;
using NUnitSamples.Model.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitSamples.Test.Business
{
    [TestFixture]
    public class NotaFiscalTests
    {
        private const double VALOR_TOTAL_NOTAFISCAL = 1350;
        private NotaFiscal notaFiscal = null;

        [SetUp]
        public void CarregarNotaFiscal()
        {
            Fornecedor fornecedor = new Fornecedor();

            notaFiscal = new NotaFiscal();
            notaFiscal.Fornecedor = fornecedor;
            notaFiscal.AdicionarItem(1001, "Alicate de Corte", 50, 10);
            notaFiscal.AdicionarItem(1002, "Chave de Fenda", 30, 25);
            notaFiscal.AdicionarItem(1003, "Chave Inglesa", 20, 5);

            ConfiguracaoImpostoRepository.AddImpostoClassificacao(ClassificacaoFornecedor.MicroEmpresa, 5);
            ConfiguracaoImpostoRepository.AddImpostoClassificacao(ClassificacaoFornecedor.MediaEmpresa, 10);
            ConfiguracaoImpostoRepository.AddImpostoClassificacao(ClassificacaoFornecedor.GrandeEmpresa, 15);

        }

        [Test]
        public void TesteVerificarItemExisteNotaFiscal()
        {
            bool itemEncontrado = notaFiscal.VerificaItemExisteNaNotaFiscal(1001);

            Assert.IsTrue(itemEncontrado);
        }

        [Test]
        public void TesteVerificarItemNaoExisteNaNotaFiscal()
        {
            bool itemEncontrado = notaFiscal.VerificaItemExisteNaNotaFiscal(2001);

            Assert.IsFalse(itemEncontrado);
        }

        [Test]
        public void TesteCalcularValorTotalNotaFiscalSemFornecedor()
        {
            notaFiscal.Fornecedor = null;

            Assert.Throws(typeof(FornecedorNaoInformadoException),
                delegate () { notaFiscal.CalcularValorTotalNotaFiscal();});
        }

        [Test]
        public void TesteCalcularValorNotaFiscalMicroEmpresa()
        {
            notaFiscal.Fornecedor.Classificacao = ClassificacaoFornecedor.MicroEmpresa;
            double percentualImposto = ConfiguracaoImpostoRepository.GetPercentualImpostoPorClassificacao(notaFiscal.Fornecedor.Classificacao);

            double valorEsperado = VALOR_TOTAL_NOTAFISCAL + (VALOR_TOTAL_NOTAFISCAL * percentualImposto / 100);
            double valorCalculado = notaFiscal.CalcularValorTotalNotaFiscal();

            Assert.AreEqual(valorEsperado, valorCalculado);
        }

        [Test]
        public void TesteCalcularValorNotaFiscalMediaEmpresa()
        {
            notaFiscal.Fornecedor.Classificacao = ClassificacaoFornecedor.MediaEmpresa;
            double percentualImposto = ConfiguracaoImpostoRepository.GetPercentualImpostoPorClassificacao(notaFiscal.Fornecedor.Classificacao);

            double valorEsperado = VALOR_TOTAL_NOTAFISCAL + (VALOR_TOTAL_NOTAFISCAL * percentualImposto / 100);
            double valorCalculado = notaFiscal.CalcularValorTotalNotaFiscal();

            Assert.AreEqual(valorEsperado, valorCalculado);
        }

        [Test]
        public void TesteCalcularValorNotaFiscalGrandeEmpresa()
        {
            notaFiscal.Fornecedor.Classificacao = ClassificacaoFornecedor.GrandeEmpresa;
            double percentualImposto = ConfiguracaoImpostoRepository.GetPercentualImpostoPorClassificacao(notaFiscal.Fornecedor.Classificacao);

            double valorEsperado = VALOR_TOTAL_NOTAFISCAL + (VALOR_TOTAL_NOTAFISCAL * percentualImposto / 100);
            double valorCalculado = notaFiscal.CalcularValorTotalNotaFiscal();

            Assert.AreEqual(valorEsperado, valorCalculado);
        }

        [Test]
        public void RemoverItem()
        {
            int codigoItem = 1001;

            notaFiscal.RemoverItem(codigoItem);

            bool itemEncontrado = notaFiscal.VerificaItemExisteNaNotaFiscal(codigoItem);

            Assert.IsFalse(itemEncontrado);
        }

        [TearDown]
        public void LimparImpostos()
        {
            ConfiguracaoImpostoRepository.ClearImpostosClassificacao();
        }
    }
}
