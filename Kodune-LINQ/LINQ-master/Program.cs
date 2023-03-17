using System.Net.NetworkInformation;
using System.Security.Cryptography.X509Certificates;

namespace LINQ
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("LINQ");

            WhereLINQ();

            PeopleByAge();

            ThenByLINQ();

            ThenByDescending();

            ToLookupLINQ();

            JoinLINQ();

            GroupJoinLINQ();

            SelectLINQ();

            AllAndAnyLINQ();

            ContainsLINQ();

            AggregateLINQ();

            AverageLINQ();

            CountLINQ();

            MaxLINQ();

            SumLINQ();

            UnionLINQ();

            Skip();

            SkipWhile();

            Take();

            TakeWhile();
        }
        public static void WhereLINQ()
        {
            Console.WriteLine("---------------------------");
            var filteredResult = PeopleList.people.Where((s, i) =>
            {
                if (i % 2 == 0)
                {
                    return true;
                }
                return false;
            });

            foreach (var people in filteredResult)
            {
                Console.WriteLine(people.Name);
            }
        }

        public static void PeopleByAge()
        {
            Console.WriteLine("---------------------------");

            Console.WriteLine("Vanuse järgi selekteerimine");

            var peopleByAge = PeopleList.people.Where(s => s.Age > 14 && s.Age < 20);  //s võib siinkohal olla suvaline täht

            foreach (var people in peopleByAge)
            {
                Console.WriteLine(people.Age + " " + people.Name);
            }
        }

        public static void ThenByLINQ()
        {
            Console.WriteLine("---------------------------");

            Console.WriteLine("ThenBy ja ThenByDescending järgi reastamine");

            var thenByResult = PeopleList.people
                .OrderBy(x => x.Name)
                .ThenBy(y => y.Age);

            Console.WriteLine("ThenBy järgi");
            foreach (var people in thenByResult)
            {
                Console.WriteLine(people.Name + " " + people.Age);
            }
        }

        public static void ThenByDescending()
        {
            Console.WriteLine("---------------------------");

            Console.WriteLine("ThenByDescending järgi reastamine");

            var thenByDescending = PeopleList.people
                .OrderBy(x => x.Name)
                .ThenByDescending(y => y.Age);

            foreach (var people in thenByDescending)
            {
                Console.WriteLine(people.Name + " " + people.Age);
            }
        }

        public static void ToLookupLINQ()
        {
            Console.WriteLine("---------------------------");

            Console.WriteLine("ToLookup järgi reastamine");

            var toLookup = PeopleList.people
                .ToLookup(x => x.Age);

            foreach (var people in toLookup)
            {
                Console.WriteLine("Age group " + people.Key);

                foreach (People n in people)
                {
                    Console.WriteLine("Person name {0}", n.Name);
                }
            }

        }

        public static void JoinLINQ()
        {
            Console.WriteLine("---------------------------");

            var innerJoin = PeopleList.people.Join(
                GenderList.genderList,
                humans => humans.GenderId,
                gender => gender.Id,
                (humans, gender) => new
                {
                    Name = humans.Name,
                    Sex = gender.Sex
                });

            foreach (var obj in innerJoin)
            {
                Console.WriteLine("{0} - {1}", obj.Name, obj.Sex);
            }
        }

        public static void GroupJoinLINQ()
        {
            Console.WriteLine("-------------------------");
            var groupJoin = GenderList.genderList
                .GroupJoin(PeopleList.people,
                p => p.Id,
                g => g.GenderId,
                (p, peopleGroup) => new
                {
                    Humans = peopleGroup,
                    GenderFullName = p.Sex
                });

            foreach (var item in groupJoin)
            {
                Console.WriteLine(item.GenderFullName);

                foreach (var name in item.Humans)
                {
                    Console.WriteLine(name.Name);
                }
            }
        }

        public static void SelectLINQ()
        {
            //start
            Console.WriteLine("-----------------------");
            Console.WriteLine("Select in LINQ");
            var selectResult = PeopleList.people
                .Select(x => new
                {
                    Name = x.Name,
                    Age = x.Age,
                });

            foreach (var item in selectResult)
            {
                Console.WriteLine("Human name: {0}, Age: {1}", item.Name, item.Age);
            }
            //end
        }

        public static void AllAndAnyLINQ()
        {
            Console.WriteLine("-----------------------");
             Console.WriteLine("All LINQ");

            bool areAllPeopleTeenagers = PeopleList.people
                .All(x => x.Age < 12 && x.Age > 22);
             //vastus tuleb false, aga x => x.Age > 12 tuleb true
            Console.WriteLine(areAllPeopleTeenagers);

            Console.WriteLine("-----------------------");
            Console.WriteLine("Any LINQ");

            bool isAnyPersonTeenager = PeopleList.people
                .Any(x => x.Age > 15);
            //vähemalt üks andmerida vastab nimetatud tingimusele e. x.Age > 15
            Console.WriteLine(isAnyPersonTeenager);
        }

        public static void ContainsLINQ()
        {
            Console.WriteLine("---------------");
            Console.WriteLine("Contains LINQ");

            //kontrollib, kas nimekirjas on number olemas või ei
            bool result = NumberList.numberList.Contains(1);

            Console.WriteLine(result);
        }

        public static void AggregateLINQ()
        {
            Console.WriteLine("---------------------");
            Console.WriteLine("Aggregate LINQ");

            string commaSeparatedPersonNames = PeopleList.people
                .Aggregate<People, string>(
                "People names: ",
                (str, y) => str += y.Name + ", "   //y.Name.Count() on ka variant
                );

            Console.WriteLine(commaSeparatedPersonNames);
        }

        public static void AverageLINQ()
        {
            Console.WriteLine("-------------");
            Console.WriteLine("Average LINQ");

            var averageResult = PeopleList.people
                .Average(x => x.Age);

            Console.WriteLine(averageResult);
        }

        public static void CountLINQ()
        {
            Console.WriteLine("---------------");
            Console.WriteLine("Count LINQ");

            var totalPersons = PeopleList.people.Count();

            Console.WriteLine("Inimesi on kokku: " + totalPersons);

            var adultPersons = PeopleList.people.Count(x => x.Age >= 18);

            Console.WriteLine("Täisealisi inimesi on kokku: " + adultPersons);
        }

        public static void MaxLINQ()
        {
            Console.WriteLine("-----------------");

            var oldestPerson = PeopleList.people
                .Max(x => x.Age);

            Console.WriteLine("Vanim inimene nimekirjas on: " + oldestPerson);
        }

        public static void SumLINQ()
        {
            Console.WriteLine("-------------------");
            Console.WriteLine("Summa LINQ");

            var sumAge = PeopleList.people.Sum(x => x.Age);
            Console.WriteLine("Vanuste summa on : " + sumAge);

            Console.WriteLine("-------------");

            var numAdult = PeopleList.people.Sum(x =>
            {
            if (x.Age >= 18)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }

            });

            Console.WriteLine("Täiskasvanud inimesi on kokku:" + numAdult);

            var sumAdult = PeopleList.people.Sum(x =>
            {
                //täiskasvanud isikute vanused kokku KODUTÖÖ
                if (x.Age >= 18)
                {                    
                    return x.Age;     //lahendus siin
                }
                else
                {
                    return 0;
                }

            });
            Console.WriteLine("Täiskasvanud isikute vanuste summa: "+ sumAdult);
        }
        public static void UnionLINQ()
        {
            Console.WriteLine("-----------UNION---------");
            //kõik kordused teeb üheks e. topelt ei kuva

            IList<string> list1 = new List<string>() { "car", "bike", "truck", "FOOT" };
            IList<string> list2 = new List<string>() { "CAR", "Bike", "Truck", "f00t" };

            var result = list1.Union(list2);

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }

        public static void Skip()
        {
            Console.BackgroundColor = ConsoleColor.Black;

            Console.WriteLine("\n\n----------Skip----------");

            var skip = PeopleList.people.Skip(3);

            foreach (var item in skip)
            {
                Console.WriteLine(item.Id);
            }
        }
        public static void SkipWhile()
        {
            Console.WriteLine("\n\n----------Skipwhile----------");

            var skipWhile = PeopleList.people
                .SkipWhile(x => x.Age > 18);

            foreach (var item in skipWhile)
            {
                Console.WriteLine(item.Name + " " + item.Age);
            }
        }
        public static void Take()
        {
            Console.WriteLine("\n\n----------Take----------");

            var take = PeopleList.people.Take(3);

            foreach (var item in take)
            {
                Console.WriteLine(item.Id + " " + item.Name);
            }
        }
        public static void TakeWhile()
        {
            Console.WriteLine("\n\n----------Takewhile----------");

            var takeWhile = PeopleList.people.TakeWhile(x => x.Age > 18);

            foreach (var item in takeWhile)
            {
                Console.WriteLine(item.Id + " " + item.Name);
            }
        }
    }
}




    