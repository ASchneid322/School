using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICA12ExtensionMethod
{
    class Program
    {
        public static Random _rnd = new Random();
        static void Main(string[] args)
        {
            List<int> iNums = new List<int>(new int[] { 4, 12, 4, 3, 5, 6, 7, 6, 12 });
            foreach (KeyValuePair<int, int> scan in iNums.Categorize())
                Console.WriteLine(scan.Key.ToString("d3") + " x " + scan.Value.ToString("d5"));            Console.WriteLine();            List<string> names = new List<string>(new string[] {
                "Rick", "Glenn", "Rick", "Carl", "Michonne", "Rick", "Glenn" });
            foreach (KeyValuePair<string, int> scan in names.Categorize())
                Console.WriteLine(scan.Key + " x " + scan.Value.ToString("d5"));            Console.WriteLine();            LinkedList<char> llfloats = new LinkedList<char>();

            while (llfloats.Count < 1000)
                llfloats.AddLast((char)_rnd.Next('A', 'Z' + 1));
            foreach (KeyValuePair<char, int> scan in llfloats.Categorize())
                Console.Write(scan.Key + " x " + scan.Value.ToString("d5")+" - ");
            Console.WriteLine();
            Console.WriteLine("-------------");

            string TestString = "This is the test string, do not panic!";
            foreach (KeyValuePair<char, int> scan in TestString.Categorize())
                Console.Write(scan.Key + " x " + scan.Value.ToString("d5")+" - ");
            Console.WriteLine();

            Console.ReadKey();            Console.WriteLine();

            iNums = new List<int>(new int[] { 4, 12, 4, 3, 5, 6, 7, 6, 12 });            Console.WriteLine(iNums.Popular());            names = new List<string>(new string[] {
                "Rick", "Glenn", "Rick", "Carl", "Michonne", "Rick", "Glenn" });            Console.WriteLine(names.Popular());            llfloats = new LinkedList<char>();
            while (llfloats.Count < 1000)
                llfloats.AddLast((char)_rnd.Next('A', 'Z' + 1));
            Console.WriteLine(llfloats.Popular());

            TestString = "This is the test string, do not panic!";
            Console.WriteLine(TestString.Popular());


            Console.ReadKey();            Console.WriteLine();

            iNums = new List<int>(new int[] { 4, 12, 4, 3, 5, 6, 7, 6, 12 });
            foreach (int scan in iNums.Shuffle())
                Console.Write(scan.ToString("d3")+" ");            Console.WriteLine();            names = new List<string>(new string[] {
                "Rick", "Glenn", "Rick", "Carl", "Michonne", "Rick", "Glenn" });
            foreach (string scan in names.Shuffle())
                Console.Write(scan+" ");            Console.WriteLine();            llfloats = new LinkedList<char>();
            while (llfloats.Count < 1000)
                llfloats.AddLast((char)_rnd.Next('A', 'Z' + 1));
            foreach (char scan in llfloats.Shuffle())
                Console.Write(scan);
            Console.WriteLine();

            TestString = "This is the test string, do not panic!";
            foreach (char scan in TestString.Shuffle())
                Console.Write(scan);
            Console.WriteLine();

            Console.ReadKey();            Console.WriteLine();
        }
    }
}
