using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Reflection;

namespace _06_CustomAttributes
{
    class Program
    {
        //attribute DebuggerDisplay is used to show information about object of the
        //class while debugging once I will move mouse pointer to this object I will
        //see string that shows me the status of the object by sharing values of
        //string_status and int1 member variables
        [DebuggerDisplay("String status is={m_string_status}, second integer is: {m_int2}")]
        internal class AttributesSampleClass
        {
            private int m_int1 = 1;
            [DebuggerBrowsable(DebuggerBrowsableState.Never)]//using this attribute value of Int2 property will not be shown in debugger
            private int m_int2 = 2;
            private string m_string_status;

            [Obsolete("This method is obsolete, use ConsolseOutput2 instead")]//having this attribute we will have compiler warning when trying to use this method
            public void ConsoleOutput1()
            {
                Console.WriteLine("Output 1");
            }
            [DebuggerStepThrough]//this parameter says that debugger shouldn't step in this function
            public void ConsoleOutput2()
            {
                Console.WriteLine("Output 2");
            }
            public AttributesSampleClass() 
            {
            }
            //attribute flags indicates that numeration can be treated as a bit field
            [Flags]
            public enum EnumFlags 
            {
                Flag1 = 1,
                Flag2 = 2,
                Flag3 = 4,
                Flag4 = 8,
                Flag5 = 16,
                Flag6 = 32
            }
            [DebuggerNonUserCode]
            [DllImport("User32.dll")]// this attribute from System.Runtime.InteropServices gives
                                     // us ability to load SetForegroundWindow from User32.dll
            public static extern int SetForegroundWindow(IntPtr point);
        }


        [AttributeUsage(AttributeTargets.All,Inherited=false, AllowMultiple=false)]//I want my attribute to be applied to anything where it is possible - AttributeTargets.All
                                                                                  //also my attribute can be inherited - Inherited=true
                                                                                  //also my attribute can't be applied several times for one element - AllowMultiple=false
        public sealed class MyOwnExcitingAttribute : System.Attribute
        {
            private string m_StringData;
            private int m_IntegerData;

            public MyOwnExcitingAttribute()
            {
                m_StringData = "default value";
            }
            public MyOwnExcitingAttribute(string s)
            {
                m_StringData = s;
            }
            public int IntegerData
            {
                get { return m_IntegerData; }
                set { m_IntegerData = value; }
            }
            public string StringData
            {
                get { return m_StringData; }//we encapsulate only reading, you can set this variable only in constructor
            }
        }
        public class AttributeUser
        {
            [MyOwnExciting("custom value applied to function", IntegerData = 5)]
            public void FunctionThatDoSomething()
            {
            }
            [MyOwnExciting("custom value applied to member", IntegerData = 10)]
            public int m_IntData;
            [MyOwnExciting(IntegerData = 10)]//here string data will have "default value"
            public int m_IntData2;
        }
        public class NotAttributeUser
        {
        }

        public static void Main(string[] args)
        {
            //SAMPLE
            Console.WriteLine("------------------SAMPLE---------------------");
            AttributesSampleClass sample = new AttributesSampleClass();
            sample.ConsoleOutput1();//when I call it like this i have warning while building the project, but code executes
            sample.ConsoleOutput2();//works well

            //CUSTOM ATTRIBUTES
            AttributeUser user = new AttributeUser();
            //check if attribute is applied
            if (user.GetType().IsDefined(typeof(MyOwnExcitingAttribute), false))
            {
                Console.WriteLine("Attribute is defined");
            }
            NotAttributeUser not_user = new NotAttributeUser();
            //check if attribute is applied
            if (not_user.GetType().IsDefined(typeof(MyOwnExcitingAttribute), false))
            {

            }
            else 
            {
                Console.WriteLine("Attribute is not defined");
            }
            //reflection
            var members = from m in typeof(AttributesSampleClass).GetTypeInfo().DeclaredMembers select m;
            foreach (MemberInfo m in members)
            {
                ShowAttributes(m);
            }
            var members2 = from m2 in typeof(AttributeUser).GetTypeInfo().DeclaredMembers select m2;
            foreach (MemberInfo m2 in members2)
            {
                ShowAttributes(m2);
            }
        }

        public static void ShowAttributes(MemberInfo member)
        {
            var attributes = member.GetCustomAttributes<Attribute>();//getting all attributes for specific member
            Console.WriteLine(member.Name + " attributes are:");
            foreach (Attribute at in attributes)
            {
                Console.WriteLine("Attribute type is: " + at.GetType().ToString());
                if (at is MyOwnExcitingAttribute)
                {
                    Console.WriteLine("String data is: " + ((MyOwnExcitingAttribute)at).StringData);
                    Console.WriteLine("int data is: " + ((MyOwnExcitingAttribute)at).IntegerData);
                }
            }
        }
    }
}
