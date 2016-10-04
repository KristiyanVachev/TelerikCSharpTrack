using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Students_and_Workers
{
    class Startup
    {
        static void Main()
        {
            List<Student> students = new List<Student>()
            {
                new Student("Robert", "Baratheon",3),
                new Student("Tywin", "Lannister", 6),
                new Student("Sandor", "Clegane", 2),
                new Student("Doran", "Martell", 6),
                new Student("SmallJon", "Umber", 4)
            };

            var highestGrades = students
                                .OrderBy(s => s.Grade)
                                .ToList();

            //Print students
            Console.WriteLine("Students by ascending:");
            foreach (var h in highestGrades)
            {
                Console.WriteLine("{0} {1} grade: {2}",h.FirstName,h.LastName,h.Grade);
            }
            Console.WriteLine();


            List<Worker> workers = new List<Worker>
            {
                new Worker("Tormund", "Giantsbane",120,8),
                new Worker("Joffrey", "Baratheon",240,4),
                new Worker("Jorah", "Mormont",160,8),
                new Worker("Randyl", "Tarly",180,8),
                new Worker("Osmund", "Kettleback",200,8)
            };

            var highestPaid = workers
                            .OrderByDescending(w => w.MoneyPerHour())
                            .ToList();
            Console.WriteLine("Highest paid workers:");
            foreach (var h in highestPaid)
            {
                Console.WriteLine("{0} {1} - {2}$ per hour", h.FirstName, h.LastName, h.MoneyPerHour());
            }
            Console.WriteLine();

            //Humans by name
            List<Human> humans = new List<Human>();
            foreach (var student in students)
            {
                humans.Add(student);
            }
            foreach (var worker in workers)
            {
                humans.Add(worker);
            }

            var sortByName = humans
                            .OrderBy(h => h.FirstName)
                            .ThenBy(h => h.LastName)
                            .ToList();

            Console.WriteLine("All people sorted by name");
            foreach (var s in sortByName)
            {
                Console.WriteLine("{0} {1}", s.FirstName, s.LastName);
            }

        }
    }
}
