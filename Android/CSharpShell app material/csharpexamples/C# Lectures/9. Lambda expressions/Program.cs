using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09_Lambda
{
    public delegate int MyDelegate(string s, int i);
    public delegate int SomeDelegate(int input);
    class Program
    {
        SomeDelegate m_del;
        static void Main(string[] args)
        {
            //---------------ANONYMOUS TYPES------------------------
            Console.WriteLine("-----------ANONYMOUS TYPES----------------");
            var anonym1 = new { int_val = 1, double_val = 0.11, string_val = "some string" };
            Console.WriteLine("anonym1 type is: " + anonym1.GetType());
            Console.WriteLine("double_val type is: " + anonym1.double_val.GetType());
            Console.WriteLine("int_val type is: " + anonym1.int_val.GetType());
            Console.WriteLine("string_val type is: " + anonym1.string_val.GetType());
            //another way to initialize anonymous type
            int i = 10;
            string s = "string value";
            var anonym2 = new { int_val = i, string_val = s };
            var anonym3 = new { i, s };
            var anonym4 = new { anonym2, anonym3 };

            //---------------LAMBDA EXPRESSIONS------------------------
            Console.WriteLine("-----------LAMBDA EXPRESSIONS----------------");
            //calling by delegate
            DelegateCaller(new MyDelegate(DelegateFunction));
            //creating lambda delegate
            MyDelegate del = (str, dig) =>
            {
                Console.WriteLine("Delegate lambda string: " + str + " int: " + dig);
                return 2;
            };
            DelegateCaller(new MyDelegate(del));

            //delegates variable scope
            Program test = new Program();
            test.ScopeExample();
            int k = test.m_del(10);
            Console.WriteLine("Delegate external result is: " + k);
        }
        public static void DelegateCaller(MyDelegate input)
        {
            int res = input("Delegate Caller", 5);
            Console.WriteLine("Delegate result is: " + res);
        }
        public static int DelegateFunction(string s, int i)
        {
            Console.WriteLine("Delegate function string: " + s + " int:" + i);
            return 1;
        }
        public void ScopeExample()
        {
            //local variable that will be hold for delegate
            //even after ScopeExample is running out of the
            //scope and released from memory
            int j = 5;
            m_del = (x) =>
            {
                Console.WriteLine("Input parameter is : " + x);
                Console.WriteLine("Local variable is: " + j);
                return j + x;
            };
            int i = m_del(5);
            Console.WriteLine("Delegate internal result is: " + i);
        }
    }
}
