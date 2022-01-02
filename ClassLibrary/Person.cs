using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class Person
    {
        private string name;
        private string id;

        public Person() { }

        public Person(string id, string name)
        {
            this.id = id;
            this.name = name;
        }

        public string GetName()
        {
            return this.name;
        }

        public void SetName(string newName)
        {
            this.name = newName;
        }

        public string GetId()
        {
            return this.id;
        }

        public void SetId(string newId)
        {
            this.id = newId;
        }
    }
}
