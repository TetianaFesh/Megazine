using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    class Person
    {
        private string _firstname;
        private string _secondname;
        private DateTime _date { get; set; }

        public Person()
        {
            _date = DateTime.Now;
            _firstname = "";
            _secondname = "";
        }

        public Person(string firstname, string secondname, DateTime date)
        {
            _firstname = firstname;
            _secondname = secondname;
            _date = date;
        }

        public string name
        {
            get
            {
                return _firstname;
            }
            set
            {
                _firstname = value;
            }
        }

        public string surname
        {
            get
            {
                return _secondname;
            }
            set
            {
                _secondname = value;
            }
        }

        public int Year
        {
            get
            {
                return _date.Year;
            }
            set
            {
                _date = new DateTime(value, _date.Month, _date.Day);
            }
        }

        public override string ToString()
        {
            return "Name " + _firstname + " Surname " + _secondname + " birthdate " + _date;
        }

        public virtual string ToShortString()
        {
            return "Name " + _firstname + " Surname " + _secondname;
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType() && obj != null)
                return false;
            else
            {
                Person p = (Person)obj;
                return (p._firstname == _firstname) && (p._secondname == _secondname) && (p._date == _date);
            }
        }

        public static bool operator !=(Person obj1, Person obj2)
        {
            return !(obj1._firstname == obj2._firstname && obj1._secondname == obj2._secondname && obj1._date == obj2._date);
        }

        public static bool operator ==(Person obj1, Person obj2)
        {
            return (obj1._firstname == obj2._firstname) && (obj1._secondname == obj2._secondname) && (obj1._date == obj2._date);
        }

        public override int GetHashCode()
        {
            int hash = 17;
            hash = 17 + _firstname.GetHashCode();
            hash = 17 + _secondname.GetHashCode();
            hash = 17 + _date.GetHashCode();
            return hash;
        }

        public virtual object DeepCopy()
        {
            Person p = new Person(_firstname, _secondname, _date);
            return p;
        }
    }
}

