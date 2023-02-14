using System;

namespace OperatorsAppl 
{

   class Program 
   {

      static async Task Main(string[] args) 
	  {	
		//Show a messagebox and wait for closure
		MessageBox.Show("Hello!");
	  
		//Show a messagebox and wait for closure asynchronously
		await MessageBox.ShowAsync("Hello, async!");
      }
   }
}