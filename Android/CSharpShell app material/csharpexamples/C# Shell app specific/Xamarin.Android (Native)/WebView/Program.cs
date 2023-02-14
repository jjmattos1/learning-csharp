using System;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using NativeUiLib;

namespace CSharp_Shell
{

    public static class Program 
    {
        public static void Main() 
        {
            //To prevent crash due to calling function from non-UI thread exception
            Ui.RunOnUiThread(()=>
            {
				try
				{
					UiStuff();
				}
				catch(Exception ex)
				{
					Console.WriteLine(ex.Message);
				}
            });
           
        }
		
		private static void UiStuff()
		{
				var lay = new LinearLayout();
				
                var webview = new WebView();
                webview.SetWebViewClient(new Android.Webkit.WebViewClient());
                webview.LoadUrl("https://www.google.com");
                lay.AddView(webview);
				
                Ui.ShowLayout(lay);
		}
		
		private static void UiStuffSmaller()
		{
				var lay = new LinearLayout();
				
                var webview = lay.AddWebView();
                webview.SetWebViewClient(new Android.Webkit.WebViewClient());
                webview.LoadUrl("https://www.google.com");
				
                lay.Show();
		}
    }
}