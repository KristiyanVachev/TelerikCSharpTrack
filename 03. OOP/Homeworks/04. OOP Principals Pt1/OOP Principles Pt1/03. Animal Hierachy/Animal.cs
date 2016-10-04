enum Sex
{
    Male, Female
}

namespace _03.Animal_Hierachy
{
    class Animal : ISound
    {
        //properties
        public int Age { get; set; }
        public string Name { get; set; }
        public Sex Sex { get; set; }

        //constructrs
        public Animal(int age, string name, Sex sex)
        {
            this.Age = age;
            this.Name = name;
            this.Sex = sex;
        }

        public virtual void Speak()
        {
            System.Console.WriteLine("Animal speaks");
        }
    }
}
