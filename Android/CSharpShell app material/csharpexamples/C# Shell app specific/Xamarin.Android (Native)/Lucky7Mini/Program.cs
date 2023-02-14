//This example requires the 'Xamarin.Android GUI' option to be enabled
using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using NativeUiLib;  //This adds the UI controls

namespace CSharp_Shell
{

    public static class Program 
    {
        static int spins = 0;
        static Button btnNum1, btnNum2, btnNum3, btnPlay;
        public static void Main() 
        {
           var linMain = new LinearLayout();
           linMain.Orientation = Android.Widget.Orientation.Horizontal;
           
           btnNum1 = linMain.AddButton();
           btnNum1.Text="0";
                   
           btnNum2 = linMain.AddButton();
           btnNum2.Text="0";
           
           btnNum3 = linMain.AddButton();
           btnNum3.Text="0";
            
           var linPlay = new LinearLayout();
           linMain.AddView(linPlay);
                   
           btnPlay = linPlay.AddButton();
           btnPlay.Text="Spin";
           btnPlay.Click += btnPlay_Click;
           
           var btnSpinUntilWin = linPlay.AddButton();
           btnSpinUntilWin.Text = "Spin until win";
           btnSpinUntilWin.Click += btnSpinUntilWin_Click;
   
           linMain.Show();
        }
        
        static void btnPlay_Click(object sdr, EventArgs args)
        {
            var rand = new Random();
            btnNum1.Text = rand.Next(0, 9).ToString();
            btnNum2.Text = rand.Next(0, 9).ToString();
            btnNum3.Text = rand.Next(0, 9).ToString();
            spins++;
			
            if (btnNum1.Text == "7" && btnNum2.Text == "7" && btnNum3.Text == "7")
            {
                MessageBox.ShowAsync($"You win!\nTries: {spins}");
				spins=0;
            }
        }
        
        static async void btnSpinUntilWin_Click(object sdr, EventArgs args)
        {
            spins=0;
            var btn = (Button)sdr;
            btn.Enabled=false;
            while (btnNum1.Text != "7" || btnNum2.Text != "7" || btnNum3.Text != "7")
            {
                btnPlay.PerformClick();
                await Task.Delay(4);
            }
            btn.Enabled=true;
        }
    }
}