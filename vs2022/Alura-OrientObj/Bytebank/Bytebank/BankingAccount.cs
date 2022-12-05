using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bytebank
{
    public class BankingAccount
    {
        public int agNum = 0;
        public string accNum = "";
        //public string owner = "";
        public double balance = 0.00;
        public Client owner;

        public void Withdrawn(double value)
        {
            this.balance -= value;
        }

        public void Deposit(double value)
        {
            this.balance += value;
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
                this.Withdrawn(value);
                destiny.Deposit(value);
                return true;

            }

        }

        public void ShowAcc(BankingAccount selAcc)
        {
            Console.WriteLine("\nAgência: "+selAcc.agNum);
            Console.WriteLine("Num. conta: "+selAcc.accNum);
            Console.WriteLine("Titular: "+selAcc.owner);
            Console.WriteLine("Saldo: "+selAcc.balance);
        }
    }
}
