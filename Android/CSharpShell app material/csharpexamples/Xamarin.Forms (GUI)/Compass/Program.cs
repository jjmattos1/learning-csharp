//+ref=System.Numerics.dll
using System;
using Xamarin.Essentials; //This contains the compass class along witch other sensors and useful stuff
using Xamarin.Forms; //This primarily contains the UI controls and the internals.

namespace CSharp_Shell
{

    public static class Program 
    {
        public static void Main()
        {   
			//Start of an anonymous method, which is invoked on the UI thread, since oontrols need to be created there
            Ui.RunOnUiThread(()=>
            {
				//Create main layout. It will contain the fixed pin and the rotationg stackV
                var stack = new StackLayout(); 
                stack.Orientation = StackOrientation.Vertical;
                Ui.Orientation = XamarinFormsUiLib.ScreenOrientation.Portrait;
				//Create vertical stack that will contain North, stackH and South
                var stackV = new StackLayout()
                {
                    Orientation = StackOrientation.Vertical,
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    VerticalOptions = LayoutOptions.FillAndExpand
                    
                };
				//Create a horizontal stack. It will contain West, Bearing and East
                var stackH = new StackLayout()
                {
                    Orientation = StackOrientation.Horizontal,
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    VerticalOptions = LayoutOptions.FillAndExpand
                };
            
				//Fixed red pin that will be on the top
                var pin = new Label()
                {
                    Text = "|",
                    TextColor = Color.Red,
                    FontSize = 30,
                    HorizontalOptions = LayoutOptions.Center
                };
                var north = new Label()
                {
                    Text = "N",
                    TextColor = Color.Red,
                    FontSize = 30,
                    HorizontalOptions = LayoutOptions.Center
                };
                var south = new Label()
                {
                    Text = "S",
                    FontSize = 30,
                    HorizontalOptions = LayoutOptions.Center
                };
                var west = new Label()
                {
                    Text = "W",
                    FontSize = 30,
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.StartAndExpand
                };
                var east = new Label()
                {
                    Text = "E",
                    FontSize = 30,
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.EndAndExpand
                };
                
                var bear = new Label()
                {
                    Text = ".",
                    FontSize = 20,
                    MinimumWidthRequest = 300,
                    MinimumHeightRequest = 300,
                    VerticalOptions = LayoutOptions.CenterAndExpand,
                    HorizontalOptions = LayoutOptions.CenterAndExpand
                };
                
                var di = DeviceDisplay.MainDisplayInfo;
				
				//This local method will be called to calculate offset dimensions to properly center the UI elements
                void Translate() //Define the method
                {
                    pin.TranslationY = di.Height / di.Density / 6;
                    north.TranslationY = di.Height / di.Density / 6;
                    south.TranslationY = -(di.Height / di.Density / 6);
                }
                Translate(); //Call the method
				
                DeviceDisplay.MainDisplayInfoChanged += (sdr, args) =>
                {
					//Screen rotated, asign new display info and invoke Translate().
                    di = args.DisplayInfo; 
                    Translate();
                };
                
				
				
				//We start adding stuff to the horizontal stack layout here.
                stackH.Children.Add(west); //Add first item
                stackH.Children.Add(bear); //Horizontal, so add second item to the right of the first
                stackH.Children.Add(east); //Add to right of second
				
				//We start adding stuff to the vertical stack layout here.
				stackV.Children.Add(north); //Add first item
                stackV.Children.Add(stackH); //Vertical, so add second item below the first. Yes, we are adding a layout inside a layout. The central 'row' - West, degrees, East.
                stackV.Children.Add(south); //Add below the second
				
				//Notice we added to 2 layouts up there. Now we add them to the main stack.
                stack.Children.Add(pin); //Add  the little pin on top
                stack.Children.Add(stackV); //Add the vertical layout, which contains the compass elements
                
				//Subscribe to the compass data event
                Compass.ReadingChanged += (sdr, e) =>
                {
                    stackV.Rotation = -e.Reading.HeadingMagneticNorth;
					bear.Rotation = e.Reading.HeadingMagneticNorth; //Keep the center unrotated.. by rotating it the opposite way
                    bear.Text = e.Reading.HeadingMagneticNorth.ToString("0°");
                };
                Compass.Start(SensorSpeed.UI); //Start taking reading from the compass
				
				//Use the 'Ui' utility class to display the interface that was just created.
                Ui.LoadMainLayout(stack);
            });
			//End of UI anonymous method,
        }
    }
}