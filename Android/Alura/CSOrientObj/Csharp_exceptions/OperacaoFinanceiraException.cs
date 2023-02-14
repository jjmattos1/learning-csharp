using System;
using System.Linq;
using System.Collections.Generic;

namespace Csharp_exception
{
    public class OperacaoFinanceiraException : Exception 
    {         
        /*
        public OperacaoFinanceiraException()
        {
        	
        }
        */
        public OperacaoFinanceiraException(string mensagem) : base(mensagem)

        {

        	
        }
        
        public OperacaoFinanceiraException(string mensagem, Exception excecaoInterna) : base(mensagem, excecaoInterna)

        {

        	
        }
    }
}