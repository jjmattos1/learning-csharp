//This file contains the C# the methods that can be used in a UI related context.
//For example the "ButtonClick" method is an event handler and
//the "text" field is a XAML element exposed by its "x:Name".
using System;
using System.IO;
using Xamarin.Forms;

namespace CSharp_Shell
{
	public partial class NewPage : ContentPage
	{
		public NewPage()
		{
			//Page classes are generally implemented in 2 files. 
			//This InitializeComponent resides in an auto-generated ".xaml.d.cs" file,
			//which is automatically updated when a ".xaml" file is saved.
			InitializeComponent();
		}
		
		
		public void ButtonClick(object sender, EventArgs args)
		{
			text.Text = ((Button)sender).Text;
		}
	}
}