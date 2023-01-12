using System;
using System.Linq;
using System.Collections.Generic;

namespace Bytebank_ADM
// if i specify the namespace as Bytebank_ADM.Directors here in Android
// C# Shell Copiler, it breaks the link between the classes!

{
    public class Directors : Employees
    {         
        /*
        // fields inherited from Employee superclass.
        public string DirName { get; set; }

        public string DirCpf { get; set; }
6ú
        public double DirWage { get; set; }
        */
        
        public override double getBonus()
        {
        	return this.Wage *= 0.5;
        }
        
        public override double get1HBonus()
        {
        	// code below prior from abstracting Employees class
        	//return this.Wage + base.get1HBonus();
        	
        	return this.Wage *= 0.2;
        }
        
        // default constructor method
        public Directors (string cpf): base(cpf, 5000)
        {
        	
        }
        
        public void raiseWage()
        {

        	this.Wage *= 1.15;
        }
    }
}