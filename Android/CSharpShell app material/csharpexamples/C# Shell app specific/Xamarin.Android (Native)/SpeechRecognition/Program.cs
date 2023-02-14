/* In depth information about common action intents
https://developer.android.com/guide/components/intents-common
*/

using System;
using Android.Speech;
using Android.App;
using Android.Content;

namespace CSharp_Shell
{

    public static class Program 
    {
		static readonly int VOICE = 10;
		static Button btnRecognize;
		static TextView lblSpeech;		
		
        public static void Main() 
        {
			Ui.RunOnUiThread(()=>
			{		
				var lay = new LinearLayout();
				btnRecognize = lay.AddButton(true);
				lblSpeech = lay.AddTextView();
				
				btnRecognize.Text = "Recognize speech";
				btnRecognize.Click += delegate
				{
					try
					{
						SpeechRecognition();
					}
					catch(Exception ex)
					{
						MessageBox.Show(ex.Message);
					}
				};
				Ui.OnActivityResult += OnActivityResult;
				
				lay.Show();
			});
           
        }
		
		public static void SpeechRecognition()
		{
			// create the intent and start the activity
			var voiceIntent = new Intent(RecognizerIntent.ActionRecognizeSpeech);
			voiceIntent.PutExtra(RecognizerIntent.ExtraLanguageModel, RecognizerIntent.LanguageModelFreeForm);

			// put a message on the modal dialog
			//voiceIntent.PutExtra(RecognizerIntent.ExtraPrompt, Application.Context.GetString(Resource.String.messageSpeakNow));

			// if there is more then 1.5s of silence, consider the speech over
			voiceIntent.PutExtra(RecognizerIntent.ExtraSpeechInputCompleteSilenceLengthMillis, 1500);
			voiceIntent.PutExtra(RecognizerIntent.ExtraSpeechInputPossiblyCompleteSilenceLengthMillis, 1500);
			voiceIntent.PutExtra(RecognizerIntent.ExtraSpeechInputMinimumLengthMillis, 15000);
			voiceIntent.PutExtra(RecognizerIntent.ExtraMaxResults, 1);

			// you can specify other languages recognised here, for example
			// voiceIntent.PutExtra(RecognizerIntent.ExtraLanguage, Java.Util.Locale.German);
			// if you wish it to recognise the default Locale language and German
			// if you do use another locale, regional dialects may not be recognised very well

			voiceIntent.PutExtra(RecognizerIntent.ExtraLanguage, Java.Util.Locale.Default);
			Ui.StartActivityForResult(voiceIntent, VOICE);
		}
		
		
		//This function is called when the launched intent returns with a result
		static void OnActivityResult(int requestCode, Result resultVal, Intent data)
		{
			if (requestCode == VOICE && resultVal == Result.Ok)
			{
				var matches = data.GetStringArrayListExtra(RecognizerIntent.ExtraResults);
				if (matches.Count != 0)
				{
					string textInput = matches[0];
					lblSpeech.Text = textInput;
				}
			}
		}
    }
}