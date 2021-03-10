using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
namespace OOKP_Lab1._2
{
    class Program
    {
        static void Main(string[] args)
        {
            ImmutableClass immutableClass = new ImmutableClass ("John");
            ImmutableClass immutableClass1 = new ImmutableClass("Tom");
            ImmutableClass immutableClass2 = new ImmutableClass("John");

            Console.WriteLine(immutableClass.Equals(immutableClass1));
            Console.WriteLine(immutableClass.Equals(immutableClass2));

            Console.WriteLine(immutableClass.GetHashCode());
            Console.WriteLine(immutableClass1.GetHashCode());
            Console.WriteLine(immutableClass2.GetHashCode());


            ImmutableClass immutableClass3 = immutableClass.Clone() as ImmutableClass;
            Console.WriteLine(immutableClass.Name);
            Console.WriteLine(immutableClass3.Name);

                
            List<ImmutableClass> people = new List<ImmutableClass>();
            people.Add(new ImmutableClass("John"));
            people.Add(new ImmutableClass("Tom"));
            people.Add(new ImmutableClass("Alex"));
            people.Add(new ImmutableClass("Rina"));
            people.Add(new ImmutableClass("Vova"));
            Console.WriteLine("**************");
            people.Sort();
            foreach (ImmutableClass a in people)
            {
                Console.WriteLine(a);
            }
            immutableClass.Serializble();
            Console.ReadKey();
        }
    }
}

