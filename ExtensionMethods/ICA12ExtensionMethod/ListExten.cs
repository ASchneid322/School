using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICA12ExtensionMethod
{
    public static class ListExten
    {
        public static Dictionary<K, int> Categorize<K>(this IEnumerable<K> sourcelist)
        {
            Dictionary<K, int> newDict = new Dictionary<K, int>();
            //List to Dict
            foreach (K s in sourcelist)
            {
                if (newDict.ContainsKey(s)) {
                    newDict[s]++;
                }
                else
                {
                    newDict.Add(s, 1);
                }
            }
            //List order
            newDict = newDict.OrderBy((o) => (o.Key)).ToDictionary((p) => (p.Key), (p) => (p.Value));

            return newDict;
        }

        public static T Popular<T>(this IEnumerable<T> sourceEnum)
        {
            int popindex;
            int currentHigh = 0;
            T currentT = sourceEnum.First();
            foreach (T s in sourceEnum)
            {
                popindex = sourceEnum.Count((t) => t.Equals(s));
                if (popindex > currentHigh)
                {
                    currentHigh = popindex;
                    currentT = s;
                }
            }
            return currentT;
        }

        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> sourceEnum)
        {
            T temp;
            int rnd;
            Random rand = new Random();
            List<T> listy = sourceEnum.ToList();
            for(int i= listy.Count()-1; i>0; i--)
            {
                rnd = rand.Next(0, i);
                temp = listy[i];
                listy[i] = listy[rnd];
                listy[rnd] = temp;
            }
            return listy.AsEnumerable();
        }
    }
}
