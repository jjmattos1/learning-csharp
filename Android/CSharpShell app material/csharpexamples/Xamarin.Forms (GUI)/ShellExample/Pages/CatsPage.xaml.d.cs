using System;
using Xamarin.Forms;
namespace CSharp_Shell
{
	public partial class CatsPage
	{
		internal WebView catView;
		void InitializeComponent()
		{
			Xamarin.Forms.Xaml.Extensions.LoadFromXaml(this, typeof(CatsPage));
				catView = (WebView)this.FindByName("catView");
		}
	}
}
