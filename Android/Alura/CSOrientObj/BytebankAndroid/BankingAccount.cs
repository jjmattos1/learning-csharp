using System;
using System.Linq;
using System.Collections.Generic;

namespace Bytebank
{
    public class BankingAccount 
    {         
        public int agNum = 0;
        public string accNum = "";
        //public string owner= "";
        public Client owner;
        public double balance = 0.00;
        
        public void Deposit(double value)
        {
        	this.balance += value;
        }
        
        public void Withdrawn(double value)
        {
        	this.balance -= value;
        }
        
        public bool Transfer(double value, BankingAccount destiny)
        {
        	//double value;
        	//string accNum;
        	if (this.balance < value)
        	{
        		return false;
        	}
        	else 
        	{
        		this.balance -= value;
                destiny.balance += value;
                return true;
        		
        	}
        	
        }
    }
}