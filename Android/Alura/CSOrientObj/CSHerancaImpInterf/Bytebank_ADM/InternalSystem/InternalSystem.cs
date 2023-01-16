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
        		Console.WriteLine("Seja bem vindo(a) ao Sistema");
        		return true;
        	}
        	else
        	{
        		Console.WriteLine("Credencial inválidas!");
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
        		Console.WriteLine("Credencial inválidas!");
        		return false;
        	}
        }
    }
}