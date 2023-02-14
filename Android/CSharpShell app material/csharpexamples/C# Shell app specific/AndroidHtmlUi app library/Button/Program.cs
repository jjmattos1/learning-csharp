using System;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using AndroidHtmlUi;

namespace CSharp_Shell
{

    public static class Program 
    {
        public static void Main() 
        {
           var form = new TableLayout();
           var btn = form.AddButton("btn", 1,1);
           btn.Click += delegate
           {
             for (int i=0; i<25; i++)
             {
               btn.Text += i;
             }
           };
           
           form.Show().Wait();
        }
    }
}















































































