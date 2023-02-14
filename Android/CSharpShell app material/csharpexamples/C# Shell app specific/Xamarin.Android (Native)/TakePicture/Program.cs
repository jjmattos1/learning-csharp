/* In depth information about common action intents
https://developer.android.com/guide/components/intents-common
*/

//+ref=Java.Interop.dll
//+ref=Xamarin.Android.Support.v4.dll
//+ref=Xamarin.Android.Support.Core.Utils.dll
//+ref=Xamarin.Android.Support.Compat.dll
using System;
using Android.App;
using Android.Content;
using Android.Provider;
using Android.Graphics;
using Android.OS;
using Java.IO;
using Environment = Android.OS.Environment;
using Uri = Android.Net.Uri;
using NativeUiLib;

namespace CSharp_Shell
{

    public static class Program 
    {
		static readonly int REQUEST_IMAGE_CAPTURE = 11;
		static Button btnTakePicture; //We will click this button to start the camera.
		static TextView lblImagePath; //This TextView will show the path of the picture taken.
		static ImageView imgThumbnail;	//This image is a preview of the picture. Click to show full size.
		static string imagePath; // Path of the picture taken.
		static Uri imageURI; //The URI of the picture. Android uses this to find it
		
        public static void Main() 
        {
			Ui.RunOnUiThread(()=>
			{
				var lay = new LinearLayout();
				btnTakePicture = lay.AddButton(true);
				lblImagePath = lay.AddTextView();
				imgThumbnail = lay.AddImageView(false, false, Android.Views.GravityFlags.CenterHorizontal);

				btnTakePicture.Text = "Take a picture";
				btnTakePicture.Click += delegate
				{
					try
					{
						TakePicture();
					}
					catch(Exception ex)
					{
						MessageBox.ShowDialog(ex.Message);
					}
				};
				imgThumbnail.Click += delegate
				{
					try
					{
						OpenImage(imageURI);
					}
					catch(Exception ex)
					{
						MessageBox.ShowDialog(ex.Message);
					}
				};
				
				Ui.OnActivityResult += OnActivityResult;
				
				lay.Show();
			});
        }
		
		public static void TakePicture()
		{
			var takePictureIntent = new Intent(MediaStore.ActionImageCapture);
			var imageFile = CreateImageFile();
			imagePath = imageFile.AbsolutePath;
			if ( Android.OS.Build.VERSION.SdkInt >= BuildVersionCodes.N)
			{
				//Android >= 7
				imageURI = Android.Support.V4.Content.FileProvider.GetUriForFile(Ui.Context, Ui.Context.PackageName + ".fileprovider", imageFile);
				takePictureIntent.AddFlags(ActivityFlags.GrantReadUriPermission);
			}
			else
			{
				//Android < 7
				imageURI =  Uri.FromFile(imageFile);
			}
			
			//Give the URI of the file we want the picture to be saved to.
            takePictureIntent.PutExtra(MediaStore.ExtraOutput, imageURI);
			
			Ui.StartActivityForResult(takePictureIntent, REQUEST_IMAGE_CAPTURE);
			
		}
		
		static File CreateImageFile()
		{
			// Create an image file name
			var imageFileName = DateTime.Now.ToString("yyyyMMddHHmmss");
			var storageDir = new File(Environment.ExternalStorageDirectory, Environment.DirectoryPictures);
			var image = File.CreateTempFile(
				imageFileName,  /* prefix */
				".jpg",         /* suffix */
				storageDir      /* directory */
			);

			// Save a file: path for use with ACTION_VIEW intents
			return image;
		}
		
		
		//This function is called when the launched intent returns with a result
		static void OnActivityResult(int requestCode, Result resultVal, Intent data)
		{
			if (requestCode == REQUEST_IMAGE_CAPTURE && resultVal == Result.Ok) 
			{
				try
				{
					if (data == null)
					{
						
						var img = BitmapFactory.DecodeFile(imagePath);
						img = Bitmap.CreateScaledBitmap(img, 200, 200, false);
						imgThumbnail.SetImageBitmap(img);
						lblImagePath.Text = imagePath;
						return;
					}			
					var extras = data.Extras;
					var imageBitmap = (Bitmap)extras.Get("data");
					imgThumbnail.SetImageBitmap(imageBitmap);
					lblImagePath.Text = imagePath;
				}
				catch(Exception ex)
				{
					MessageBox.Show(ex.ToString());
				}
			}
		}
		
		static void OpenImage(Uri uri)
		{
		    var intent = new Intent();
		    intent.SetAction(Intent.ActionView);
		    intent.SetData(uri);
		    intent.SetType("image/*");
		    Ui.StartActivity(intent);
		}
		
    }
}