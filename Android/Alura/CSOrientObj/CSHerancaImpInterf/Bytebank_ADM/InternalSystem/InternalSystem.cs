using System;
using System.Linq;
using System.Collections.Generic;

namespace Bytebank_ADM
{
    public class InternalSystem 
    {         
        public bool LogIn (Directors Employees, string password)
        {
        	bool authUser = Employees.Auth(password);
        	
        	if (authUser)
        	{
        		Console.WriteLine("Seja bem vindo(a) ao Sistema!");
        		return true;
        	}
        	else
        	{
        		Console.WriteLine("Credencial inválida!");
        		return false;
        	}
        }
        
        public bool LogIn (AccountManager Employees, string password)
        {

        	bool authUser = Employees.Auth(password);
        	
        	if (authUser)
        	{
        		Console.WriteLine("Seja bem vindo(a) ao Sistema!");
        		return true;
        	}
        	else
        	{
        		Console.WriteLine("Credencial inválida!");
        		return false;
        	}
        }
        
        public bool LogIn (string userName, string pw)
        {
        	if ((userName == "admin") && (pw == "masterkey"))
        	{
        		Console.WriteLine("Seja bem-vindo(a) ao Sistema! Auth login&pw");
        		return true;
        	}
        	else 
        	{
        		Console.WriteLine("Credencial inválida! Auth login&pw");
        		return false;
        	}
        }
        
        public bool LogIn (CommercialPartner Employees, string password)
        {

        	bool authUser = Employees.Auth(password);
        	
        	if (authUser)
        	{
        		Console.WriteLine("\nSeja bem vindo(a) ao Sistema! CommPartner");
        		return true;
        	}
        	else
        	{
        		Console.WriteLine("\nCredencial inválida! CommPartner");
        		return false;
        	}
        }
    }
}