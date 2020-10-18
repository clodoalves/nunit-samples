using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitSamples.Model.Exceptions
{
    public class FornecedorNaoInformadoException : Exception
    {
        public FornecedorNaoInformadoException()
        {

        }

        public override string Message
        {
            get
            {
                return "O fornecedor não foi informado.";
            }
        }
    }
}
