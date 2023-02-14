using System;

namespace CSharp_Shell
{
	public static class Program
	{
		//Assignment 6. Three digit
		//Write a program that prints out all natural three digit numbers
		//which have a sum of their digits equal to an inputed number.
		//Input number in interval [2, 27]
		//Input                       Output
		//24                          699 789 798 879 888 897 969 978 987 996
		//26                          99 989 998

		public static int num = 0;

		public static bool sumChecker(int n)
		{
			int sum = 0;
			//Convert the number to string
			string strNum = Convert.ToString(n);

			for (int i = 0; i < strNum.Length; i++)
			{
				 //Interpret a char as integer using ASCII code.
				//ASCII code 48 equals the number 0
				sum += strNum[i] - 48;
			}

			return sum == num;
		}

		public static void Main()
		{


			
		}
	}
}


