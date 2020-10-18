using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitSamples.Model.Business
{
    public class Fornecedor
    {
        public string RazaoSocial { get; set; }
        public ClassificacaoFornecedor Classificacao { get; set; }
    }
}
