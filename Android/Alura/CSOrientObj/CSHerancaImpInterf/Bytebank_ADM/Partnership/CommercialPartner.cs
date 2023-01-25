using System;
using System.Linq;
using System.Collections.Generic;

namespace Bytebank_ADM
{
    public class CommercialPartner : Authenticable
    {         
        public string Password { get; set; }
        
        public bool Auth (string password)
        {
        	return this.Password == password;
        }
        /*
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
        
        //
    }
}