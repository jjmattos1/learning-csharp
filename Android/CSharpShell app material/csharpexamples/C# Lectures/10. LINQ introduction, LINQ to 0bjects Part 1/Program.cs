using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10_LINQ
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
            //----------------yielding----------------------
            Console.WriteLine("-----------------YIELDING--------------------");
            IEnumerable<string> cars = CarBrands.Where(s => s.StartsWith("T"));
            //result for below is Toyota and Tesla
            foreach (string car in cars) 
            {
                Console.WriteLine(car);
            }
            //the query below is problematic and has exception out of range for values of "BMW" and "KIA"
            try
            {
                cars = CarBrands.Where(s => s[3]!='D');
                foreach (string car in cars)
                {
                    Console.WriteLine(car);
                }
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine("Out of range catched");
            }
            //----------------deferred query----------------------
            Console.WriteLine("-----------------DEFERRED QUERY--------------------");
            int[] arr = new int[] { 1, 2, 3, 4, 5 };
            IEnumerable<int> ints = arr.Select(i => i);
            foreach (int i in ints)
            {
                Console.WriteLine(i);//result is 1,2,3,4,5
            }
            arr[0] = 10;
            foreach (int i in ints)
            {
                Console.WriteLine(i);//result is 10,2,3,4,5
            }
            //----------------OPERATORS----------------------
            Console.WriteLine("-----------------OPERATORS--------------------");
            Console.WriteLine("-----------------WHERE");
            //first version
            Console.WriteLine("--first version");
            IEnumerable<string> outCars = CarBrands.Where(s => s.StartsWith("C"));//gives Chevrole and Cadillac
            foreach (string car in outCars)
            {
                Console.WriteLine(car);
            }
            Console.WriteLine("--second version");
            outCars = CarBrands.Where((s, i) => { return (i & 1) == 0; });//gives cars whose index is odd
            foreach (string car in outCars)
            {
                Console.WriteLine(car);
            }
            Console.WriteLine("-----------------SELECT");
            Console.WriteLine("--first version");
            //here we transofrm input sequence of strings to output sequence of integers that present their lenghts
            IEnumerable<int> lengths = CarBrands.Select( s => s.Length);
            foreach (int i in lengths)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("--second version");
            var CarsAndTheirIndexes = CarBrands.Select((s, i) => new { CarName = s, CarIndex = i});
            foreach (var Car in CarsAndTheirIndexes)
            {
                Console.WriteLine("Car name is: " + Car.CarName + " Car index is: " + Car.CarIndex);
            }
            Console.WriteLine("-----------------SELECTMANY");
            Console.WriteLine("--first version");
            //here we return list of characters for a car that starts with C and othervise return empty array
            var CarsLetters = CarBrands.SelectMany(car => { if(car.StartsWith("C"))return car.ToArray(); return new char[0];});
            foreach (char c in CarsLetters) 
            {
                Console.Write(c);
            }
            Console.WriteLine("--second version");
            CarsLetters = CarBrands.SelectMany((car,index) => { if((index&1) == 0)return car.ToArray(); return new char[0]; });
            foreach (char c in CarsLetters)
            {
                Console.Write(c);
            }
            Console.WriteLine("\n-----------------TAKE");
            IEnumerable<string> ThreeCars = CarBrands.Take(3);
            foreach (string car in ThreeCars)
            {
                Console.WriteLine(car);
            }
            Console.WriteLine("\n-----------------TAKEWHILE");
            Console.WriteLine("--first version");
            cars = CarBrands.TakeWhile(s => s.Length > 3);//will return all cars until we reach BMW
            foreach (string car in cars)
            {
                Console.WriteLine(car);
            }
            Console.WriteLine("--second version");
            cars = CarBrands.TakeWhile((s,i) => i < 5);//will return first 5 cars
            foreach (string car in cars)
            {
                Console.WriteLine(car);
            }
            Console.WriteLine("\n-----------------SKIP");
            IEnumerable<string> CarsWithoutFirstThree = CarBrands.Skip(3);
            foreach (string car in CarsWithoutFirstThree)
            {
                Console.WriteLine(car);
            }
            Console.WriteLine("\n-----------------SKIPWHILE");
            Console.WriteLine("--first version");
            cars = CarBrands.SkipWhile(s => !s.StartsWith("C"));//will return all cars after Chevrole including it also
            foreach (string car in cars)
            {
                Console.WriteLine(car);
            }
            Console.WriteLine("--second version");
            cars = CarBrands.SkipWhile((s, i) => i < 5);//will return cars without first 4
            foreach (string car in cars)
            {
                Console.WriteLine(car);
            }
            Console.WriteLine("\n-----------------CONCAT");
            string[] FewMoreCars = { "Acura", "Infinity" };
            cars = CarBrands.Concat(FewMoreCars);
            foreach (string car in cars)
            {
                Console.WriteLine(car);
            }
            Console.WriteLine("\n-----------------ORDERBY");
            Console.WriteLine("--first version");
            cars = CarBrands.OrderBy(s => s.Length);
            foreach (string car in cars)
            {
                Console.WriteLine(car);
            }
            Console.WriteLine("--second version");
            MyStringComparer comparer = new MyStringComparer();
            cars = CarBrands.OrderBy((s => s), comparer);
            foreach (string car in cars)
            {
                Console.WriteLine(car);
            }
            Console.WriteLine("\n-----------------ORDERBYDESCENDING");
            Console.WriteLine("--first version");
            cars = CarBrands.OrderByDescending(s => s.Length);
            foreach (string car in cars)
            {
                Console.WriteLine(car);
            }
            Console.WriteLine("--second version");
            cars = CarBrands.OrderByDescending((s => s), comparer);
            foreach (string car in cars)
            {
                Console.WriteLine(car);
            }
            Console.WriteLine("\n-----------------THENBY");
            Console.WriteLine("--first version");
            cars = CarBrands.OrderBy(s => s.Length).ThenBy(s => s);
            foreach (string car in cars)
            {
                Console.WriteLine(car);
            }
            Console.WriteLine("--second version");
            comparer = new MyStringComparer();
            cars = CarBrands.OrderBy(s => s.Length).ThenBy(s=>s, comparer);
            foreach (string car in cars)
            {
                Console.WriteLine(car);
            }
            Console.WriteLine("\n-----------------THENBYDESCENDING");
            Console.WriteLine("--first version");
            cars = CarBrands.OrderBy(s => s.Length).ThenByDescending(s => s);
            foreach (string car in cars)
            {
                Console.WriteLine(car);
            }
            Console.WriteLine("--second version");
            comparer = new MyStringComparer();
            cars = CarBrands.OrderBy(s => s.Length).ThenByDescending(s => s, comparer);
            foreach (string car in cars)
            {
                Console.WriteLine(car);
            }
            Console.WriteLine("\n-----------------REVERSE");
            cars = CarBrands.Reverse();
            foreach (string car in cars)
            {
                Console.WriteLine(car);
            }
            Console.WriteLine("\n-----------------JOIN");
            int[] Lenghts = { 3, 4, 5, 6, 7, 8, 9 };
            var outStructs = CarBrands.Join(Lenghts, s => s.Length, l => l, (s, l) => new { name = s, length = l });
            foreach (var Car in outStructs)
            {
                Console.WriteLine("Car name is: " + Car.name + " Car name length is: " + Car.length);
            }
            Console.WriteLine("\n-----------------GROUPJOIN");
            //if car length is bigger than 5 we take all lengths that bigger than 5
            //if car length is smaller or equal 5 we take all lengths that smaller or equal 5
            int[] Len = { 3, 4, 5, 6, 7, 8, 9 };
            var outValues = CarBrands.GroupJoin(Len, s => s.Length > 5, l => l > 5, (s, lens) => new { name = s, lensplus = lens });
            foreach (var car in outValues)
            {
                Console.WriteLine("Car name is: " + car.name + "name length: "+ car.name.Length +" Lengths bigger or smaller and equal than 5: ");
                foreach (int l in car.lensplus) 
                {
                    Console.WriteLine(l);
                }
            }
            Console.WriteLine("\n-----------------GROUPBY");
            Console.WriteLine("--first version");
            IEnumerable<IGrouping<int, string>> grouppedCars = CarBrands.GroupBy(s => s.Length);
            foreach(IGrouping<int, string> element in grouppedCars)
            {
                Console.WriteLine("Length: " + element.Key + " Names:");
                foreach(string s in element)
                {
                    Console.WriteLine(s);
                }
            }
            Console.WriteLine("--second version");
            IntComparer comp = new IntComparer();
            grouppedCars = CarBrands.GroupBy(s => s.Length,comp);
            foreach (IGrouping<int, string> element in grouppedCars)
            {
                Console.WriteLine("Length: " + element.Key + " Names:");
                foreach (string s in element)
                {
                    Console.WriteLine(s);
                }
            }
            Console.WriteLine("--third version");
            IEnumerable<IGrouping<int, int>> grouppedLengths = CarBrands.GroupBy(s => s.Length, el => el.Length);
            foreach (IGrouping<int, int> element in grouppedLengths)
            {
                Console.WriteLine("Length group: " + element.Key + " Cars lengths:");
                foreach (int s in element)
                {
                    Console.WriteLine(s);
                }
            }
            Console.WriteLine("--fourth version");
            grouppedLengths = CarBrands.GroupBy(s => s.Length, el => el.Length, comp);
            foreach (IGrouping<int, int> element in grouppedLengths)
            {
                Console.WriteLine("Length group: " + element.Key + " Cars lengths:");
                foreach (int s in element)
                {
                    Console.WriteLine(s);
                }
            }
            Console.WriteLine("\n-----------------DISTINCT");
            string[] names = { "Sergey", "Sergey", "John", "James", "John", "Mary", "Alexander" };
            IEnumerable<string> dist = names.Distinct();
            foreach (string s in dist)
            {
                Console.WriteLine(s);
            }
            Console.WriteLine("\n-----------------UNION");
            string[] names2 = { "Mary", "Alexander", "James", "Richard", "Julia" };
            IEnumerable<string> uniqueNames = names.Union(names2);
            foreach (string s in uniqueNames)
            {
                Console.WriteLine(s);
            }
            Console.WriteLine("\n-----------------INTERSECT");
            IEnumerable<string> intersNames = names.Intersect(names2);
            foreach (string s in intersNames)
            {
                Console.WriteLine(s);
            }
            Console.WriteLine("\n-----------------EXCEPT");
            IEnumerable<string> exceptNames = names.Except(names2);
            foreach (string s in exceptNames)
            {
                Console.WriteLine(s);
            }
            Console.WriteLine("\n-----------------CAST");
            int[] integers = { 1, 2, 3, 4, 5, 6, 7 };
            IEnumerable<object> objs = integers.Cast<object>();
            foreach (object s in objs)
            {
                Console.WriteLine(s.ToString());
            }
            Console.WriteLine("\n-----------------OFTYPE");
            IEnumerable<string> strs = integers.OfType<string>();//here we'll receive empty string
            foreach (string s in strs)
            {
                Console.WriteLine(s.ToString());
            }
            Console.WriteLine("\n-----------------DEFAULTIFEMPTY");
            Console.WriteLine("--first version");
            IEnumerable<int> sequence = integers.Where(i => i>10);
            IEnumerable<int> outseq = sequence.DefaultIfEmpty();//here we should have default int value
            Console.WriteLine("Result on empty:");
            foreach(int i in outseq)
            {
                Console.WriteLine(i);
            }
            sequence = integers.Where(i => i > 5);
            outseq = sequence.DefaultIfEmpty();//here we should have default int value
            Console.WriteLine("Result on not empty:");
            foreach (int i in outseq)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("--second version");
            sequence = integers.Where(i => i > 10);
            outseq = sequence.DefaultIfEmpty(55);//here we should have default int value
            Console.WriteLine("Result on empty:");
            foreach (int i in outseq)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("\n-----------------RANGE");
            IEnumerable<int> intseq = Enumerable.Range(5, 5);
            foreach (int i in intseq)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("\n-----------------REPEAT");
            intseq = Enumerable.Repeat(5, 5);
            foreach (int i in intseq)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("\n-----------------EMPTY");
            intseq = Enumerable.Empty<int>();
            foreach (int i in intseq)
            {
                Console.WriteLine(i);//we should never reach here
            }
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
                return x==y;
            }
            public int GetHashCode(int i)
            {
                return i;
            }
        }
    }
}
