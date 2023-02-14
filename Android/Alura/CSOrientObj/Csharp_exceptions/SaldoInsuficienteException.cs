using System;
using System.Linq;
using System.Collections.Generic;

namespace Csharp_exception
{
    public class SaldoInsuficienteException : OperacaoFinanceiraException
    {         
        /*
        public SaldoInsuficienteException()
    	{
    		
    	}*/
        
        public SaldoInsuficienteException(string mensagem) : base(mensagem)
        {
        	
        }
        
        /*
        public double Saldo { get; }
		public double ValorSaque { get; }
		public SaldoInsuficienteException(double saldo, double valorSaque)
    		: this("Tentativa de saque de " + valorSaque + " com saldo de " + saldo)
				{
    				Saldo = saldo;
    				ValorSaque = valorSaque;
				}
        */
        
    }
}