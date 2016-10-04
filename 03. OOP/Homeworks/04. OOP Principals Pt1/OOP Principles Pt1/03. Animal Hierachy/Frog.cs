using System;

namespace _03.Animal_Hierachy
{
    class Frog : Animal
    {
        //constructors
        public Frog(int age, string name, Sex sex) : base(age, name, sex)
        {

        }

        //methods
        public override void Speak()
        {
            Console.WriteLine("Kwak-kwak");
        }
    }
}
