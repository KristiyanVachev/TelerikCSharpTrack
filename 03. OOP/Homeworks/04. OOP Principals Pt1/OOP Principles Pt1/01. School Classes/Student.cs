namespace _01.School_Classes
{
    class Student : Person
    {
        //fields
        private int classNumber;

        //properties
        public int ClassNumber { get; set; }

        //constructors
        public Student(string name,int classNumber) : base(name)
        {
            this.classNumber = classNumber;
        }

    }
}
