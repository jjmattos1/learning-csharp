
//This is a calculator using Mono.CSharp.Evaluator to evaluate expressions

using System;
using System.Text.RegularExpressions;
using System.IO;
using Mono.CSharp;
using Android.Widget;
using Android.Content;
using Android.Views.InputMethods;
using System.Threading.Tasks;
using NativeUiLib; //This adds the UI controls

namespace CSharp_Shell
{

    public static class Program 
    {
        static Evaluator evaluator;
        static StringWriter sw; //Results and errors are printed here
		static string evalCodeStart = "public static class Calc { public static void Eval(){ result=";
		static EditText txtDisplay; //calculator display/result line
		static TextView lblError; //calculator evaluation error line
		static LinearLayout layNumpad;
		static LinearLayout layArithmetics;
		
        public static void Main() 
        {
		   var layMain = new LinearLayout(); //Primary layout
		   layMain.Orientation = Orientation.Vertical;   
		   txtDisplay = layMain.AddEditText(true); 
		   txtDisplay.Click += txtDisplay_Click;
		   lblError = layMain.AddTextView(true);
		   var hpx = Ui.Context.Resources.DisplayMetrics.HeightPixels * 0.1;
		   txtDisplay.SetMinHeight((int)hpx);
		   
		   
           var layHor = new LinearLayout(); //This layout will contains 2 others
           layHor.Orientation = Orientation.Horizontal;   
		   layMain.AddView(layHor); //Add to primary layout

           layNumpad = GenerateNumpad();
		   layArithmetics = GenerateArithmetics();
           
           layHor.AddView(layNumpad);
		   layHor.AddView(layArithmetics);
		   
		   
		   //Set layNumpad and layArithmetics to take up a specific percantage of space
		   var np= new LinearLayout.LayoutParams(0, LinearLayout.LayoutParams.WrapContent);
		   np.Weight = 0.85f;//Take up 85% of parent layout (parent layout is width=fill_parent)
		   layNumpad.LayoutParameters = np;
		   
		   var ap= new LinearLayout.LayoutParams(0, LinearLayout.LayoutParams.WrapContent);
		   ap.Weight = 0.25f; //Take up 25% of parent layout
		   layArithmetics.LayoutParameters = ap;
		   
		   
           layMain.Show(); //Show primary layout
           txtDisplay_Click(null, null);//Hide keyboard popup
           
        }
		
		//Hide the keyboard on click
		private static async void txtDisplay_Click(object sender, EventArgs args)
		{
			var im = ((InputMethodManager)Ui.Context.GetSystemService(Context.InputMethodService));
			await Task.Delay(10); //Hiding keyboard doesn't work without a delay
			im.HideSoftInputFromWindow(txtDisplay.WindowToken, Android.Views.InputMethods.HideSoftInputFlags.None);
		}
        
        private static LinearLayout GenerateNumpad()
        {
			//This layout is basically a table with 6 rows and 3 columns			
            var linNum = new LinearLayout();
            linNum.Orientation = Orientation.Vertical;

            var linRow1 = new LinearLayout();
			linRow1.Orientation = Orientation.Horizontal;
            linRow1.AddView(NewCalcButton("1"));
			linRow1.AddView(NewCalcButton("2"));
			linRow1.AddView(NewCalcButton("3"));
			
			var linRow2 = new LinearLayout();
			linRow2.Orientation = Orientation.Horizontal;
            linRow2.AddView(NewCalcButton("4"));
			linRow2.AddView(NewCalcButton("5"));
			linRow2.AddView(NewCalcButton("6"));
			
			var linRow3 = new LinearLayout();
			linRow3.Orientation = Orientation.Horizontal;
            linRow3.AddView(NewCalcButton("7"));
			linRow3.AddView(NewCalcButton("8"));
			linRow3.AddView(NewCalcButton("9"));
			
			var linRow4 = new LinearLayout();
			linRow4.Orientation = Orientation.Horizontal;
            linRow4.AddView(NewCalcButton("0"));
			linRow4.AddView(NewCalcButton("."));
			linRow4.AddView(NewCalcButton("="));
			
			var linRow5 = new LinearLayout();
			linRow5.Orientation = Orientation.Horizontal;
            linRow5.AddView(NewCalcButton("("));
			linRow5.AddView(NewCalcButton(")"));
			linRow5.AddView(NewCalcButton("%"));
			
			var linRow6 = new LinearLayout();
			linRow6.Orientation = Orientation.Horizontal;
            linRow6.AddView(NewCalcButton("sqrt"));
			linRow6.AddView(NewCalcButton("pow"));
			linRow6.AddView(NewCalcButton("mod"));
            
            linNum.AddView(linRow1);
			linNum.AddView(linRow2);
			linNum.AddView(linRow3);
			linNum.AddView(linRow4);
			linNum.AddView(linRow5);
			linNum.AddView(linRow6);
			
            return linNum;
        }
		
