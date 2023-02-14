using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_ClassesStructuresEtc
{
    class Program
    {
        ////////////////////////////////////System.Object//////////////////////////////////////////
        internal class ObjectExample
        {

        }
        internal class ObjectOverrideExample
        {
            //static variable is used in our example
            //as global counter for all objects of 
            //type ObjectOverrideExample
            private static int ObjectsCounter = 0;

            private string m_InternalString;
            private int m_OrderNumber;

            public int OrderNumber
            {
                get { return m_OrderNumber; }
                set { m_OrderNumber = value; }
            }
            public string InternalString
            {
                get { return m_InternalString; }
                set { m_InternalString = value; }
            }

            public ObjectOverrideExample()
            {
                m_InternalString = " Private string";
                ObjectsCounter++;
                m_OrderNumber = ObjectsCounter;
            }
            public override string ToString()
            {
                //here in addition to the full name of the type
                //that System.Object returns we add the value
                //of string member
                return base.ToString() + m_InternalString;
            }
            public override int GetHashCode()
            {
                //instead of HashCode that is implemented
                //in System.Object we return their order
                //number that we give to each object while
                //its creation
                return m_OrderNumber;
            }
            public override bool Equals(object obj)
            {
                if (obj == null) return false;
                //check if input object is of type ObjectOverrideExample
                //if so then we compare not that both references point
                //to same object but we compare order numbers
                if (obj.GetType().FullName == "_03_ClassesStructuresEtc.Program+ObjectOverrideExample")
                {
                    ObjectOverrideExample temp = (ObjectOverrideExample)obj;
                    if (m_OrderNumber != temp.OrderNumber) 
                    {
                        return false;
                    }
                    return true;
                }
                //if input object is of different type we compare
                //that both objects reference the same memory i.e. use
                //parent algorithm
                return base.Equals(obj);
            }
        }
        //////////////////////////REFERENCE TYPES AND VALUE TYPES/////////////////////////////////
        //value types
        internal enum eMyNumbers
        {
            ONE = 1,
            TWO,
            THREE
        }
        internal struct ExampleStructure 
        {
            //public ExampleStructure(); - this line will not compile
            private int m_intValue;
            private string m_stringValue;

            public int IntValue
            {
                get { return m_intValue; }
                set { m_intValue = value; }
            }
            public string StringValue
            {
                get { return m_stringValue; }
                set { m_stringValue = value; }
            }
        }
        //reference types
        internal class ExampleClass 
        {
            private int m_intValue = 0;
            private string m_StringValue = "default class value";

            public int IntValue
            {
                get { return m_intValue; }
                set { m_intValue = value; }
            }
            public string StringValue
            {
                get { return m_StringValue; }
                set { m_StringValue = value; }
            }
        }
        ////////////////////////////////////TYPE CASTING//////////////////////////////////////////
        internal class ParentClass
        {
            public virtual void OutputFunction(string s = "")
            {
                Console.WriteLine("OutputFunction in ParentClass" + s);
            }
        }
        internal class ChildClass_Level1 : ParentClass
        {
            //ChildClass_Level1 overrides base class function
            //to have its own implementation
            public override void OutputFunction(string s = "")
            {
                Console.WriteLine("OutputFunction in ChildClass_Level1" + s);
            }
        }
        internal class ChildClass_Level2 : ChildClass_Level1
        {
            //ChildClass_Level2 overrides base class function
            //to have its own implementation
            public override void OutputFunction(string s = "")
            {
                Console.WriteLine("OutputFunction in ChildClass_Level2" + s);
            }
        }
        ////////////////////////////////////DESIGNING TYPES//////////////////////////////////////////
        //internal keyword means that class if visible only inside current assembly
        internal class DemonstratingType
        {
            //Constant member that is equal to all objects
            //of the class and is not changeable
            public const int const_digit = 5;
            //static field that is equal to all objects
            //and related to type not to object
            private static string m_StaticString;
            //read only field
            //it can be changed only in constructor
            public readonly int ReadOnlyDigit;
            //static property that wraps static string
            public static string StaticString
            {
                get { return DemonstratingType.m_StaticString; }
                set { DemonstratingType.m_StaticString = value; }
            }
            //not static filed that is unique for each
            //object and related to object not to type
            private string m_InstanceString;
            //instance property that wraps instance field
            public string InstanceString
            {
                get { return m_InstanceString; }
                set { m_InstanceString = value; }
            }
            protected string m_ProtectedInstanceString;

            //+ operator overloading
            public static string operator+ (DemonstratingType obj1, DemonstratingType obj2)
            {
                return obj1.m_InstanceString + obj2.m_InstanceString;
            }

            //type constructor
            static DemonstratingType() 
            {
                m_StaticString = "static string default value";
            }
            //default constructor
            public DemonstratingType() 
            {
                m_ProtectedInstanceString = "default value for protected string";
                ReadOnlyDigit = 10;
            }
            //parametrized overloaded constructor
            public DemonstratingType(string InstanceStringInitialValue)
            {
                m_InstanceString = InstanceStringInitialValue;
                m_ProtectedInstanceString = "default value for protected string";
                ReadOnlyDigit = 10;
            }
            //static method that is called on type
            public static int SummarizeTwoDigits(int a, int b) 
            {
                return a + b;
            }
            //instance method that is called on object
            public int MyDigitPlustTypeConstant(int digit)
            {
                return digit + const_digit;
            }
            public string ShowProtectedString()
            {
                return m_ProtectedInstanceString;
            }
            //nested type
            private class InternalDataClass
            {
                private int m_x;
                private int m_y;
                public InternalDataClass(int x, int y)
                {
                    m_x = x;
                    m_y = y;
                }
            }
        }
        //class DerivedDemonstratedType derives DemonstratingType
        //this is called inheritance
        internal sealed class DerivedDemonstratingType : DemonstratingType 
        {
            //this function changes protected string that we
            //derived from parent type in our sample only 
            //derived class may change protected string
            public void ChangeProtectedString(string newString)
            {
                m_ProtectedInstanceString = newString;
            }
        } 
        static void Main(string[] args)
        {
            #region OBJECT
            ////////////////////////////////////System.Object//////////////////////////////////////////
            Console.WriteLine("-----------------System.Object-------------------");
            ObjectOverrideExample OverrideSample = new ObjectOverrideExample();
            Console.WriteLine(OverrideSample.ToString());//prints "_03_ClassesStructuresEtc.Program+ObjectOverrideExample Private string"
            ObjectExample Sample = new ObjectExample();
            Console.WriteLine(Sample.ToString());//prints "_03_ClassesStructuresEtc.Program+ObjectExample"
            //GetHashCode
            Console.WriteLine(Sample.GetHashCode());
            Console.WriteLine(OverrideSample.GetHashCode());//prints 1
            for (int i = 0; i < 10; i++) //prints numbers from 2 to 11
            {
                ObjectOverrideExample tmp = new ObjectOverrideExample();
                Console.WriteLine(tmp.GetHashCode());
            }
            //Equals
            ObjectOverrideExample tmp2 = new ObjectOverrideExample();
            Console.WriteLine(OverrideSample.Equals(tmp2));//prints true
            ObjectOverrideExample tmp3 = OverrideSample;
            Console.WriteLine(OverrideSample.Equals(tmp3));//prints true
            //GetType
            Type OverrideType = OverrideSample.GetType();
            Console.WriteLine(OverrideType.FullName);//prints "_03_ClassesStructuresEtc.Program+ObjectOverrideExample"
            Console.WriteLine(OverrideType.Name); //prints "ObjectOverrideExample"
            Type SampleType = Sample.GetType();
            Console.WriteLine(SampleType.FullName);//prints "_03_ClassesStructuresEtc.Program+ObjectExample"
            Console.WriteLine(SampleType.Name); //prints "ObjectExample"

            #endregion

            #region REFERENCE_TYPES_VALUE_TYPES
            //////////////////////////REFERENCE TYPES AND VALUE TYPES/////////////////////////////////
            Console.WriteLine("-----------------REFERENCE TYPES AND VALUE TYPES-------------------");
            eMyNumbers enumSample = eMyNumbers.THREE;

            //explicit default constructor is called
            ExampleStructure structValue = new ExampleStructure();//stored in stack
            structValue.IntValue = 5;//changes in stack
            structValue.StringValue = " sample string";//changes in stack
            //copying on assignment operator below
            //creates new structure in stack and copies there all values
            ExampleStructure structValue2 = structValue;
            Console.WriteLine(structValue.IntValue + structValue.StringValue); //prints "5 sample string"
            Console.WriteLine(structValue2.IntValue + structValue2.StringValue); //prints "5 sample string"
            Console.WriteLine(Object.ReferenceEquals(structValue, structValue2));//prints false

            ExampleClass classSample = new ExampleClass();//stored in heap
            classSample.IntValue = 5;//changes in heap
            classSample.StringValue = " sample string";
            ExampleClass classSample2 = classSample;//copies only reference
            Console.WriteLine(classSample.IntValue + classSample.StringValue); //prints "5 sample string"
            Console.WriteLine(classSample2.IntValue + classSample2.StringValue); //prints "5 sample string"
            Console.WriteLine(Object.ReferenceEquals(classSample, classSample2));//prints true

            object o = (object)structValue;//boxing
            structValue2 = (ExampleStructure)o;//unboxing
            #endregion

            #region TYPE_CASTING
            ////////////////////////////////////TYPE CASTING//////////////////////////////////////////
            Console.WriteLine("-----------------TYPE CASTING-------------------");
            //implicit conversion from child to parent, no special syntax is needed
            ParentClass parent = new ParentClass();
            parent.OutputFunction();//prints "OutputFunction in ParentClass"
            ParentClass parent_child1 = new ChildClass_Level1();
            parent_child1.OutputFunction();//prints "OutputFunction in ChildClass_Level1"
            ParentClass parent_child2 = new ChildClass_Level2();
            parent_child2.OutputFunction();//prints "OutputFunction in ChildClass_Level2"
            //explicit conversion to cast back to derived type
            ChildClass_Level2 child2 = (ChildClass_Level2)parent_child2;
            child2.OutputFunction();//prints "OutputFunction in ChildClass_Level2"
            ChildClass_Level1 child1 = (ChildClass_Level1)parent_child1;
            child1.OutputFunction();//prints "OutputFunction in ChildClass_Level1"
            //the code below compiles, but fails in runtime
            try 
            {
                child2 = (ChildClass_Level2)parent;
                child2.OutputFunction();
            }
            catch (InvalidCastException e)
            {
                Console.WriteLine("Catch invalid cast exception : " + e.Message);
            }
            //to avoid exception above we can use following code and is operator
            if (parent is ChildClass_Level2) 
            {
                parent.OutputFunction();//we never reach here
            }
            if(parent_child2 is ChildClass_Level2)
            {
                parent_child2.OutputFunction(" using is");//prints "OutputFunction in ChildClass_Level2 using is"
            }
            //is operator can be replaced by as operator
            child2 = parent as ChildClass_Level2;
            if (child2 != null)
            {
                child2.OutputFunction();//we never reach here
            }
            child2 = parent_child2 as ChildClass_Level2;
            if (child2 != null)
            {
                child2.OutputFunction(" using as");//prints "OutputFunction in ChildClass_Level2 using as"
            }
            #endregion

            #region DESIGNING_TYPES
            ////////////////////////////////////DESIGNING TYPES//////////////////////////////////////////
            Console.WriteLine("-----------------DESIGNING TYPES-------------------");
            //default constructor
            DemonstratingType object1 = new DemonstratingType();
            DemonstratingType object2 = new DemonstratingType();
            //static field and static property
            Console.WriteLine(DemonstratingType.StaticString);//prints "static string default value"
            DemonstratingType.StaticString = "this is the static string";
            Console.WriteLine(DemonstratingType.const_digit);//prints 5
            Console.WriteLine(DemonstratingType.StaticString);//prints "this is the static string"
            //instance field and instance property
            object1.InstanceString = "object 1 string";
            object2.InstanceString = " object 2 string";
            Console.WriteLine(object1.InstanceString);//prints "object 1 string"
            Console.WriteLine(object2.InstanceString);//prints " object 2 string"
            //operator overloading
            Console.WriteLine(object1 + object2);//prints "object 1 string object 2 string"
            //parametrized overloaded constructor
            DemonstratingType object3 = new DemonstratingType("object 3 string");
            Console.WriteLine(object3.InstanceString);//prints "object 3 string"
            //static method
            Console.WriteLine(DemonstratingType.SummarizeTwoDigits(2 , 3));//prints 5
            //instance method
            Console.WriteLine(object3.MyDigitPlustTypeConstant(5));//prints 10
            //inheritance example + protected string example
            DerivedDemonstratingType childType = new DerivedDemonstratingType();
            //object1 will reference to same object that childType
            object1 = childType;
            Console.WriteLine(object1.ShowProtectedString());//prints "default value for protected string"
            childType.ChangeProtectedString("new value for protected string");
            Console.WriteLine(object1.ShowProtectedString());//prints "new value for protected string"
            #endregion
        }
    }
}
