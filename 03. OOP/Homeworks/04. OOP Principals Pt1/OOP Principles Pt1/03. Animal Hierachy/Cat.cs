using System;

namespace _03.Animal_Hierachy
{
    class Cat : Animal
    {
        //constructors
        public Cat(int age, string name, Sex sex) : base(age, name, sex)
        {

        }

        //methods

        public override void Speak()
        {
            Console.WriteLine("Mauu");
        }
    }
}
