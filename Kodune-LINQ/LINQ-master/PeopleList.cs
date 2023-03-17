
using static LINQ.Program;

namespace LINQ
{
    public class PeopleList
    {
        public static readonly List<People> people = new List<People>
        {
                new People() {
                    Id = 1, 
                    Name = "Joonas", 
                    Age = 13, 
                    GenderId = Guid.Parse("1651f349-3248-4c91-93af-f9ac1ab8c1de")
                },
                new People() 
                {
                    Id = 2, 
                    Name = "Moona", 
                    Age = 21, 
                    GenderId = Guid.Parse("ca6d3376-b4f1-41b7-96b7-af8a1813e5cf") 
                },
                new People() 
                {
                    Id = 3, 
                    Name = "Roonas", 
                    Age = 18, 
                    GenderId = Guid.Parse("1651f349-3248-4c91-93af-f9ac1ab8c1de") 
                },
                new People() 
                {
                    Id = 4, 
                    Name = "Anna", 
                    Age = 20, 
                    GenderId = Guid.Parse("ca6d3376-b4f1-41b7-96b7-af8a1813e5cf") 
                },
                new People() 
                {
                    Id = 5, 
                    Name = "Mari", 
                    Age = 17, 
                    GenderId = Guid.Parse("ca6d3376-b4f1-41b7-96b7-af8a1813e5cf") 
                },
                new People() 
                {
                    Id = 6, 
                    Name = "Mauno", 
                    Age = 15, 
                    GenderId = Guid.Parse("1651f349-3248-4c91-93af-f9ac1ab8c1de") 
                },
                new People() 
                {
                    Id = 7, 
                    Name = "Jumbo", 
                    Age = 21, 
                    GenderId = Guid.Parse("1651f349-3248-4c91-93af-f9ac1ab8c1de") 
                },
        };
    }
}

