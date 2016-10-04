namespace _03.Animal_Hierachy
{
    using System;
    class Dog : Animal
    {

        //constructors
        public Dog(int age, string name, Sex sex) : base(age, name, sex)
        {

        }
        
        //methods

        public override void Speak()
        {
            Console.WriteLine("Grrr Bau!");
        }
    }
}
