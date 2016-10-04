namespace _01.School_Classes
{
    using System.Collections.Generic;
    class Startup
    {
        static void Main()
        {
            //Creating Disciplines
            Discipline climbing = new Discipline("Climbing", 3, 6);
            Discipline swimming = new Discipline("Swimming", 4, 8);
            Discipline hiking = new Discipline("Hiking", 5, 10);

            //Creating Students
            Student koala = new Student("Koala Square", 1);
            Student kote = new Student("Kote", 2);

            //Creating Teacher
            List<Discipline> list = new List<Discipline>();
            Teacher dolphin = new Teacher("Dolphin Dem-Pi-Pi-Du", list);
            dolphin.Disciplines.Add(climbing);
            dolphin.Disciplines.Add(swimming);
            dolphin.Disciplines.Add(hiking);

            //Creating class
            Classes theCoolClass = new Classes(new List<Student>(), new List<Teacher>());

            //Attend to class
            theCoolClass.Students.Add(koala);
            theCoolClass.Students.Add(kote);
            theCoolClass.Teachers.Add(dolphin);

            //Show the class 
            theCoolClass.printTeachers();
            theCoolClass.printStudents();

        }
    }
}
