using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace _07_Reflection
{
    [AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = false)]//I want my attribute to be applied to anything where it is possible - AttributeTargets.All
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
        [MyOwnExciting("custom value applied to constructor", IntegerData = 2)]
        public AttributeUser()
        {
        }
        [MyOwnExciting("custom value applied to function", IntegerData = 5)]
        public void FunctionThatDoSomething()
        {
        }
        [MyOwnExciting("custom value applied to member", IntegerData = 10)]
        public int m_IntData;
        [MyOwnExciting(IntegerData = 10)]//here string data will have "default value"
        private int m_IntData2;

        public int IntData2
        {
            get { return m_IntData2; }
            set { m_IntData2 = value; }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //-------------------------------------ASSEMBLY------------------------------
            Assembly currentAssembly = Assembly.GetExecutingAssembly();
            //properties
            Console.WriteLine(currentAssembly.CodeBase);//shows assembly binary file path
            //below I output only data about my own attribute applied for this assembly (look for AssemblyInfo.cs)
            var customAttributes = currentAssembly.CustomAttributes;
            foreach(CustomAttributeData attribute in customAttributes)
            {
                string s = attribute.AttributeType.GetType().Name;
                if (attribute.AttributeType == typeof(MyOwnExcitingAttribute))
                {
                    Console.WriteLine(attribute.AttributeType);
                    Console.WriteLine(attribute.Constructor);
                    Console.WriteLine(attribute.ConstructorArguments);
                    Console.WriteLine(attribute.NamedArguments);
                }
            }
            //below I read all types defined in my assembly
            Console.WriteLine("\n Assemblies types are: " + currentAssembly.EntryPoint);
            var definedTypes = currentAssembly.DefinedTypes;
            foreach (Type t in definedTypes)
            {
                Console.WriteLine("Type namespace = " + t.Namespace);
                Console.WriteLine("Type name = " + t.Name);
                Console.WriteLine("Is type public =" + t.IsPublic);
            }
            //outputs entry point
            Console.WriteLine("\n Assembly entry point = " + currentAssembly.EntryPoint);
            //below I read all types that are exported by my assembly
            Console.WriteLine("\n Assemblies types that are exported are: ");
            var exportedTypes = currentAssembly.ExportedTypes;
            foreach (Type t in exportedTypes)
            {
                Console.WriteLine("Type namespace = " + t.Namespace);
                Console.WriteLine("Type name = " + t.Name);
                Console.WriteLine("Is type public =" + t.IsPublic);
            }
            //below I read all types that are exported by my assembly
            Console.WriteLine("\n Assembliy loaded only for reflection: " + currentAssembly.ReflectionOnly);

            //below I read all modules in my assembly
            Console.WriteLine("\n Assemblies modules are: ");
            var modules = currentAssembly.Modules;
            Module myModule = null;
            foreach (Module m in modules)
            {
                Console.WriteLine("Scope name = " + m.ScopeName);
                Console.WriteLine("Type name = " + m.Name);
                Console.WriteLine("Assembly =" + m.Assembly);
                myModule = m;
            }
            //-------------------------------------MODULE------------------------------
            Console.WriteLine("Module's assembly is: " + myModule.Assembly);
            customAttributes = myModule.CustomAttributes;
            foreach (CustomAttributeData attribute in customAttributes)
            {
                    Console.WriteLine(attribute.AttributeType);
                    Console.WriteLine(attribute.Constructor);
                    Console.WriteLine(attribute.ConstructorArguments);
                    Console.WriteLine(attribute.NamedArguments);
            }
            Console.WriteLine("Module's fully qualified name is: " + myModule.FullyQualifiedName);
            Console.WriteLine("Module's name: " + myModule.Name);
            Console.WriteLine("Module's scope name: " + myModule.ScopeName);

            //i'm looking for specific type in my module
            var queriedType = myModule.GetType("_07_Reflection.AttributeUser");
            if (queriedType != null)
            {
                Console.WriteLine(queriedType.FullName);
            }

            //-------------------------------------TYPE------------------------------
            Console.WriteLine("------------DISCOVERING TYPE: " + queriedType.Name + "-----------------");
            Console.WriteLine("--Constructors details");
            var constructorsInfo = queriedType.GetConstructors();
            foreach (ConstructorInfo ci in constructorsInfo)
            {
                Console.WriteLine("Name = " + ci.Name);
                Console.WriteLine("Member type = " + ci.MemberType);
                Console.WriteLine("Is virtual = " + ci.IsVirtual);
                Console.WriteLine("Is static = " + ci.IsStatic);
                Console.WriteLine("Is public = " + ci.IsPublic);
            }
            Console.WriteLine("--Methods details");
            var methodsInfo = queriedType.GetMethods();
            foreach (MethodInfo mi in methodsInfo)//here we can see also methods derieved from System.Object
            {
                Console.WriteLine("Name = " + mi.Name);
                Console.WriteLine("Member type = " + mi.MemberType);
                Console.WriteLine("Is virtual = " + mi.IsVirtual);
                Console.WriteLine("Is static = " + mi.IsStatic);
                Console.WriteLine("Is public = " + mi.IsPublic);
            }
            Console.WriteLine("--Fields details");
            var fieldsInfo = queriedType.GetFields();//here we can see only public fields
            foreach (FieldInfo fi in fieldsInfo)
            {
                Console.WriteLine("Name = " + fi.Name);
                Console.WriteLine("Member type = " + fi.MemberType);
                Console.WriteLine("Is static = " + fi.IsStatic);
                Console.WriteLine("Is public = " + fi.IsPublic);
            }
            Console.WriteLine("--Properties details");
            var propInfo = queriedType.GetProperties();
            foreach (PropertyInfo pi in propInfo)
            {
                Console.WriteLine("Name = " + pi.Name);
                Console.WriteLine("Member type = " + pi.MemberType);
                Console.WriteLine("Can read = " + pi.CanRead);
                Console.WriteLine("Can write = " + pi.CanWrite);
            }
            //-------------------------------------INSTATIATING------------------------------
            Console.WriteLine("------------INSTANTIATING TYPE: -----------------");
            Console.WriteLine("--System.Activator.CreateInstnce");
            var Instance1 = System.Activator.CreateInstance(queriedType);
            Console.WriteLine(Instance1.GetType().FullName);
            var Instance2 = constructorsInfo[0].Invoke(null);
            Console.WriteLine(Instance2.GetType().FullName);

        }
    }
}
