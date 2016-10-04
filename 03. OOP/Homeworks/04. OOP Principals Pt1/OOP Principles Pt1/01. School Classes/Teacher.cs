namespace _01.School_Classes
{
    using System.Collections.Generic;

    class Teacher : Person
    {
        //fields
        private List<Discipline> disciplines = new List<Discipline>();

        //properties
        public List<Discipline> Disciplines { get {return this.disciplines; } set {this.disciplines = value; } }

        //constructors
        public Teacher(string name, List<Discipline> disciplines) : base(name)
        {
            this.disciplines = disciplines;
        }
    }
}
