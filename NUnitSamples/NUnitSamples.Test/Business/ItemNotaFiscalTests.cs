using NUnit.Framework;
using NUnitSamples.Model.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitSamples.Test.Business
{
    [TestFixture]
    public class ItemNotaFiscalTests
    {
        [Test]
        public void TestCalcularSubTotal()
        {
            NotaFiscal notaFiscal = new NotaFiscal();
            ItemNotaFiscal item = notaFiscal.AdicionarItem(1, "teste", 20, 100);
            double subTotalCalculado = item.CalcularSubTotal();

            Assert.AreEqual(2000, subTotalCalculado);

        }
    }
}
