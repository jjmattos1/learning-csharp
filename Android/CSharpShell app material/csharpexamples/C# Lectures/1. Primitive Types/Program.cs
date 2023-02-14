//Note: I'm going to make a shorter version of this course into a type of interactive tutorial.
//For example this file would probably...
//- Show you a few types, then ask you to do something like get the max value of long.
//- Show you a comparison sizeof(byte) and sizeof(int), and ask you to print out the data size of long.
//- Show you a basic array and ask you to change the value of an element.
//Keep in mind that this interactive tutorial will only check the console output and not analyze the code itself.
//Which actually makes it less accurate and more easily cheatable.
//However, assuming you aren't cheating, that also means the underlying algorithm and code style you have can be anything and still be a valid solution.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValueTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-------------BOOL EXAMPLE------------- \n");
            //declare boolean variable and assign default value for it
            //you will see later that default value for bool is false
            //so we could avoid assigning it to false and simply define it as bool bVar;
            bool bVar = false;
            bVar = true;
            if (bVar)//here we use boolean value in conditional operator
            {
                Console.WriteLine("We are here because our boolean value is true");
                bVar = false;
            }
            if (!bVar)
            {
                Console.WriteLine("We are here because our boolean value is false");
            }
            Console.WriteLine("-------------CHAR EXAMPLE------------- \n");
            //declare char value and assign to it value of character literal
            char cVar = 's';
            Console.WriteLine("Code of character s = " + (int)cVar );
            //declare char value and assign to it value converted from integer
            char cVar1 = (char)115;
            //declare char value and assign to it value converted from hexadecimal sequence
            char cVar2 = '\x0073';
            //declare char value and assign to it value converted from unicode sequence
            char cVar3 = '\u0073';
            //in all cases the character literal is s
            Console.WriteLine("cVar=" + cVar + " cVar1=" + cVar1 + " cVar2=" + cVar2 + " cVar3=" + cVar3);

            //when we reach maximum value for char the nex one will be 0
            int i = char.MaxValue - 5;
            for (int j = 0; j < 7; j++)
            {
                cVar = (char)i;
                i++;
            }

            Console.WriteLine("-------------PRIMITIVE TYPES PROPERTIES------------- \n");
            //we need to call constructor for byte type here othervise compiler said that
            //we try to use unassigned local variable in next operator when print its value
            //it means compiler don't call constructor automatically and we need to assign
            //value to primitive type when we declare it and then plan to read from it
            //this can be done usig direct value: byte byteVar=2;
            byte byteVar = new byte();
            Console.WriteLine("byte type" +
                              " \n\t minimum value: " + byte.MinValue +
                              " \n\t maximum value: " + byte.MaxValue +
                              " \n\t default value for unassigned variable: " + byteVar +
                              " \n\t FCL type: " + byteVar.GetType() +
                              " \n\t size in bytes: " + sizeof(byte));

            sbyte sbyteVar = new sbyte();
            Console.WriteLine("sbyte type" +
                              " \n\t minimum value: " + sbyte.MinValue +
                              " \n\t maximum value: " + sbyte.MaxValue +
                              " \n\t default value for unassigned variable: " + sbyteVar +
                              " \n\t FCL type: " + sbyteVar.GetType() +
                              " \n\t size in bytes: " + sizeof(sbyte));

            int intVar = new int();
            Console.WriteLine("int type" +
                              " \n\t minimum value: " + int.MinValue +
                              " \n\t maximum value: " + int.MaxValue +
                              " \n\t default value for unassigned variable: " + intVar +
                              " \n\t FCL type: " + intVar.GetType() +
                              " \n\t size in bytes: " + sizeof(int));

            uint uintVar = new uint();
            Console.WriteLine("uint type" +
                              " \n\t minimum value: " + uint.MinValue +
                              " \n\t maximum value: " + uint.MaxValue +
                              " \n\t default value for unassigned variable: " + uintVar +
                              " \n\t FCL type: " + uintVar.GetType() +
                              " \n\t size in bytes: " + sizeof(uint));

            short shortVar = new short();
            Console.WriteLine("short type" +
                              " \n\t minimum value: " + short.MinValue +
                              " \n\t maximum value: " + short.MaxValue +
                              " \n\t default value for unassigned variable: " + shortVar +
                              " \n\t FCL type: " + shortVar.GetType() +
                              " \n\t size in bytes: " + sizeof(short));

            ushort ushortVar = new ushort();
            Console.WriteLine("ushort type" +
                              " \n\t minimum value: " + ushort.MinValue +
                              " \n\t maximum value: " + ushort.MaxValue +
                              " \n\t default value for unassigned variable: " + ushortVar +
                              " \n\t FCL type: " + ushortVar.GetType() +
                              " \n\t size in bytes: " + sizeof(ushort));

            long longVar = new long();
            Console.WriteLine("long type" +
                              " \n\t minimum value: " + long.MinValue +
                              " \n\t maximum value: " + long.MaxValue +
                              " \n\t default value for unassigned variable: " + longVar +
                              " \n\t FCL type: " + longVar.GetType() +
                              " \n\t size in bytes: " + sizeof(long));

            ulong ulongVar = new ulong();
            Console.WriteLine("ulong type" +
                              " \n\t minimum value: " + ulong.MinValue +
                              " \n\t maximum value: " + ulong.MaxValue +
                              " \n\t default value for unassigned variable: " + ulongVar +
                              " \n\t FCL type: " + ulongVar.GetType() +
                              " \n\t size in bytes: " + sizeof(ulong));

            float floatVar = new float();
            Console.WriteLine("float type" +
                              " \n\t minimum value: " + float.MinValue +
                              " \n\t maximum value: " + float.MaxValue +
                              " \n\t default value for unassigned variable: " + floatVar +
                              " \n\t FCL type: " + floatVar.GetType() +
                              " \n\t size in bytes: " + sizeof(float));

            double doubleVar = new double();
            Console.WriteLine("double type" +
                              " \n\t minimum value: " + double.MinValue +
                              " \n\t maximum value: " + double.MaxValue +
                              " \n\t default value for unassigned variable: " + doubleVar +
                              " \n\t FCL type: " + doubleVar.GetType() +
                              " \n\t size in bytes: " + sizeof(double));

            char charVar = new char();
            Console.WriteLine("char type" +
                              " \n\t minimum value: " + char.MinValue +
                              " \n\t maximum value: " + char.MaxValue +
                              " \n\t default value for unassigned variable: " + charVar +
                              " \n\t FCL type: " + charVar.GetType() +
                              " \n\t size in bytes: " + sizeof(char));

            bool boolVar = new bool();
            Console.WriteLine("bool type" +
                              " \n\t default value for unassigned variable: " + boolVar +
                              " \n\t FCL type: " + charVar.GetType() +
                              " \n\t size in bytes: " + sizeof(bool));

            object objectVar = new object();
            Console.WriteLine("object type" +
                              " \n\t default value for unassigned variable: " + objectVar +
                              " \n\t FCL type: " + objectVar.GetType());

            decimal decimalVar = new decimal();
            Console.WriteLine("decimal type" +
                              " \n\t minimum value: " + decimal.MinValue +
                              " \n\t maximum value = " + decimal.MaxValue +
                              " \n\t default value for unassigned variable: " + decimalVar +
                              " \n\t FCL type: " + decimalVar.GetType() +
                              " \n\t size in bytes: " + sizeof(decimal));

            //Is primitive
            bool bIsPrimitive = typeof(long).IsPrimitive;


            //OVERFLOW SAMPLE
            Console.WriteLine("\n\n\n -------------OVERFLOW-------------");
            byte v = 255;
            Console.WriteLine("Insert any positive value:");
            int c = Console.Read();
            //here we have value of byte that reached more than maximum value, but
            //the result is a new we didn't receive overflow exception since by default
            //compiler doesn't react to overflow for primitive types and not generate System.OverflowException
            //to add the check for oveflow you need to add "/checked+" to compiler command line
            byteVar = (byte)(v + c);
            Console.WriteLine("New byte is: " + byteVar);
            //we have also another way to make operation checked
            try 
            {
                byteVar = checked((byte)(v + c));
            }
            catch (OverflowException e) 
            {
                Console.WriteLine("Overflow exception catched: " + e.Message);
            }
        }
    }
}
 