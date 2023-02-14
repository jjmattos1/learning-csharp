using System;
using System.IO;
using Xamarin.Forms;

namespace CSharp_Shell
{
	public partial class DogsPage : ContentPage
	{
		public DogsPage()
		{
			InitializeComponent();
			dogView.Source = "https://www.google.com/search?tbm=isch&q=dogs";
		}
	}
}