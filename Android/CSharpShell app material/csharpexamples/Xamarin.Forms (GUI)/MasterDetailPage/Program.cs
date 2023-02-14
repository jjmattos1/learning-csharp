//This example requires the 'Xamarin.Forms GUI' option to be enabled
using System;
using System.Linq;
using System.Collections.Generic;
using Xamarin.Forms;  //This adds the UI controls

namespace CSharp_Shell
{
    public class Template
    {
        public string Text { get; set; }
    }
    
    public class MultiPage : MasterDetailPage 
    {
        public MultiPage()
        {
            Master = new MasterPage(this); //Drawer
            Detail = new NavigationPage(new DetailPage("Page 1")); //Content
        }
    }
    
    public class MasterPage : ContentPage
    {
        private MasterDetailPage mdp;
        public MasterPage(MasterDetailPage mdp)
        {
            this.mdp = mdp; //Save a reference to the MasterDetailPage.
            var stack = new StackLayout();
            var list = new List<Template>()
            {
                new Template() { Text = "Page 1" },
                new Template() { Text = "Page 2" }
            };
			
			//Create a ListView to display the List<Template>.
            var lw = new ListView();
            lw.ItemTemplate = new DataTemplate(typeof(TextCell)); //Specify a text/string cell.
            lw.ItemTemplate.SetBinding(TextCell.TextProperty, "Text"); //Bind Template.Data from the list to the TextProperty of the cell.
            lw.ItemsSource = list; //Set the list as the source.
            lw.ItemSelected += Lw_ItemSelected; //Subscribe to item click event.
			
			
            stack.Children.Add(lw); //Add the
            Content = stack;
            Title = "MultiPage";
        }
        
        private void Lw_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = (Template)e.SelectedItem; //Get the selected item
			//Create a DetailPage. Put it inside a NavigationPage to enable the Toolbar on top.
            var page = new NavigationPage(new DetailPage(item.Text));
            mdp.Detail = page; //Set the Detail (Content) of he MasterDetailPage
        }
    }
    
    public class DetailPage : ContentPage
    {
        public DetailPage(string str)
        {
            var stack = new StackLayout();
            var lbl = new Label();
            lbl.Text=str;
            stack.Children.Add(lbl);
            Content = stack;
        }
        
    }
    
    public static class Program 
    {
        public static void Main() 
        {
            Console.WriteLine();
            
            Ui.RunOnUiThread(()=>
            {
               var page = new MultiPage();
               Ui.LoadMainPage(page);
            });
        }
    }
}