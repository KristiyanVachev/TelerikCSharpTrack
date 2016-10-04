using System.Collections.Generic;

namespace _01.School_Classes
{
    class Classes
    {
        //fields
        private List<Student> students;
        private List<Teacher> teachers;

        //properties
        public List<Student> Students { get { return this.students; } set { this.students = value; } }
        public List<Teacher> Teachers { get { return this.teachers; } set { this.teachers = value; } }

        //constructors
        public Classes(List<Student> students, List<Teacher> teachers)
        {
            this.students = students;
            this.teachers = teachers;
        }

        //methods

        public void printStudents()
        {
            foreach (var student in students)
            {
                System.Console.WriteLine("{0} attends the class.", student.Name);
            }
        }

        public void printTeachers()
        {
            foreach (var teacher in teachers)
            {
                System.Console.WriteLine("The class is taught by teacher {0}", teacher.Name);
            }
        }
    }
}
