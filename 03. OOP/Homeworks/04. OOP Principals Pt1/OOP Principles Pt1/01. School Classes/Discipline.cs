namespace _01.School_Classes
{
    class Discipline
    {
        //fields
        private string name;
        private int lecturesCount;
        private int exercisesCount;

        //properties
        public string Name { get { return this.name; } set {this.name = value; } }
        public int LecturesCount { get; set; }
        public int ExercisesCount { get; set; }

        //constructors
        public Discipline(string name, int lecturesCount, int exercisesCount)
        {
            this.name = name;
            this.lecturesCount = lecturesCount;
            this.exercisesCount = exercisesCount;
        }
    }
}
