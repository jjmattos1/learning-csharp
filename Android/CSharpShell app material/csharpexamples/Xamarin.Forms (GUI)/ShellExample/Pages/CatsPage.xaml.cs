using System;
using System.IO;
using Xamarin.Forms;

namespace CSharp_Shell
{
	public partial class CatsPage : ContentPage
	{
		public CatsPage()
		{
			InitializeComponent();
			catView.Source = "https://www.google.com/search?tbm=isch&q=cats";
		}
	}
}