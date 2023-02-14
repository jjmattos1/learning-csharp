using System;
using System.Linq;
using System.Collections.Generic;
using NativeUiLib;
using Android.Graphics;

namespace CSharp_Shell
{

    public static class Program 
    {
        public static void Main() 
        {
            Ui.RunOnUiThread(()=> UiStuff());
        }
		
		private static void UiStuff()
		{
		        var w = 800;
		        var h = 600;
				var lay = new LinearLayout();
				
                var drawingImageView = new ImageView();
                lay.AddView(drawingImageView);
				
				                
                var paint = new Paint();
                paint.Color = Color.Blue;
                paint.SetStyle(Paint.Style.Stroke);
                paint.StrokeWidth = 15;    
                var bmpBase = Bitmap.CreateBitmap(w, h, Bitmap.Config.Argb8888);
                Canvas canvas = new Canvas(bmpBase);
                canvas.DrawCircle(100, 100, 30, paint);
                drawingImageView.SetImageBitmap(bmpBase);
				
                Ui.ShowLayout(lay);
		}
    }
}