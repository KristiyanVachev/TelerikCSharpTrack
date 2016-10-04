using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsLinq
{
    class Startup
    {
        static void Main()
        {
            List<Student> students = new List<Student>{
                new Student("Jon", "Snow", 18,"610407","02093232","iKnowNothing@abv.bg",new List<int>{2,2 },2),
                new Student("Oberyn", "Martell",36,"610406","05093232","redViper@abv.bg",new List<int>{4,6 },2),
                new Student("Jon", "Connington",45,"610402","02093232","notInTheShow@gmail.com",new List<int>{2,6 },4),
                new Student("Aegon", "Targaryen",14,"610406","032093232","notDead@abv.bg",new List<int>{2,6,3,4 },3),
                new Student("Jeyne", "Pool", 15,"610404","096093232","nothing@yahoo.com",new List<int>{2,2,4,2 },1),
                new Student("Sarrela", "Sand", 19,"610406","032093232","nothing@gmail.com",new List<int>{2,3,4 },3)
            };

            //Problem 3
            var sortedStudents = from st in students
                                 orderby st.FirstName
                                 select st;

            //foreach (var sortedStudent in sortedStudents)
            //{
            //    Console.WriteLine(sortedStudent.FirstName + " " + sortedStudent.LastName);
            //}

            //Problem 4
            var agedStudents = from st in students
                               where st.Age >= 18 && st.Age <= 24
                               select st;
            //foreach (var aged in agedStudents)
            //{
            //    Console.WriteLine(aged.FirstName + " " + aged.LastName);
            //}

            //Problem 5
            var sortedStudents2 = students
                .OrderByDescending(s => s.FirstName)
                .ThenBy(s => s.LastName)
                .ToList();

            //foreach (var student in sortedStudents2)
            //{
            //    Console.WriteLine(student.FirstName + " " + student.LastName);
            //}

            //Problem 6
            //Divisible my 3 OR 7
            var divisible = students
                .Where(s => s.Age % 3 == 0 || s.Age % 7 == 0)
                .ToList();

            //foreach (var student in divisible)
            //{
            //    Console.WriteLine(student.Age);
            //}

            //Problem 9
            var inSecondGroup = students
                .Where(s => s.GroupNumber == 2)
                .ToList();
            //foreach (var student in inSecondGroup)
            //{
            //    Console.WriteLine("{0} {1} in group {2}",student.FirstName,student.LastName,student.GroupNumber);
            //}

            //Problem 11
            var abvUsers = students
                .Where(s => s.Email.EndsWith("abv.bg"))
                .ToList();

            //foreach (var student in abvUsers)
            //{
            //    Console.WriteLine("{0} {1} email: {2}", student.FirstName, student.LastName, student.Email );
            //}

            //Problem 12
            var sofiaNumbers = students
                .Where(s => s.Tel[0] == '0' && s.Tel[1] == '2')
                .ToList();

            //foreach (var student in sofiaNumbers)
            //{
            //    Console.WriteLine("{0} {1} phone: {2}", student.FirstName, student.LastName, student.Tel);
            //}

            //Problem 13
            var goodMark = students
                .Where(s => s.Marks.Contains(6));
            var anon =
                new
                {
                    FullName = goodMark.Select(s => s.FirstName + " " + s.LastName),
                    Marks = goodMark.Select(s => s.Marks)
                };

            //Problem 14
            var twoMarks = students
                .Where(s => s.Marks.Count == 2)
                .ToList();

            //foreach (var student in twoMarks)
            //{
            //    Console.WriteLine("{0} {1} marks count: {2}", student.FirstName, student.LastName, student.Marks.Count);
            //}

            //Problem 15
            var enrolledIn06 = students
                .Where(s => s.FN[4] == '0' && s.FN[5] == '6')
                .ToList();

            //foreach (var student in enrolledIn06)
            //{
            //    Console.Write("{0} {1}: ", student.FirstName, student.LastName);
            //    foreach (var mark in student.Marks)
            //    {
            //        Console.Write("{0} ", mark);
            //    }
            //    Console.WriteLine();
            //}

        }
    }
}
