using System;
using System.Linq;
using System.Collections.Generic;

namespace Bytebank_ADM
{
    public interface Authenticable
    {         
        //
        
        public string Password { get; set; }

        public bool Auth (string password)
        {
        	return Password == password;
        }
        
        /* removing constructor because its not a heir from Employees
        public Authenticable (string cpf, double wage) : base(cpf, wage)

        {
        	
        }
        
        public override void raiseWage()
        {
        	throw new NotImplementedException();
        }
        
        public override double getBonus()
        {
        	throw new NotImplementedException();
        }
        
        public override double get1HBonus()
        {
        	throw new NotImplementedException();
        }
        */
        
    }
}