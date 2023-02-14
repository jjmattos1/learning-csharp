using System;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using AndroidHtmlUi;

namespace CSharp_Shell
{

    public class Program 
    {
        public static void Main() 
        {
           int i=0;
           var lay = new TableLayout();
           var lbl = lay.AddLabel("mylabel", 1, 1);
           lbl.Text = "Press button";
           lbl.Align = "right";
           var btn = lay.AddButton("mybutton", 1, 2);
           var chk = lay.AddCheckbox("chk", 3, 1);
           var date = lay.AddEditDate("date",4,1);
           var num = lay.AddSpinner("num",5,1);
           var color = lay.AddColorPicker("color",6,1);
           var time = lay.AddEditTime("time", 7,1);
           var cmb = lay.AddCombobox("combo",8,1);
		   var edit = lay.AddEditText("edit", 2, 2);
		   lay.AddLabel("lbl", 2,1, "Enter text: ");
		   var dgv = lay.AddDataGridView("dgv", 9, 1);
			
           cmb.Items.Add("555");
           cmb.Items.Add("666");
		   
           btn.Click += delegate
           {
             Console.WriteLine(1);
             cmb.SetEnabled(!cmb.GetEnabled());
             Console.WriteLine(2);
             btn.SetValue(i.ToString());
             Console.WriteLine(3);
             Console.WriteLine(btn.GetValue());
             chk.Checked = true;
             var d = date.GetValue<DateTime>();
             Console.WriteLine(d.GetType());
             Console.WriteLine(d);
             var n = num.GetValue<double>();
             Console.WriteLine(n.GetType());
             Console.WriteLine(n);
             var t = time.GetValue<DateTime>();
             Console.WriteLine(t.GetType());
             Console.WriteLine(t);
             Console.WriteLine(color.Color);
             i++;          
           };
           color.OnChange += (sdr, args) =>
           {
             Console.WriteLine(args.Value);
           };
          
          
          
           edit.OnChange += (sender, args) =>
           {
             Console.Write(args.Value);
           };
          
           
		  
           chk.ColSpan=2;  //Column span in the table layout
           chk.OnCheckedChange += (sender, args) =>
           {
             Console.WriteLine(args.Checked);
           };
		   
		   
		   //DataGridView
           var dt = new DataTable();
           dt.Columns.Add("column 1", typeof(int));
           dt.Rows.Add(4);
           dt.Rows.Add(6);
           dgv.DataSource = dt;
		   
           lay.Show();
        }
    }
}