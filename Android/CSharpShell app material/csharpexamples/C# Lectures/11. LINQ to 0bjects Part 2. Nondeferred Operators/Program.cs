using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11_LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            //LINQ TO OBJECTS
            string[] CarBrands = { "Mersedes", "Ford", "Lexus", "Toyota",
                                   "Honda", "Hyunday", "BMW", "KIA", "Chevrolet",
                                   "Tesla", "Lamborghini", "Ferrari", "Lincoln",
                                    "Cadillac"};
            Console.WriteLine("-----------------NONDEFERRED OPERATORS--------------------");
            Console.WriteLine("\n-----------------TOARRAY");
            List<string> Names = new List<string>();
            Names.Add("Sergey");
            Names.Add("Alexander");
            Names.Add("Maria");
            Names.Add("John");
            Names.Add("Bruce");
            Names.Add("Emily");
            Console.WriteLine("Names type = " + Names.GetType().ToString());
            var newNames = Names.ToArray();
            Console.WriteLine("newNames type = " + newNames.GetType().ToString());

            Console.WriteLine("\n-----------------TOLIST");
            Console.WriteLine("CarBrands type = " + CarBrands.GetType().ToString());
            var newCarBrands = CarBrands.ToList();
            Console.WriteLine("newCarBrands type = " + newCarBrands.GetType().ToString());

            Console.WriteLine("\n-----------------TODICTIONARY");
            Console.WriteLine("-----------------first version");
            Dictionary<int, string> outDict = CarBrands.ToDictionary(s => Array.IndexOf(CarBrands, s));
            foreach (var element in outDict)
            {
                Console.WriteLine("Key = " + element.Key + " Value = " + element.Value);
            }
            Console.WriteLine("-----------------second version");
            IntComparer comp = new IntComparer();
            outDict = CarBrands.ToDictionary(s => Array.IndexOf(CarBrands, s),comp);
            foreach (var element in outDict)
            {
                Console.WriteLine("Key = " + element.Key + " Value = " + element.Value);
            }
            Console.WriteLine("-----------------third version");
            Dictionary<int, int> dict = CarBrands.ToDictionary(s => Array.IndexOf(CarBrands, s),el => el.Length);
            foreach (var element in dict)
            {
                Console.WriteLine("Key = " + element.Key + " Value = " + element.Value);
            }
            Console.WriteLine("-----------------fourth version");
            dict = CarBrands.ToDictionary(s => Array.IndexOf(CarBrands, s), el => el.Length,comp);
            foreach (var element in dict)
            {
                Console.WriteLine("Key = " + element.Key + " Value = " + element.Value);
            }

            Console.WriteLine("\n-----------------TOLOOKUP");
            Console.WriteLine("-----------------first version");
            ILookup<int, string> outLook = CarBrands.ToLookup(s => Array.IndexOf(CarBrands, s));
            IEnumerable<string> car = outLook[4];
            foreach (var str in car)
            {
                Console.WriteLine("Fifth car is = " + str);
            }
            Console.WriteLine("-----------------second version");
            outLook = CarBrands.ToLookup(s => Array.IndexOf(CarBrands, s),comp);
            car = outLook[3];
            foreach (var str in car)
            {
                Console.WriteLine("Fourth car is = " + str);
            }
            Console.WriteLine("-----------------third version");
            ILookup<int, int> outLook2 = CarBrands.ToLookup(s => Array.IndexOf(CarBrands, s),el => el.Length);
            IEnumerable<int> carl = outLook2[4];
            foreach (var i in carl)
            {
                Console.WriteLine("Fifth car lengh is = " + i);
            }
            Console.WriteLine("-----------------fourth version");
            outLook2 = CarBrands.ToLookup(s => Array.IndexOf(CarBrands, s), el => el.Length,comp);
            carl = outLook2[3];
            foreach (var i in carl)
            {
                Console.WriteLine("Fourth car lengh is = " + i);
            }

            Console.WriteLine("\n-----------------SEQUENCEEQUAL");
            Console.WriteLine("-----------------first version");
            int[] seq1 = { 0, 5, 25 };
            int[] seq2 = { 0, 5, 25 };
            string[] Cars2 = { "Ford", "Acura"};
            Console.WriteLine(CarBrands.SequenceEqual(Cars2));//prints false
            Console.WriteLine(seq1.SequenceEqual(seq2));//prints true
            Console.WriteLine("-----------------second version");
            Console.WriteLine(seq1.SequenceEqual(seq2,comp));//prints true

            Console.WriteLine("\n-----------------FIRST");
            Console.WriteLine("-----------------first version");
            Console.WriteLine(CarBrands.First());//prints Merseds
            Console.WriteLine("-----------------second version");
            Console.WriteLine(CarBrands.First(s=>s.StartsWith("BM")));//prints BMW

            Console.WriteLine("\n-----------------FIRSTORDEFAULT");
            Console.WriteLine("-----------------first version");
            Console.WriteLine(CarBrands.FirstOrDefault());//prints Merseds
            string [] seqstr = {};
            try 
            {
                Console.WriteLine(seqstr.First());
            }
            catch (System.InvalidOperationException e) 
            {
                Console.WriteLine("Fisrt operator on empty sequence raises exception");
            }
            if(String.IsNullOrEmpty(seqstr.FirstOrDefault()))
            {
                Console.WriteLine("We got default value of string = null");
            }
            Console.WriteLine("-----------------second version");
            Console.WriteLine(CarBrands.FirstOrDefault(s => s.StartsWith("BM")));//prints BMW

            Console.WriteLine("\n-----------------LAST");
            Console.WriteLine("-----------------first version");
            Console.WriteLine(CarBrands.Last());//prints Cadillac
            Console.WriteLine("-----------------second version");
            Console.WriteLine(CarBrands.Last(s => s.StartsWith("L")));//prints Lincoln

            Console.WriteLine("\n-----------------LASTORDEFAULT");
            Console.WriteLine("-----------------first version");
            Console.WriteLine(CarBrands.LastOrDefault());//prints Cadillac
            try
            {
                Console.WriteLine(seqstr.Last());
            }
            catch (System.InvalidOperationException e)
            {
                Console.WriteLine("Last operator on empty sequence raises exception");
            }
            if (String.IsNullOrEmpty(seqstr.LastOrDefault()))
            {
                Console.WriteLine("We got default value of string = null");
            }
            Console.WriteLine("-----------------second version");
            Console.WriteLine(CarBrands.LastOrDefault(s => s.StartsWith("L")));//prints Lincoln

            Console.WriteLine("\n-----------------SINGLE");
            Console.WriteLine("-----------------first version");
            string[] singleElementSequence = { "single one"};
            Console.WriteLine(singleElementSequence.Single());//prints - single one
            Console.WriteLine("-----------------second version");
            Console.WriteLine(CarBrands.Single(s => s.StartsWith("Lin")));//prints Lincoln

            Console.WriteLine("\n-----------------SINGLEORDEFAULT");
            Console.WriteLine("-----------------first version");
            string[] singleElementSequence2 = {};
            if (String.IsNullOrEmpty(singleElementSequence2.SingleOrDefault()))
            {
                Console.WriteLine("We got default value of string = null");
            }
            Console.WriteLine("-----------------second version");
            if (String.IsNullOrEmpty(singleElementSequence2.SingleOrDefault(s=> s.StartsWith("strange string"))))
            {
                Console.WriteLine("We again got default value of string = null");
            }

            Console.WriteLine("\n-----------------ELEMENTAT");
            Console.WriteLine("Element at position 2 is: " + CarBrands.ElementAt(2));//prints - Lexus

            Console.WriteLine("\n-----------------ELEMENTATORDEFAULT");
            if (String.IsNullOrEmpty(CarBrands.ElementAtOrDefault(-1)))
            {
                Console.WriteLine("We got default value of string = null");
            }

            Console.WriteLine("\n-----------------ANY");
            Console.WriteLine("-----------------first version");
            string[] emptySequence = { };
            if (!emptySequence.Any())
            {
                Console.WriteLine("Input sequence is empty");
            }
            Console.WriteLine("Has CarBrands any elements? : " + CarBrands.Any());
            Console.WriteLine("-----------------second version");
            Console.WriteLine("Does car brands has something that starts with B: " + CarBrands.Any(s=> s.StartsWith("B")));

            Console.WriteLine("\n-----------------ALL");
            Console.WriteLine("Do all elements of CarBrands has more than 3 symbols: " + CarBrands.All(s => {if(s.Length>3)return true;return false;}));
            Console.WriteLine("Do all elements of CarBrands has more than 2 symbols: " + CarBrands.All(s => { if (s.Length > 2)return true; return false; }));

            Console.WriteLine("\n-----------------Contains");
            Console.WriteLine("-----------------first version");
            Console.WriteLine("Does CarBrands contain BMW: " + CarBrands.Contains("BMW"));
            int[] ints = { 0, 1, 2, 3, 4, 5 };
            Console.WriteLine("-----------------second version");
            Console.WriteLine("Does ints contain 5 with comparer: " + ints.Contains(5,comp));

            Console.WriteLine("\n-----------------Count");
            Console.WriteLine("-----------------first version");
            Console.WriteLine("CarBrands count: " + CarBrands.Count());
            Console.WriteLine("-----------------second version");
            Console.WriteLine("CarBrands count where length > 4: " + CarBrands.Count(s=> s.Length > 4));

            Console.WriteLine("\n-----------------LongCount");
            Console.WriteLine("-----------------first version");
            Console.WriteLine("CarBrands count: " + CarBrands.LongCount());
            Console.WriteLine("-----------------second version");
            Console.WriteLine("CarBrands count where length > 5: " + CarBrands.LongCount(s => s.Length > 5));

            Console.WriteLine("\n-----------------Sum");
            double[] doubles = { 0.1, 1.2, 2.3, 3.5, 4.6, 5.3 };
            Console.WriteLine("-----------------first version");
            Console.WriteLine("Sum of doubles is: " + doubles.Sum());
            Console.WriteLine("-----------------second version");
            Console.WriteLine("Sum of chars in CarBrands is: " + CarBrands.Sum(s=> s.Length));

            Console.WriteLine("\n-----------------Min");
            Console.WriteLine("-----------------first version");
            Console.WriteLine("Min of doubles is: " + doubles.Min());
            Console.WriteLine("-----------------second version");
            Console.WriteLine("Min in CarBrands: " + CarBrands.Min());
            Console.WriteLine("-----------------third version");
            Console.WriteLine("Min in CarBrands by length is: " + CarBrands.Min(s => s.Length));
            Console.WriteLine("-----------------fourth version");
            Console.WriteLine("Min in CarBrands (we imagine this is class and return string value  for name from it) : " + CarBrands.Min(s => s.ToString()));

            Console.WriteLine("\n-----------------Max");
            Console.WriteLine("-----------------first version");
            Console.WriteLine("Mxn of doubles is: " + doubles.Max());
            Console.WriteLine("-----------------second version");
            Console.WriteLine("Max in CarBrands: " + CarBrands.Max());
            Console.WriteLine("-----------------third version");
            Console.WriteLine("Max in CarBrands by length is: " + CarBrands.Max(s => s.Length));
            Console.WriteLine("-----------------fourth version");
            Console.WriteLine("Max in CarBrands (we imagine this is class and return string value  for name from it) : " + CarBrands.Max(s => s.ToString()));

            Console.WriteLine("\n-----------------Average");
            Console.WriteLine("-----------------first version");
            Console.WriteLine("Average of doubles is: " + doubles.Average());
            Console.WriteLine("-----------------second version");
            Console.WriteLine("Average of lengths in CarBrands is: " + CarBrands.Average(s => s.Length));
        }
        public class MyStringComparer : IComparer<string>
        {
            public int Compare(string first, string second)
            {
                if (first.Length > second.Length) return 1;
                if (first.Length < second.Length) return -1;
                return 0;
            }
        }
        public class IntComparer : IEqualityComparer<int>
        {
            public bool Equals(int x, int y)
            {
                return x == y;
            }
            public int GetHashCode(int i)
            {
                return i;
            }
        }
    }
}
