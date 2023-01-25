using System;
using System.Linq;
using System.Collections.Generic;
//using Bytebank_ADM;

namespace Bytebank_ADM
// if i specify the namespace as Bytebank_ADM.Employees here in Android
// C# Shell Copiler, it breaks the link between the classes!
{
    public abstract class Employees 
    {         
        public string Name { get; set; }
        public string Cpf { get; private set; }
        public double Wage { get; protected set; }
        //private double calc;
        
        public abstract double getBonus();
        /*{
        	
        	//calc = this.Wage * 0.1;
        	//return calc;
        	return this.Wage * 0.1;
        }*/
        
        public abstract double get1HBonus();
        /*{
        	return this.Wage * 0.2;
        
        }*/
        
        public static int EmployeesTotal { get; private set; }
        
        // default constructor method
        public Employees(string cpf, double wage)
        {
        	this.Cpf = cpf;
        	this.Wage = wage;
        	EmployeesTotal++;
        }
        
        public abstract void raiseWage();
        /*{
        	this.Wage *= 1.10;
        }*/
        
        //Object
		// remember that is possible to rewrite methods from Object and other main Base Classes
        public override string ToString()

        {
        	return	$"Nome: {this.Name} \n"+
        			$"CPF: {this.Cpf} \n"+
        			$"Salário: {this.Wage}";
        }
        
    }
}