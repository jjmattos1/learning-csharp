using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace CSharp_Shell
{

    public class XAMLPage 
    {
    	public void Main()
    	{
    		Ui.RunOnUiThread(()=>
    		{
				//Load and show the page.
				//Page files can be created from the '+' in the project menu
    			Ui.LoadMainPage(new NewPage());
    		});
    	}
    }
}