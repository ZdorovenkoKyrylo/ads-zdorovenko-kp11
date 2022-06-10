using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADS_Hashtable
{
    class Key
    {
        public string username;
        public Key(String username)
        {
            this.username = username;
        }
    }
    class Value
    {
        public string Password;
        public string EmailAdress;
        public Date LastLoginDate;
        public Value(string password, string emailAdress, Date lastLoginDate)
        {
            this.Password = password;
            this.EmailAdress = emailAdress;
            this.LastLoginDate = lastLoginDate;
        }
        public Value() { }
    }

    class Entry
    {
        public Key Key;
        public Value Value;
        public Entry(Key key, Value value)
        {
            Key = key;
            Value = value;
        }
    }
}
