using System;
using System.Linq;
using System.Collections.Generic;

namespace Bytebank_ADM
// if i specify the namespace as Bytebank_ADM.Directors here in Android
// C# Shell Copiler, it breaks the link between the classes!
{
    public class AccountManager : Employees
    {
    	public string Password { get; set; }
        
        public bool Auth (string password)
        {
        	return Password == password;
        }
        
        
        public AccountManager(string cpf) : base(cpf, 4000)
        {
        	
        }
        
        public override double get1HBonus()
        {
        	return this.Wage;
        }
        
        public override double getBonus()
        {
        	return this.Wage * 0.25;
        }
        
        public void raiseWage()
        {
        	this.Wage *= 1.05;
        }
        
        //
    }
}