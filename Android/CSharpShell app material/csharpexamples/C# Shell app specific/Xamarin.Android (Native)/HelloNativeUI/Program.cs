using System;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using NativeUiLib;  //This adds the UI controls

namespace CSharp_Shell
{

    public static class Program 
    {
        public static void Main() 
        {
			int i=1;
            var lay = new LinearLayout();
            var btn = lay.AddButton();
            btn.Text = "Hello, Native UI";
    
            btn.Click += delegate
            {
              btn.Text = i.ToString();  
			  i++;
            };
            
            lay.Show();
           
        }
    }
}