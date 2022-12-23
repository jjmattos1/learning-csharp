using System;
using System.Linq;
using System.Collections.Generic;

namespace BytebankAndroid
{
    public class BankingAccount 
    {         
        private static int totalCreatedAccs;
        public static int TotalCreatedAccs
        {
        	get { return totalCreatedAccs; }
        	private set { totalCreatedAccs = value; }
        }
        
        
        
        //public Client
        public Client owner { get; set; }
        
        private int agNum = 0;
        public int AgNum
        {
        	get { return this.agNum; }
        	private set
        	{
        		if ( value > 0 )
        		this.agNum = value;
        	}
        }
        
        private string accNum = "";
        public string AccNum
        {
        	get { return this.accNum; }
        	set { this.accNum = value ; }
        }
        
        public BankingAccount (Client newOwner, int newAgNum, string newAccNum, double initBalance)
        {
        	this.owner = newOwner;
        	this.AgNum = newAgNum;
        	this.AccNum = newAccNum;
        	SetBalance(initBalance);
        	TotalCreatedAccs++;
        }
        
        //public string owner= "";
        
        private double balance = 0.00;
        
        public void SetBalance(double newBalance)
        {
        	this.balance = newBalance;
        }
        
        public double GetBalance()
        {
        	return this.balance;
        }
        
        //public Client tit0;
        
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
