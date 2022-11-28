using Bytebank;
using System;
using System.Linq;
// line
BankingAccount AndreAccount = new BankingAccount();

AndreAccount.owner = "André Silva";
AndreAccount.aGNum = 15;
AndreAccount.acc = "1010-X";
AndreAccount.balance = 100;

Console.WriteLine("Saldo da conta do André: R$ "+AndreAccount.balance);

// closing...
Console.WriteLine("\n\nPress any key to continue...");
Console.ReadLine();