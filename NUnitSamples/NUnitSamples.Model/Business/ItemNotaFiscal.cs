using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitSamples.Model.Business
{
    public class ItemNotaFiscal
    {
        public NotaFiscal NotaFiscal { get; set; }

        private ItemNotaFiscal()
        {

        }

        public ItemNotaFiscal(NotaFiscal notaFiscal)
        {
            this.NotaFiscal = notaFiscal;
        }

        public int Codigo { get; set; }
        public string Descricao { get; set; }
        public double Quantidade { get; set; }
        public double ValorUnitario { get; set; }

        public double CalcularSubTotal()
        {
            return Quantidade * ValorUnitario;
        }
    }
}
