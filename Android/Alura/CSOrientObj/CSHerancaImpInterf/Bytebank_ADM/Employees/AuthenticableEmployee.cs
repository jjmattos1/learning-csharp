using System;
using System.Linq;
using System.Collections.Generic;

namespace Bytebank_ADM
{
    public abstract class AuthenticableEmployee : Employees, Authenticable
    {         
        //
        protected AuthenticableEmployee (string cpf, double wage) : base(cpf,wage)
        {
        	
        }
        
        public string Password { get; set; }

        public bool Auth (string password)
        {
        	return Password == password;
        }
        
        //
    }
}