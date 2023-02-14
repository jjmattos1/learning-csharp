using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_Exceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int i = 0;
                Console.WriteLine(1/i);//division by 0 causes exception
            }
            catch(Exception e)
            {
                Console.WriteLine("Exception help link is: " + e.HelpLink);
                Console.WriteLine("Exception HReult is: " + e.HResult);
                Console.WriteLine("Exception message is: " + e.Message);
                Console.WriteLine("Exception source is: " + e.Source);
                Console.WriteLine("Exception stack trace is: " + e.StackTrace);
                Console.WriteLine("Exception target site i: " + e.TargetSite);
                Console.WriteLine();
            }
            try 
            {
                //out of range
                char[] arr = new char[5];
                char c = arr[6];
            }
            catch(IndexOutOfRangeException e)
            {
                Console.WriteLine("Out of range catch with message: " + e.Message);
            }
            try 
            {
                //null reference
                object o = null;
                o.ToString();
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine("Null reference catch with message: " + e.Message);
            }
            try
            {
                //argument null exception
                string s = null;
                "somestring".Contains(s);
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("Argument null catch with message: " + e.Message);
            }
        }
    }
    class CSample
    {
        void SampleFunction()
        {
            try
            {
                //code that may raise exception and need to be revovered\cleaned up
            }
            catch (AccessViolationException av)
            {
                //code to recovery from AccessViolationException
            }
            catch (UnauthorizedAccessException ua)
            {
                //code to recovery from UnauthorizedAccessException
            }
            catch
            {
                //code to recovery from all other exception types
            }
            finally
            {
                //code that will be executed forever and that will do cleaning up
            }
        }
    }
}
