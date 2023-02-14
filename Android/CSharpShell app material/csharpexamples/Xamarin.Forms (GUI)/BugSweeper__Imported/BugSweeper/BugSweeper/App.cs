//Project URL: https://docs.microsoft.com/bg-bg/samples/xamarin/xamarin-forms-samples/bugsweeper/
/*
	Steps taken to import project.
	1. Download and unzip.
	2. Click "Open file or new project" from menu
	3. Go to root folder ("INTERNAL_STORAGE/CSharpShell/examples/XamarinFormsUi/BugSweeper" for this example).
	4. Find the Application.cs or App.cs file and open it ("INTERNAL_STORAGE/CSharpShell/examples/XamarinFormsUi/BugSweeper/BugSweeper/App.cs" for this example).
	5. Open the left project menu and click the "+".
	6. Go to the folder of the Application.cs file ("INTERNAL_STORAGE/CSharpShell/examples/XamarinFormsUi/BugSweeper/BugSweeper" for this example)
	7. Add all files in this folder and subfolders by picking the option from the "..." menu in the toolbar.
	8. Add an entry point to App.cs which can be seen below.
	9. Add the files in the "Images" folder as embedded resources (used in "Tile.cs").
	
	Note: The Xamarin.Android, Xamarin.iOS, and Xamarin.UWP folders are ignored because C# Shell doesn't have the full tools for them.
	This also means that complex projects may not be supported.
*/
using System;
using Xamarin.Forms;


namespace BugSweeper
{
	public class App : Application
    {
		//This code segment is needed as the entry point for C# Shell.
		//This essentially replaces most of the purpose of the "Xamarin.Android" folder mentioned before.
#if CSHARPSHELL		
		public static void Main()
		{
			Ui.Init(); //This is equivalent to "Forms.Init" and necessary before using Xamarin.Forms.
			Ui.LoadApplication(new App());
		}
#endif
		
		public App ()
        {
            MainPage = new BugSweeperPage();
        }
    }
}
