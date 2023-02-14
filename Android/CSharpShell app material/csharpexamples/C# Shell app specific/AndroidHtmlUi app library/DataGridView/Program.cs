using System;
using System.Text;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using AndroidHtmlUi;

namespace CSharp_Shell
{

    public static class Program 
    {
        public static void Main() 
        {
           var frm = new TableLayout();
           var btn = frm.AddButton("btn", 1,1, "Change DataSource");
           
           var dt = new DataTable();
           dt.Columns.Add("column 1", typeof(string));
           dt.Columns.Add("col2", typeof(string));
           dt.Columns.Add("int", typeof(int));
           dt.Columns.Add("bool", typeof(bool));
           dt.Columns.Add("doubl", typeof(double));
           dt.Columns.Add("date field", typeof(DateTime));
           for (int i = 0; i<200; i++)
           {
             dt.Rows.Add(new object[] {"hello world", "tt", 5, true, 4.563, DateTime.Now});
             dt.Rows.Add(new object[] { "second row", "ft" , 4, false, 6, DateTime.Now});
           }
           var dgv = frm.AddDataGridView("dgv", 2, 1, dt);
           dt.RowChanged += (sdr, args) =>
           {
             var sb = new StringBuilder();
             foreach (var item in args.Row.ItemArray)
             {
              
               sb.AppendLine(item.ToString());
             }
             Console.WriteLine(sb);
           };
           btn.Click += delegate
           {
             var newdt = new DataTable();
             newdt.Columns.Add("somename", typeof(int));
             for (int i=0; i<100; i++)
             {
               newdt.Rows.Add(new object[]{i});
             }
             dgv.DataSource = newdt;
           };
           frm.Show();
        }
    }
}