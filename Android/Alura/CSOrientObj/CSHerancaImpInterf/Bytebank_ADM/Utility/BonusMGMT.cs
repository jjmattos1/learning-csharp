using System;
using System.Linq;
using System.Collections.Generic;

namespace Bytebank_ADM
// if i specify the namespace as Bytebank_ADM.Utility here in Android
// C# Shell Copiler, it breaks the link between the classes!

{
    public class BonusMGMT 
    {         
        public double BonusTotal { get; private set; }
        
        public void Register(Employees employee)
        {
        	this.BonusTotal += employee.getBonus();
        }
        
        public void Register(Directors director)

        {

        	this.BonusTotal += director.getBonus();
        }
    }
}