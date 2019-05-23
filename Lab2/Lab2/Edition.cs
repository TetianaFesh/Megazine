using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    class Edition
    {
        protected string _name;
        protected DateTime _date;
        protected int _circulation;

        public Edition(string newname, DateTime newdate, int newcirculation)
        {
            _name = newname;
            _date = newdate;
            _circulation = newcirculation;
        }

        public Edition()
        {
            _name = "Default";
            _date = DateTime.Now;
            _circulation = 0;
        }

        public virtual object DeepCopy()
        {
            Edition e = new Edition(_name, _date, _circulation);
            return e;
        }

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        public DateTime Date
        {
            get
            {
                return _date;
            }
            set
            {
                _date = value;
            }
        }

        public int Circulation
        {
            get
            {
                return _circulation;
            }
            set
            {
                if (value < 0)
                {
                    throw new Exception("Incorrect value. Value must be positive.");
                }
                else _circulation = value;
            }
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType() && obj != null)
                return false;
            else
            {
                Edition p = (Edition)obj;
                return (p._name == _name) && (p._date == _date) && (p._circulation == _circulation);
            }
        }

        public static bool operator !=(Edition obj1, Edition obj2)
        {
            return !(obj1._name == obj2._name && obj1._circulation == obj2._circulation && obj1._date == obj2._date);
        }

        public static bool operator ==(Edition obj1, Edition obj2)
        {
            return (obj1._name == obj2._name) && (obj1._circulation == obj2._circulation) && (obj1._date == obj2._date);
        }

        public override int GetHashCode()
        {
            int hash = 21;
            hash = 21 + _name.GetHashCode();
            hash = 21 + _circulation.GetHashCode();
            hash = 21 + _date.GetHashCode();
            return hash;
        }

        public override string ToString()
        {
            return "Name " + _name + " Date " + _date + " Circulation " + _circulation;
        }
    }
}