		private static LinearLayout GenerateArithmetics()
		{
			var linArth = new LinearLayout();
			linArth.Orientation = Orientation.Vertical;
			
			linArth.AddView(NewCalcButton("+"));	
			linArth.AddView(NewCalcButton("-"));	
			linArth.AddView(NewCalcButton("*"));	
			linArth.AddView(NewCalcButton("/"));
			linArth.AddView(NewCalcButton("DEL"));
			linArth.AddView(NewCalcButton("CLR"));
			return linArth;
		}
        
		//Helper method for adding buttons to the calculator
        private static Button NewCalcButton(string text)
        {
           var btn = new Button(); 
           btn.Text = text;
           btn.Click += PerformButtonAction;
           return btn;
        }
        
		
		//Decide what to do when a button is pressed
        private static void PerformButtonAction(object sender, EventArgs args)
        {
            var btn = (Button)sender;
			if (btn.Text == "=") Task.Run(()=> Calculate(txtDisplay.Text));
			else if (btn.Text == "CLR")
			{
			    txtDisplay.Text = string.Empty;
			    lblError.Text=string.Empty;
			}
			else if (btn.Text == "DEL") //Remove character at cursor
			{
				if (txtDisplay.Text.Length == 0) return;
			    var ind = txtDisplay.SelectionStart;
			    txtDisplay.Text = txtDisplay.Text.Remove(ind - 1, 1);
			    txtDisplay.SetSelection(--ind);
			}
			else
			{
				var text = btn.Text;
				var ind = txtDisplay.SelectionStart;
				if (text == "pow") text = "pow(,)";
				else if (text == "sqrt") text = "sqrt()";
			    else if (text == "mod") text = "mod()";
				
			    txtDisplay.Text = txtDisplay.Text.Insert(ind, text);
			    txtDisplay.SetSelection(ind + text.Length);
			}
        }
		
		
		private static void Calculate(string expr)
		{
			try
			{
			    InitEvaluator();
			    
				//Convert shorthand pseudo-methods into real ones
				expr = expr.Split('=')[0];
				expr = expr.Replace("pow", "Math.Pow");
				expr = expr.Replace("sqrt", "Math.Sqrt");
				expr = expr.Replace("mod", "Math.Abs");
				
				var ok = evaluator.Run(evalCodeStart + expr + ";}}"); //Create evaluation class
				if (!ok) throw new ApplicationException(sw.ToString());
				ok = evaluator.Run("Calc.Eval()"); //Start evaluatuion
				if (!ok || !string.IsNullOrWhiteSpace(sw.ToString())) 
				{
					//throw exception due to evaluation error.
				    throw new ApplicationException(sw.ToString());
				}
				//Show the result
				Ui.RunOnUiThread(()=>
				{
				  txtDisplay.Text = txtDisplay.Text.Split('=')[0] + "=" + GetEvalResult();
				  txtDisplay.SetSelection(txtDisplay.Text.Length);
				  lblError.Text = string.Empty;
				});
			}
			catch(Exception ex)
			{
				//Show the exception message
			    Ui.RunOnUiThread(()=>
			    {
			    	lblError.Text = ex.Message;
				    if (ex.InnerException != null)
				    {
				       lblError.Text +=  ex.InnerException.Message;
				    }
			    });
			}
		}
		
		//Get evaluator result variable and process it for display
		private static string GetEvalResult()
		{
			var errorRegex = @"\((\d*),\s*(\d*)\):(.*)";
			var res = evaluator.GetVars().Replace("object result = ", string.Empty).Trim();
			if (Regex.IsMatch(res,  errorRegex))
			{
				var offset = evalCodeStart.Length +  "using System;\nobject result;".Length;
				var matches = Regex.Matches(res, errorRegex);
				res = string.Empty;
				foreach (Match match in matches)
				{
					var pos = int.Parse(match.Groups[2].Value) - offset;
					var error = match.Groups[3].Value;
					res += $"{pos}: {error}";
				}
			}
			
			return res;
		}
		
		private static void InitEvaluator()
		{
		   sw = new StringWriter();
           var setting = new CompilerSettings();
           var pr = new ConsoleReportPrinter(sw);
           var ctx = new CompilerContext(setting, pr);
           evaluator = new Evaluator(ctx);
			
		   evaluator.Run("using System;"); //We probably need this
		   evaluator.Run("object result;"); //Result variable, very important.
		}
    }
}