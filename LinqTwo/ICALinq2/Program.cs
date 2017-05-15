using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ICALinq2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> sourcestrings = new List<string>(new string[] { "Caballo", "Gato", "Perro", "Conejo", "Tortuga", "Cangrejo" });            var ans = from n                       in sourcestrings
                      where n.Sum(c => c) < 600
                      select n;            ans.ToList().ForEach(s => Console.WriteLine(s));            Console.WriteLine();

            var ann2 = from n                        in sourcestrings
                       where n.Sum(c => c) < 600
                       select new { Str = n, Sum = n.Sum(c => c) };            ann2.ToList().ForEach(s => Console.WriteLine(s));            Console.WriteLine();

            var ann3 = from n                        in sourcestrings
                       where n.Sum(c => c) < 600
                       select new { Str = n, Sum = n.Sum(c => c) }                        into j
                            orderby j.Sum descending
                            select j;            ann3.ToList().ForEach(s => Console.WriteLine(s));            Console.WriteLine();            string filebits = File.ReadAllText(@"..\..\..\junk.txt");            var words = filebits.Split(new char[] {'\n', '\r'} );            var split = from n 
                        in words
                        where n.Trim().Length != 0
                        select n;
            var h = from n 
                    in split
                    group n by n.Sum(c=>c) 
                    into j
                    orderby j.Key
                    select j;

            Console.WriteLine("Lowest ASCII sum: " + h.ToList().First().Key);
            Console.WriteLine("Lowest string: " + h.ToList().First().Min());

            var highset = h.ToList().Last().Min();
            var sort = from n 
                       in highset
                       orderby n
                       select n;

            Console.WriteLine("Highest ASCII sum: " + h.ToList().Last().Key);
            Console.Write("Highest string: "+ highset + "/");
            sort.ToList().ForEach(s => Console.Write(s));

            Console.ReadKey();
        }
    }
}
