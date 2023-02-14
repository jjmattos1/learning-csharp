using System;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using NativeUiLib; //This adds the UI controls

namespace CSharp_Shell
{

    public static class Program 
    {
        public static void Main() 
        {
           var lay = new LinearLayout();
           var btn = lay.AddButton(true);
           btn.Text = "Button";
           btn.Click += delegate
           {
               Toast.Show("Button clicked");
           };
           
           
           Ui.OptionsMenu.AddOptionsMenuItem("Toggle button visibility", ()=>
           {
                if (btn.Visibility != Android.Views.ViewStates.Visible) 
                {
                    btn.Visibility = Android.Views.ViewStates.Visible;
                }
                else
                {
                    btn.Visibility = Android.Views.ViewStates.Gone;
                }
           });
           
           Ui.OptionsMenu.AddOptionsMenuItem("Option 2", ()=> Toast.Show("Option 2"));
           
           lay.Show();
        }
    }
}