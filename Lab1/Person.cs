using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
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
    }
}
