using System;
using Xamarin.Forms;
namespace BugSweeper
{
	public partial class BugSweeperPage
	{
		internal Grid mainGrid;
		internal StackLayout textStack;
		internal Label timeLabel;
		internal Board board;
		internal StackLayout congratulationsText;
		internal StackLayout consolationText;
		internal Button playAgainButton;
		void InitializeComponent()
		{
			Xamarin.Forms.Xaml.Extensions.LoadFromXaml(this, typeof(BugSweeperPage));
				mainGrid = (Grid)this.FindByName("mainGrid");
				textStack = (StackLayout)this.FindByName("textStack");
				timeLabel = (Label)this.FindByName("timeLabel");
				board = (Board)this.FindByName("board");
				congratulationsText = (StackLayout)this.FindByName("congratulationsText");
				consolationText = (StackLayout)this.FindByName("consolationText");
				playAgainButton = (Button)this.FindByName("playAgainButton");
		}
	}
}
