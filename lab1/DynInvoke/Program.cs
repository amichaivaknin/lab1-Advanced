using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynInvoke
{
    internal class A
    {
        public string Hello(string input)
        {
            return "Hello "+input;
        }
    }

    internal class B
    {
        public string Hello(string input)
        {
            return "Bonjour " + input;
        }
    }

    internal class C
    {
        public string Hello(string input)
        {
            return "Nihau " + input;
        }
    }

    class Program
    {
        private static string InvokeHello(object obj, string str)
        {
            Type[] input = { typeof(string)};
            var invoke = obj.GetType().GetMethod("Hello", input);
            var output = (string)invoke.Invoke(obj,new object[] {str});
            return output;
        }

        static void Main(string[] args)
        {
            A a = new A();
            B b = new B();
            C c = new C();
    
            Console.WriteLine(InvokeHello(a,"Amichai"));
            Console.WriteLine(InvokeHello(b, "Amichai"));
            Console.WriteLine(InvokeHello(c, "Amichai"));
        }
    }
}
