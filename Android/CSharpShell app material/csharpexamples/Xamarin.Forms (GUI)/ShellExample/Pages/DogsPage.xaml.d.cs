using System;
using Xamarin.Forms;
namespace CSharp_Shell
{
	public partial class DogsPage
	{
		internal WebView dogView;
		void InitializeComponent()
		{
			Xamarin.Forms.Xaml.Extensions.LoadFromXaml(this, typeof(DogsPage));
				dogView = (WebView)this.FindByName("dogView");
		}
	}
}
