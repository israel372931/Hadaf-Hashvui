using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class Person
    {
        private string id;
        private string fullName;

        public Person() { }

        public Person(string id, string name)
        {
            this.id = id;
            this.fullName = name;
        }

    }
}
