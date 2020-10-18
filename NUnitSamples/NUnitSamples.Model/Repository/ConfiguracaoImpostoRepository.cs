using NUnitSamples.Model.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitSamples.Model.Repository
{
    public class ConfiguracaoImpostoRepository
    {
        private static Dictionary<ClassificacaoFornecedor, double> listaPercentuaisImposto = new Dictionary<ClassificacaoFornecedor, double>();

        public static void AddImpostoClassificacao(ClassificacaoFornecedor classificacao, double percentualImposto)
        {
            listaPercentuaisImposto.Add(classificacao, percentualImposto);
        }

        public static double GetPercentualImpostoPorClassificacao(ClassificacaoFornecedor classificacao)
        {
            return listaPercentuaisImposto[classificacao];
        }

        public static void ClearImpostosClassificacao()
        {
            listaPercentuaisImposto.Clear();
        }
    }
}
