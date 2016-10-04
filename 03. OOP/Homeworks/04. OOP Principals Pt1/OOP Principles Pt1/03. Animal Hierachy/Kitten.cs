using System;

namespace _03.Animal_Hierachy
{
    class Kitten : Cat
    {
        //constructors
        public Kitten(int age, string name) : base(age, name, Sex.Female)
        {

        }
    }
}
