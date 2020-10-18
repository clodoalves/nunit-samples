using NUnit.Framework;
using NUnitSamples.Model.Business;
using NUnitSamples.Model.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitSamples.Test.Repository
{

    [TestFixture]
    public class TesteConfiguracaoImpostoRepository
    {
        [SetUp]
        public void CarregarImpostos()
        {
            ConfiguracaoImpostoRepository.AddImpostoClassificacao(ClassificacaoFornecedor.MicroEmpresa, 5);
            ConfiguracaoImpostoRepository.AddImpostoClassificacao(ClassificacaoFornecedor.GrandeEmpresa, 30);
        }

        [Test]
        public void TestAddImpostoClassificacao()
        {
            double percentualImposto = ConfiguracaoImpostoRepository.GetPercentualImpostoPorClassificacao(ClassificacaoFornecedor.GrandeEmpresa);
            Assert.AreEqual(30, percentualImposto);
        }

        [Test]
        public void TestGetPercentualImpostoPorClassificacao()
        {
            double percentualImposto = ConfiguracaoImpostoRepository.GetPercentualImpostoPorClassificacao(ClassificacaoFornecedor.MicroEmpresa);
            Assert.AreEqual(5, percentualImposto);
        }

        [TearDown]
        public void LimparImpostos()
        {
            ConfiguracaoImpostoRepository.ClearImpostosClassificacao();
        }
    }
}
