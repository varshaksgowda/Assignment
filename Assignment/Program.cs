using System.Security.Cryptography;

namespace Assignment
{
    public class Person
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
    }
    public class PersonImplementation
    {
        public string GetName(IList<Person> person) 
        {
            //List<string> details = new List<string>();
            string details = "";
            foreach(var persons in person)
            {
                details +=$"{persons.Name}  {persons.Address} ";

            }
            return details;
        }
        public double Average(IList<Person> person)
        {
            double sum = 0;
            int count = 0;
            double avg = 0;
            foreach(var persons in person)
            {
                sum = sum + persons.Age;
                count++;
            }
            avg= sum / count;
            return sum / count;
        }
        public int Max(IList<Person> person)
        {
            int max = 0;
            foreach (var persons in person)
            {
                if (persons.Age > max)
                {
                    max= persons.Age;
                }
            }
            return max;
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person();
            IList<Person> p= new List<Person>(); 
            p.Add(new Person { Name="Aarya",Address="A2101",Age=69});
            p.Add(new Person { Name = "Daniel", Address = "D104", Age = 40 });
            p.Add(new Person { Name = "Ira", Address = "H801", Age = 25 });
            p.Add(new Person { Name = "Jennifer", Address = "I1704", Age = 33 });
            PersonImplementation result= new PersonImplementation();
            string names=result.GetName(p);
            double Avg= result.Average(p);
            int Max= result.Max(p);
            Console.WriteLine(names);
            Console.WriteLine(Avg);
            Console.WriteLine(Max);
        }
    }
}
