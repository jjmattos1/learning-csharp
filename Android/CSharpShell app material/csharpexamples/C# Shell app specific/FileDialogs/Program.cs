using System;

namespace OperatorsAppl 
{

   class Program 
   {

      static void Main(string[] args) 
	  {	
		var open = new OpenFileDialog();
		var save = new SaveFileDialog();
		
		//You can also run this asynchronously: await open.ShowAsync() == DialogResult.OK
		if (open.Show() == DialogResult.OK)
		{
			Console.WriteLine(open.FileName);
		}
		
		if (save.Show() == DialogResult.OK)
		{
			Console.WriteLine(open.FileName);
		}
		
      }
   }
}