using System;

namespace ImplementationOfHashTables
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Implementation of Hashtables using LinkedList");
            MyMapNode<string, string> hash = new MyMapNode<string, string>(5);
            hash.Add("0", "To");
            hash.Add("1", "Be");
            hash.Add("2", "Or");
            hash.Add("3", "Not");
            hash.Add("4", "To");
            hash.Add("5", "Be");

            Console.WriteLine(hash.GetV("5"));
            Console.WriteLine(hash.GetV("0"));
            
            
        }
    }
}
