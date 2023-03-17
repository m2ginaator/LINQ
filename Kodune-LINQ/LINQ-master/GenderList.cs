namespace LINQ
{
    public class GenderList
    {
        public static readonly List<Gender> genderList = new List<Gender>()
        {
            new Gender()
            {
                Id =  Guid.Parse("1651f349-3248-4c91-93af-f9ac1ab8c1de"), 
                Sex = "male"
            },
            new Gender() 
            {
                Id =  Guid.Parse("ca6d3376-b4f1-41b7-96b7-af8a1813e5cf"), 
                Sex = "female"
            }
        };
    }
}
