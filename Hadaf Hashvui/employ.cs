using System;
using System.Collections.Generic;
using System.Text;

namespace Hadaf_Hashvui
{
    public class employ: person
    {
        private string userName;
        private string password;

        public employ(string id, string name, string userName, string passWord) : base(id, name)
        {
            this.userName = userName;
            this.password = passWord;
        }
    }
}
