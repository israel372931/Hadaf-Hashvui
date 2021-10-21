using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class Employee:Person
    {
        private string userName;
        private string password;

        public Employee(string id, string name, string userName, string passWord) : base(id, name)
        {
            this.userName = userName;
            this.password = passWord;
        }

        public Employee(string userName, string passWord)
        {
            this.userName = userName;
            this.password = passWord;
        }

    }
}
