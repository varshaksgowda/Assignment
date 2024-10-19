using System.Collections.Generic;
using System.Text;

namespace DoSelect5
{
    public delegate bool IsEligibleForScholarship(Student std);
    public class Student
    {
        public int RollNo { get; set; }
        public string Name { get; set; }
        public int Marks { get; set; }
        public char SportsGrade { get; set; }
        public static string GetEligibleStudent(List<Student> studentsList, IsEligibleForScholarship isEligible)
        {

            StringBuilder sb = new StringBuilder();
            foreach (Student students in studentsList)
            {
                if (isEligible(students))
                {
                    if (sb.Length > 0)
                    {
                        sb.Append(",");
                    }
                    sb.Append(students.Name);

                }
            }
            return sb.ToString();
        }
    }

    public class Program
    {
        public static bool ScholorshipEligibility(Student std)
        {
            if (std.Marks > 80 && std.SportsGrade == 'A')
            {
                return true;
            }
            return false;
        }
        static void Main(string[] args)
        {

            List<Student> student1 = new List<Student>();
            Student obj1 = new Student()
            {
                RollNo = 1,
                Name = "Raj",
                Marks = 75,
                SportsGrade = 'A'
            };
            Student obj2 = new Student()
            {
                RollNo = 2,
                Name = "Rahul",
                Marks = 82,
                SportsGrade = 'A'
            };
            Student obj3 = new Student()
            {
                RollNo = 3,
                Name = "Kiran",
                Marks = 89,
                SportsGrade = 'B'
            };
            Student obj4 = new Student()
            {
                RollNo = 4,
                Name = "Sunil",
                Marks = 86,
                SportsGrade = 'A'
            };
            student1.Add(obj1);
            student1.Add(obj2);
            student1.Add(obj3);
            student1.Add(obj4);
            IsEligibleForScholarship schlorship = new IsEligibleForScholarship(ScholorshipEligibility);
            var result = Student.GetEligibleStudent(student1, schlorship);
            Console.WriteLine(result);
        }
    }
}
