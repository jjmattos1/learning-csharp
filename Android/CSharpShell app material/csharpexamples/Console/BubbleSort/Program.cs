using System;
namespace CSharp_Shell
{
	public class BubbleSort
	{
		public static void Main()
		{
			int[] a = { 6, 6, 2, 56, -15, 25, 9, 8, 11 , 5, 4, 1 };  
			int t;
			Console.WriteLine("The Array is : ");
			for (int i = 0; i < a.Length; i++)
			{
				Console.WriteLine(a[i]);
			}
			for (int j = 0; j <= a.Length - 2; j++)
			{
				for (int i = 0; i <= a.Length - 2; i++)
				{
					if (a[i] > a[i + 1])
					{
						t = a[i + 1];
						a[i + 1] = a[i];
						a[i] = t;
					}
				}
			}
			Console.WriteLine("Ascending: ");
			
			foreach (int aray in a) 
			{			
				Console.Write(aray + " ");
			}

		}
	}
}