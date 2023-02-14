using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace CSharp_Shell
{

    public class ShellExample 
    {
    	 public void Main()
    	 {
    	 	Ui.RunOnUiThread(()=>
    	 	{
				//Xamarin.Forms.Shell is still new and may be unstable. Check the website for details.
				//Warnings about missing images will be printed out in the console.
				//They aren't part of this package due to size constraints. You can add some icons if you want.
    	 		Ui.LoadMainPage(new MyShell());	
    	 	});
    	 	
    	 }
    }
}