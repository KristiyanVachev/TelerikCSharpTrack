using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Students_and_Workers
{
    abstract class Human
    {
        //properties
        public string FirstName { get; set; }
        public string LastName { get; set; }
        
        //constructors
        public Human(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }
    }
}
