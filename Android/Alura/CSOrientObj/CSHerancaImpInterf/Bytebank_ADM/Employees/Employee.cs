using System;
using System.Linq;
using System.Collections.Generic;
//using Bytebank_ADM;

namespace Bytebank_ADM
{
    public class Employee 
    {         
        public string Name { get; set; }
        public string Cpf { get; set; }
        public double Wage { get; set; }
        
        public double GetBonus()
        {
        	return this.Wage *= 0.1;
        }
        
        
        
    }
}