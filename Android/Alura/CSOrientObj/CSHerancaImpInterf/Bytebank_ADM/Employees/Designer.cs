using System;
using System.Linq;
using System.Collections.Generic;

namespace Bytebank_ADM
// if i specify the namespace as Bytebank_ADM.Directors here in Android
// C# Shell Copiler, it breaks the link between the classes!
{
    public class Designer : Employees
    {         
        public Designer (string cpf) : base (cpf, 3000)
        {
        	
        }
        
        public override double get1HBonus()
        {
        	return this.Wage;
        }
        
        public override double getBonus()
        {
        	return this.Wage * 0.17;
        }
        
        public void raiseWage()
        {
        	this.Wage *= 1.11;
        }
        
        //
    }
}