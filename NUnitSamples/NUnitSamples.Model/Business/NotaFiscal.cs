using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitSamples.Model.Business
{
    public class NotaFiscal
    {
        public NotaFiscal()
        {
            Itens = new List<ItemNotaFiscal>();
        }

        private List<ItemNotaFiscal> Itens;



        public Fornecedor Fornecedor { get; set; }

        public ItemNotaFiscal AdicionarItem
        (int codigo, string descricao,
         double quantidade, double valorUnitario)
        {
                 ItemNotaFiscal item = new ItemNotaFiscal(this);
                 item.Codigo = codigo;
                 item.Descricao = descricao;
                 item.Quantidade = quantidade;
                 item.ValorUnitario = valorUnitario;

                 Itens.Add(item);

                 return item;
             }

             public bool VerificaItemExisteNaNotaFiscal(int codigo)
             {
                 ItemNotaFiscal itemLocalizado = Itens.Find
                 (x => x.Codigo == codigo);

                 return itemLocalizado != null;
             }

             public void RemoverItem(int codigo)
             {
                 ItemNotaFiscal itemLocalizado = Itens.Find
                 (x => x.Codigo == codigo);
                 if (itemLocalizado != null)
                     Itens.Remove(itemLocalizado);
             }

             public double CalcularValorTotalNotaFiscal()
             {
                 if(Fornecedor == null)
                     throw new FornecedorNaoInformadoException();

                 double total = 0;

                 foreach(ItemNotaFiscal item in Itens){
                     total = total + item.CalcularSubTotal();
                 }

                 double pecentualImposto =
                   ConfiguracaoImpostoRepository.GetPercentual
                    ImpostoPorClassificacao
                   (Fornecedor.Classificacao);

                 return total + (total* pecentualImposto / 100);
             }
         }
     }

    }
}
