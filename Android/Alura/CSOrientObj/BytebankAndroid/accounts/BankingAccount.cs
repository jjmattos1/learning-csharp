using System;
using System.Linq;
using System.Collections.Generic;

namespace Bytebank
{
    public class BankingAccount 
    {         
        private int agNum = 0;
        public int AgNum
        {
        	get { return this.agNum; }
        	set
        	{
        		if ( value > 0 )
        		this.agNum = value;
        	}
        }
        
        public string accNum = "";
        //public string owner= "";
        public Client owner;
        
        private double balance = 0.00;
        
        public void SetBalance(double newBalance)
        {
        	this.balance = newBalance;
        }
        
        public double GetBalance()
        {
        	return this.balance;
        }
        
        public Client tit0;
        
        public void Deposit(double value)
        {
        	// deny negative deposit values
        	if ( value < 0)
        	{
        		return;
        	}
        	else
        	{
        		this.balance += value;
        	}
        	
        	
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
        
        public void ShowAcc(BankingAccount selAcc)
        {
            Console.WriteLine("\nAgência: "+selAcc.agNum);
            Console.WriteLine("Num. conta: "+selAcc.accNum);
            Console.WriteLine("Titular: "+selAcc.owner.name);
            Console.WriteLine("Saldo: "+selAcc.GetBalance());
        }
    }
}