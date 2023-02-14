//This example requires the 'Xamarin.Forms GUI' option to be enabled
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using Xamarin.Forms;  //This adds the UI controls

namespace CSharp_Shell
{
    public class TabsPage : TabbedPage
    {
        public TabsPage()
        {
            this.Children.Add(CreatePage("Page 1")); //Tab 1
            this.Children.Add(CreatePage("Page 2")); //Tab 2
        }
        
        private Page CreatePage(string str)
        {
            var page = new ContentPage();
            var stack = new StackLayout();
            var btn = new Button();
            btn.Text = str;
            stack.Children.Add(btn);
            page.Title = str;
            page.Content = stack;
            return page;
        }
    }

    public static class Program 
    {
        public static void Main() 
        {
           Ui.RunOnUiThread(()=>
           {
              Ui.LoadMainPage(new TabsPage()); 
           });
        }
    }
}