using System;
using System.Linq;

namespace _03.Animal_Hierachy
{
    class Startup
    {
        static void Main()
        {
            Animal[] animals = {
                new Dog(2,"Alpi", Sex.Male),
                new Dog(1, "Wilsie", Sex.Female),
                new Tomcat(0,"Surcho"),
                new Cat(4, "Stray Cat", Sex.Male),
                new Frog(29,"Kermit",Sex.Male),
                new Kitten(2,"Hmrrr"),
                new Tomcat(7, "Prince Pounce")
            };

            //group by type
            var animalKinds = animals.GroupBy(a => a.GetType());

            foreach (var animalKind in animalKinds)
            {
                double sum = 0;
                int count = 0;
                string type = string.Empty;
                //for each instance of the animal type
                foreach (var instance in animalKind)
                {
                    sum += instance.Age;
                    count++;
                    type = instance.GetType().Name; //get the class name
                }

                double average = sum / count;
                Console.WriteLine("The average age of {0} is {1} years", type, average);
            }

            //ISound test
            //Console.WriteLine("ISound test");
            //foreach (var animal in animals)
            //{
            //    animal.Speak();
            //}


        }
    }
}
