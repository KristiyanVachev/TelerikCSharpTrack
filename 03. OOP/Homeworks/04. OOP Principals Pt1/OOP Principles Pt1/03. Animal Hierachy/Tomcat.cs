using System;

namespace _03.Animal_Hierachy
{
    class Tomcat : Cat
    {
        //constructors
        public Tomcat(int age, string name) : base(age, name, Sex.Male)
        {
        }
    }
}
