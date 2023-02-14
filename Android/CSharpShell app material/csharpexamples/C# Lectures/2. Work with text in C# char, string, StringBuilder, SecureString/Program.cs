using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_WorkWithText
{
    class Program
    {
        static void Main(string[] args)
        {
            ////////////////////////////////////CHAR//////////////////////////////////////////
            Console.WriteLine("-----------------------CHAR---------------------");
                //declare char value and assign to it value of character literal
                char cVar = 's';
                Console.WriteLine("Code of character s = " + (int)cVar);//prints 115
                //declare char value and assign to it value converted from integer
                char cVar1 = (char)115;
                //declare char value and assign to it value converted from hexadecimal sequence
                char cVar2 = '\x0073';
                //declare char value and assign to it value converted from unicode sequence
                char cVar3 = '\u0073';
                //in all cases the character literal is s
                Console.WriteLine("cVar=" + cVar + " cVar1=" + cVar1 + " cVar2=" + cVar2 + " cVar3=" + cVar3 +"\n");

                Console.WriteLine(char.GetUnicodeCategory('c'));        //lower case letter
                Console.WriteLine(char.GetUnicodeCategory('C'));        //upper case letter
                Console.WriteLine(char.GetUnicodeCategory('$'));        //currency symbol
                Console.WriteLine(char.GetUnicodeCategory(','));        //punctuation symbol
                Console.WriteLine(char.GetUnicodeCategory('+') + "\n"); //math symbol

                Console.WriteLine(char.ToUpperInvariant('s')); //gives S
                Console.WriteLine(char.ToLowerInvariant('P')); //gives p
                Console.WriteLine(char.ToLowerInvariant('p')); //gives p
                Console.WriteLine(char.ToLowerInvariant('Ф')); //gives ф
                Console.WriteLine(char.ToLower('Ф'));          //gives ф

                Console.WriteLine(char.GetNumericValue('s')); //gives -1
                Console.WriteLine(char.GetNumericValue('4')); //gives 4

                Console.WriteLine(char.Equals('s','s'));         //gives true
                Console.WriteLine(char.Equals('s', 'p'));        //gives false
                Console.WriteLine(char.Equals('s', 'S') + "\n"); //gives false

            //////////////////////STRING////////////////////////////////
            Console.WriteLine("-----------------------STRING---------------------");
            Console.WriteLine("--DEFINITION");
            //DEFINITION
            //simplest way of string instantiation
            string s = "This is the string";
            //following definitions are equal
            s = @"C:\Windows\Sysem32\notepad.exe";
            string s1 = "C:\\Windows\\Sysem32\\notepad.exe";
            //alternative ways of instantiation by char array and char pointer
            char[] charArray = {'s','d','s','d','s','a'};
            s1 = new string(charArray);
            Console.WriteLine(s1);
            string s2 = "dfdefsd";
            unsafe
            {
                fixed (char* pChar = s2)
                {
                    string s3 = new string(pChar);
                    Console.WriteLine(s3);
                }
            }
            string s4 = string.Copy(s1);//instantiates s7 with s1 content
            Console.WriteLine(s4); //true
            s4 = (string)s1.Clone();//returns reference to s1 object
            Console.WriteLine(Object.ReferenceEquals(s4, s1)); //true
            s2 = s4.ToString();//returns reference to s4 object
            Console.WriteLine(Object.ReferenceEquals(s2, s1)); //true

            //INTERTING
            Console.WriteLine("--INTERNING");
            s = string.Intern(s);
            Console.WriteLine("Is interned: " + string.IsInterned(s));//returns the string if it is there
            Console.WriteLine("Is interned: " + string.IsInterned(s1));//returns empty string
            string s5 = "Hello";
            string s6 = new StringBuilder().Append("He").Append("llo").ToString();
            Console.WriteLine(Object.ReferenceEquals(s5, s6)); //false
            s5 = string.Intern(s5);
            s6 = string.Intern(s6);
            Console.WriteLine(Object.ReferenceEquals(s5, s6)); //true

            //CONCATENATION
            Console.WriteLine("--CONCATENATION");
            //string concatenation using + operator done at literal strings
            //this is good we have the result added to module metadata while
            //compilation time
            s = "String1 " + "String2 ";
            Console.WriteLine(s);//prints "String1 String2 "
            //using this way of concatenation we will have the operation itself
            //done at runtime and it creates additional strings in memory
            s1 = "String3 ";
            s = s + s1;
            Console.WriteLine(s);//prints "String1 String2 String3"
            s = string.Concat("test1", " test2", " test3");
            Console.WriteLine(s);//prints "test1 test2 test3"
            List<int> iList = new List<int>();
            for(int i = 0; i< 10; i++)
            {
                iList.Add(i);
            }
            s = string.Concat(iList);
            Console.WriteLine(s);//prints "0123456789"
            //using Join we may group elements of array
            string[] array = { "one", "two", "three"};
            s = string.Join("||", array);
            Console.WriteLine(s);//prints "one||two||three"

            //COMPARISION
            Console.WriteLine("--COMPARISION");
            s = "String";
            s1 = "String";
            //the result will be 0, it means that first string is in the same sort position as
            //second in alphabetical sort order
            Console.WriteLine(string.Compare(s,s1));
            Console.WriteLine(s.Equals(s1));//returns true;
            s = "A String";
            s1 = "B String";
            Console.WriteLine(string.Compare(s, s1).ToString() + s.CompareTo(s1).ToString());//returns -1
            Console.WriteLine(s.Equals(s1));//returns false;
            s = "C String";
            Console.WriteLine(string.Compare(s, s1).ToString() + s.CompareTo(s1).ToString());//returns 1
            s1 = "c string";
            Console.WriteLine(string.Compare(s, s1, true).ToString());//returns 0
            Console.WriteLine(s.CompareTo(s1).ToString());//returns -1
            Console.WriteLine(s.Equals(s1,StringComparison.Ordinal));//returns false;
            Console.WriteLine(s.Equals(s1,StringComparison.OrdinalIgnoreCase));//returns true;

            //CHARACTERS AND SUBSTRINGS
            Console.WriteLine("--CHARACTERS AND SUBSTRINGS");
            s = "string that contains substring";
            s1 = "substring";
            Console.WriteLine(s.Contains(s1));//prints true
            Console.WriteLine(s.Contains("asdfds"));//prints false
            char[] destination = new char[6];
            s.CopyTo(0, destination, 0, 6);//copies word "string" to output char array
            Console.WriteLine(destination);          //prints "string"
            Console.WriteLine(s.EndsWith("dsas"));   //prints false
            Console.WriteLine(s.EndsWith("ring"));   //prints true
            Console.WriteLine(s.StartsWith("dsas")); //prints false
            Console.WriteLine(s.StartsWith("str"));  //prints true
            Console.WriteLine(s.IndexOf("that"));    //prints 7
            Console.WriteLine(s.IndexOf("rerwe"));   //prints -1
            Console.WriteLine(s.LastIndexOf("in"));  //prints 27
            Console.WriteLine(s.LastIndexOf("qqq")); //prints -1
            char[] search_chars = { 'i' };
            Console.WriteLine(s.IndexOfAny(search_chars));     //prints 3
            Console.WriteLine(s.LastIndexOfAny(search_chars)); //prints 27
            char[] search_chars1 = { 'q' };
            Console.WriteLine(s.IndexOfAny(search_chars1));     //prints -1
            Console.WriteLine(s.LastIndexOfAny(search_chars1)); //prints -1
            char[] split_char = { ' ' };
            string[] out_strings = s.Split(split_char);
            foreach (string splitted in out_strings) //prints all the words from s separately
            {
                Console.WriteLine(splitted);
            }
            string[] split_string = { "in" };
            out_strings = s.Split(split_string,StringSplitOptions.None);
            foreach (string splitted in out_strings) //prints all the words from s separately but without "in"
            {
                Console.WriteLine(splitted);
            }
            s = "very important string";
            Console.WriteLine(s.Substring(5));   //prints "important string"
            Console.WriteLine(s.Substring(5,9)); //prints "important"
            Console.WriteLine(s.Remove(5));      //prints "very "
            Console.WriteLine(s.Remove(5, 2));   //prints "very portant string"

            //FORMATTING
            Console.WriteLine("--FORMATTING");
            //string.format builds output string from different objects
            s = string.Format("First argument is: {0} and second argument is {1}", 10, 11);//creates new string
            Console.WriteLine(s);//prints "First argument is 10 and second argument is 11"
            s = string.Format("Persents are: {0:0.0%}", 0.75);//creates new string
            Console.WriteLine(s);//prints "Persents are: 75.0%"
            DateTime date = new DateTime(2015, 10, 5);
            TimeSpan time = new TimeSpan(15, 15, 30);
            decimal temp = 10.5m;
            s = String.Format("Temperature on {0:d} at {1,10} is {2} degrees", date, time, temp);
            Console.WriteLine(s);//prints "Temperature on 10/5/2015 at   15:15:30 is 10.5 degrees"
            s = "one plus";
            s = s.Insert(8, " one");
            Console.WriteLine(s);//prints "one plus one"
            //returns new string which is build from input string but all letters are upper case
            //using casting rules of current culture
            s = "some string";
            s1 = s.ToUpper();
            Console.WriteLine(s1);//prints "SOME STRING"
            //returns new string which is build from input string but all letters are lower case
            //using casting rules of current culture
            s = s1.ToLower();//prints "some string"
            Console.WriteLine(s);
            //returns new string which is build from input string but all letters are upper case
            //using casting rules of invariant culture
            s1 = s.ToUpperInvariant();
            Console.WriteLine(s1);//prints "SOME STRING"
            //returns new string which is build from input string but all letters are lower case
            //using casting rules of invariant culture
            s = s1.ToLower();
            Console.WriteLine(s);//prints "some string"
            s = "    string    with      extra     whitespaces      ";
            char[] split_chars = { 's', 't', 'r', 'c', 'e', ' ' };
            Console.WriteLine(s.Trim());            //returns "string    with      extra     whitespaces"
            Console.WriteLine(s.TrimStart());       //returns "string    with      extra     whitespaces     "
            Console.WriteLine(s.TrimEnd());         //returns "    string    with      extra     whitespaces"
            Console.WriteLine(s.Trim(split_chars)); //returns "ing    with      extra     whitespa"
            s = "some string";
            //returns new string that is left aligned and adds whitespaces if needed to achieve expected length
            Console.WriteLine(s.PadLeft(15));
            Console.WriteLine(s.Replace('s','S'));      //prints "Some String"
            Console.WriteLine(s.Replace("str", "STR")); //prints "some STRing"

            //OTHER
            Console.WriteLine("--OTHER");
            Console.WriteLine(s.Length);//prints 11
            char[] chArray = s4.ToCharArray();//initializes char array by string content
            s = null;
            Console.WriteLine(string.IsNullOrEmpty(s));      //true
            Console.WriteLine(string.IsNullOrWhiteSpace(s)); //true
            s = "  ";
            Console.WriteLine(string.IsNullOrEmpty(s));      //false
            Console.WriteLine(string.IsNullOrWhiteSpace(s)); //true
            s = "sss";
            Console.WriteLine(string.IsNullOrEmpty(s));      //false
            Console.WriteLine(string.IsNullOrWhiteSpace(s)); //false

            //////////////////////STRING BUILDER////////////////////////////////
            Console.WriteLine("-----------------------STRING BUILDER---------------------");
            //INITIALIZATION AND PROPERTIES
            Console.WriteLine("--INITIALIZATION AND PROPERTIES");

            StringBuilder sb = new StringBuilder();        //default constructor
            sb = new StringBuilder(25);                     //constructor with suggested capacity
            sb = new StringBuilder("input string");         //constructor with string
            sb = new StringBuilder(25, 225);                //constructor with suggested and maximum capacity
            sb = new StringBuilder("some string",20);       //constructor with string and suggested capacity
            sb = new StringBuilder("some string", 0, 4, 20);//constructor with string where we take its part from index and for specific length plus suggested capacity
            Console.WriteLine(sb.ToString());//prints "some"

            Console.WriteLine(sb.Capacity);    //prints 20
            Console.WriteLine(sb.MaxCapacity); //prints 2147483647
            Console.WriteLine(sb.Length);      //prints 4

            //METHODS
            Console.WriteLine("--METHODS");
            sb = new StringBuilder();
            sb.Append(1);
            sb.Append('s');
            sb.Append(" some string data ");
            sb.Append(true);
            sb.Append('\t');
            Object o = new Object();
            sb.Append(o);
            sb.Append('\t');
            sb.Append(123.435345);
            Console.WriteLine(sb.ToString());//prints "1s some string data True        System.Object   123,435345"
            sb.Clear();
            sb.AppendFormat("Appends first digit: {0} and second bool: {1}", 123, false);
            Console.WriteLine(sb.ToString());// ptints "Appends first digit: 123 and second bool: False"
            sb.Clear();
            sb.Append("first line");
            sb.AppendLine();
            sb.Append("second line");
            Console.WriteLine(sb.ToString());//prints two strings in separate lines
            sb.Clear();
            sb.AppendLine("first line");
            sb.Append("second line");
            Console.WriteLine(sb.ToString());//output and results is equal as for example above
            char[] cArray = new char[5];
            sb.CopyTo(0, cArray, 0, 5);
            Console.WriteLine(cArray);//prints "first"
            Console.WriteLine(sb.EnsureCapacity(5));//prints 64 that is current capacity of the string
            Console.WriteLine(sb.EnsureCapacity(105));//prints 105 that is current capacity of the string
            try
            {
                sb.EnsureCapacity(int.MaxValue);//raises OutOfMemoryException
            }
            catch (System.OutOfMemoryException) 
            {
                Console.WriteLine("We catch exception because tried to create StringBuilder object that exceeds maximum size");
            }
            sb.Clear();
            sb.Insert(0, "first ");
            sb.Insert(6, "second ");
            sb.Insert(13, true);
            sb.Insert(17, " ");
            sb.Insert(18, 123.2435d);
            Console.WriteLine(sb.ToString());//prints "first second True 123,2435"
            try
            {
                sb.Insert(121, "");//raises ArgumentOutOfRangeException
            }
            catch (System.ArgumentOutOfRangeException)
            {
                Console.WriteLine("We catch exception because tried to insert to StringBuilder object for a position that exceeds array size");
            }
            sb.Remove(18, 7);
            Console.WriteLine(sb.ToString());//prints "first second True 5"
            sb.Replace('5', '!');
            Console.WriteLine(sb.ToString());//prints "first second True !"
            sb.Replace("fir", "FIR");
            Console.WriteLine(sb.ToString());//prints "FIRst second True !"
        }
    }
}
