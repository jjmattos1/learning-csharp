//This example requires the 'Xamarin.Forms GUI' option to be enabled
using System;
using Xamarin.Forms;  //This adds the UI controls
using XamarinFormsUiLib; //This adds some helper classes.

namespace CSharp_Shell
{

    public static class Program 
    {
        public static void Main() 
        {
           Ui.RunOnUiThread(()=> MainUi()); 
        }
        
        private static void MainUi()
        {
            int i=0;
            var stack = new StackLayout(); //A stack layout will contain Controls linearly, on top of one another (or left to right for Horizontal).
            var btn = new Button();
            btn.Text = "Hello World!";
            btn.Clicked += delegate
            {
                btn.Text = $"Button clicked {++i} times";    
            };
            stack.Children.Add(btn); // Add the button we created to the layout
            Ui.LoadMainLayout(stack); //Load and display the layout.
        }
		
		private static void MainUnderTheHood()
		{
			//Note: The 'Ui.Init()' method is called automaticaly when using anything from the 'Ui' class
			//However depending on how you write your code you may need to call it yourself 
			//if this exception is displayed '... You MUST call Xamarin.Forms.Init(); prior to using it ...'
			
			//Create an Application that will manage stuff.
			var app = new MyApp(); 
			// Create a page that will contain GUI elements - controls.
			var page = new ContentPage();
			
			
			int i=0;
			//A stack layout will contain Controls linearly, on top of one another (or left to right for Horizontal).
            var stack = new StackLayout(); 
            var btn = new Button();
            btn.Text = "Hello World!";
            btn.Clicked += delegate
            {
                btn.Text = $"Button clicked {++i} times";    
            };
			stack.Children.Add(btn); // Add the button we created to the layout
            page.Content = stack; //Set the content of the page. The root View.
			
			
			//Set the root page
			app.MainPage = page;
			Ui.LoadApplication(app);
		}
    }
	
	//A basic example for an Application class
	public class MyApp : Application
	{
		public MyApp()
		{
			
		}
	}
}