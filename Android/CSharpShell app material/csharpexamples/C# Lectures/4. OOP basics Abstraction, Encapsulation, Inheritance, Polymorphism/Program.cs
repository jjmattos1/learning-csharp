using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_OOP_Base
{
    class Program
    {
        ////////////////////////////////////ABSTRACTION//////////////////////////////////////////
        public abstract class Vegetable
        {
            public virtual bool DoINeedIrrigationNow(float LandTemperature, float AirHumidity, float LandHumidity){return false;}
            public void IrrigateMe() 
            {
                //here we call irrigation device to give water
            }
        }
        internal class Tomato : Vegetable
        {
            public bool DoINeedIrrigationNow(float LandTemperature, float AirHumidity, float LandHumidity) 
            {
                //here we have code that checks input parameters and returns result
                return true;
            }
        }
        internal class Cabbage : Vegetable
        {
            public bool DoINeedIrrigationNow(float LandTemperature, float AirHumidity, float LandHumidity)
            {
                //here we have code that checks input parameters and returns result
                return true;
            }
        }
        internal sealed class IrrigationSystem 
        {
            List<Vegetable> vegetables = new List<Vegetable>();
            public void IrrigationProcess()
            {
                //let's assume we already read configuration here and know
                //all the vegetables that we support and have irrigation 
                //devices connected to them
                float LandTemp = 0;
                float AirHumidity = 0;
                float LandHumitity = 0;
                foreach (Vegetable item in vegetables)
                {
                    //read values of specific controllers and path them to function
                    if (item.DoINeedIrrigationNow(LandTemp,AirHumidity, LandHumitity))
                    {
                        item.IrrigateMe();
                    }
                }
            }
        }
        ////////////////////////////////////ENCAPSULATION//////////////////////////////////////////
        internal sealed class CellPhone
        {
            private int m_CellNetworkConnectionQuality;//let's say it is integer from 1 to 10
            private int m_BatteryPercentage;           //shows in percents battery status from 1 to 100

            public bool CallToPerson(string PersonsCellPhone)
            {
                //calling and return true
                AddCallDataToLog();
                return true;
            }
            public bool StopCurrentCall()
            {
                //stopping and return true
                return true;
            }
            public bool AnswerInputCall()
            {
                //answering and return true
                AddCallDataToLog();
                return true;
            }
            public void GetPhoneStatus(out int NetworkStatus, out int BatteryStatus) 
            {
                NetworkStatus = m_CellNetworkConnectionQuality;
                BatteryStatus = m_BatteryPercentage;
            }
            private void AddCallDataToLog()
            {
                //adds call data to log
            }
        }
        ////////////////////////////////////INHERITANCE//////////////////////////////////////////
        internal class C
        {
            public void CMethod()
            {
                Console.WriteLine("I'm a method of class C");
            }
        }
        internal class B : C
        {
            public void BMethod()
            {
                Console.WriteLine("I'm a method of class B");
            }
        }
        internal sealed class A : B //class A can't be inherited as we declared it as sealed
        {
            public void AMethod()
            {
                Console.WriteLine("I'm a method of class A");
            }
        }

        internal class D : B 
        {
            protected void ProtectedMehodInD()
            {
                Console.WriteLine("I'm protected method of class D");
            }
            public virtual void VirtualMethodInD() 
            {
                Console.WriteLine("I'm default implementation of virtual method in D");
            }
            public new void BMethod()
            {
                Console.WriteLine("I'm a hidden B method of class B and reimplemented in class D");
            }
        }
        internal class E : D 
        {
            public void EMethod()
            {
                Console.WriteLine("I'm a method of class E ");
                ProtectedMehodInD();
            }
        }
        internal class F : D 
        {
            public override void VirtualMethodInD()
            {
                Console.WriteLine("I'm overridden implementation of virtual method in D");
            }
        }
        internal abstract class AbstractClass
        {
            public abstract void AbstractFunction();
        }
        internal interface Interface1
        {
            void Interface1Function();
        }
        internal interface Interface2
        {
            void Interface2Function();
        }
        //below we have one parent abstract class and implement two interfaces
        internal class AbstractAndInterfaceImplementation : AbstractClass, Interface1, Interface2 
        {
            public override void AbstractFunction()
            {
                Console.WriteLine("Abstract function implementation");
            }
            public void Interface1Function()
            {
                Console.WriteLine("Interface1Function function implementation");
            }
            public void Interface2Function()
            {
                Console.WriteLine("Interface2Function function implementation");
            }
        }
        ////////////////////////////////////POLYMORPHISM//////////////////////////////////////////
        internal class CBaseShape
        {
            public virtual void PaintMyself()
            {
                Console.WriteLine("I'm default implementation and don't paint anything");
            }
        }
        internal class Rhombus : CBaseShape
        {
            public override void PaintMyself()
            {
                Console.WriteLine("   *");
                Console.WriteLine("  ***");
                Console.WriteLine(" *****");
                Console.WriteLine("  ***");
                Console.WriteLine("   *");
            }
        }
        internal class Square : CBaseShape
        {
            public override void PaintMyself()
            {
                Console.WriteLine("  ****");
                Console.WriteLine("  ****");
                Console.WriteLine("  ****");
                Console.WriteLine("  ****");
            }
        }
        internal class Rectangle : CBaseShape
        {
            //public new void PaintMyself()
            public override void PaintMyself()
            {
                Console.WriteLine("  ********");
                Console.WriteLine("  ********");
                Console.WriteLine("  ********");
            }
        }


        static void Main(string[] args)
        {
            //INHERITANCE
            //transitive inheritance example
            A aVar = new A();
            aVar.AMethod();//prints "I'm a method of class A"
            aVar.BMethod();//prints "I'm a method of class B"
            aVar.CMethod();//prints "I'm a method of class C"

            //protected example
            E eVar = new E();
            //the code below will not compile as we can't see protected
            //methods here, but we can successfully use it inside class E implementation
            //eVar.ProtectedMehodInD(); - failed at compile time
            eVar.CMethod();//prints "I'm a method of class C"
            eVar.EMethod();//prints "I'm a method of class C" and "I'm protected method of class D"

            //use child classes in context of parent class
            C cVar = new A();
            cVar.CMethod();//prints "I'm a method of class C"
            cVar = new B();
            cVar.CMethod();//prints "I'm a method of class C"

            //hide base class member
            D dVar = new D();
            dVar.BMethod();//prints "I'm a hidden B method of class B and reimplemented in class D"

            //virtual functions
            dVar.VirtualMethodInD();//prints "I'm default implementation of virtual method in D"
            dVar = new E();
            dVar.VirtualMethodInD();//prints "I'm default implementation of virtual method in D"
            dVar = new F();
            dVar.VirtualMethodInD();//prints "I'm overridden implementation of virtual method in D"

            //abstract class and interface
            AbstractAndInterfaceImplementation classVar = new AbstractAndInterfaceImplementation();
            AbstractClass abstractVar = classVar;
            abstractVar.AbstractFunction();//prints "Abstract function implementation"
            Interface1 interface1Var = classVar;
            interface1Var.Interface1Function();//prints ""Interface1Function function implementation""
            Interface2 interface2Var = classVar;
            interface2Var.Interface2Function();//prints ""Interface2Function function implementation""

            //POLYMORPHISM
            bool bExit = true;
            Rectangle rect = new Rectangle();
            Rhombus romb = new Rhombus();
            Square sqr = new Square();
            while (bExit)
            {
                CBaseShape bs = new CBaseShape();

                Console.WriteLine(@"Type your choice or type 'exit' to stop");
                Console.WriteLine(@"Reminding you can see behavior of following figures: rhombus, square, rectangle");
                string line = Console.ReadLine();
                if (line == "exit") // Check string
                {
                    break;
                }
                //here we assume that classes as Rhombus, Rectangle and Square come to us from some
                //third party DLLs that we load while runtime
                switch (line) 
                {
                    case "rhombus":
                        bs = romb;
                        break;
                    case "square":
                        bs = sqr;
                        break;
                    case "rectangle":
                        bs = rect;
                        break;
                    default:
                        break;//doing nothing here
                }
                bs.PaintMyself();
            }
            //When we use new and when override
            //execute this code first time then go to
            //Rectangle class and change override to new
            //execute again and see for result
            CBaseShape[] t = new CBaseShape[3];
            t[0] = new Rhombus();
            t[1] = new Rectangle();
            t[2] = new Square();

            for (int i = 0; i < t.Length; i++)
            {
                t[i].PaintMyself();
            }

        }
    }
}
