namespace _01.School_Classes
{
   public class Person
    {
        //fields
        private string name;

        //properties
        public string Name { get { return this.name; } set { this.name = value; } }

        //constructors
        public Person(string name)
        {
            this.name = name;
        }

        //methods
    }
}
