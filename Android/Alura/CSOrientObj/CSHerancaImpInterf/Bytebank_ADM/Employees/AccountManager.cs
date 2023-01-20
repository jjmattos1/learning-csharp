using System;
using System.Linq;
using System.Collections.Generic;

namespace Bytebank_ADM
// if i specify the namespace as Bytebank_ADM.Directors here in Android
// C# Shell Copiler, it breaks the link between the classes!
{
    public class AccountManager : AuthenticableEmployee
    {
        
         /* the propertie and Auth method are already implemented in AuthenticableEmployee superclass
        public string Password { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        
        public bool Auth (string password)
        {
        	return Password == password;
        }
        */
        
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
        
        public override void raiseWage()
        {
        	this.Wage *= 1.05;
        }
        
        //
    }
}