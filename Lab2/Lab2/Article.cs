using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    class Article : IRateandCopy
    {
        Person _author { get; set; }
        private string _title;
        private double _rate;
        public double _Rating { get { return _Rating; } }

        public Article()
        {
            _author = new Person();
            _title = "";
            _rate = 0.0F;
        }

        public Article(Person newperson, string newtitle, double newrate)
        {
            _author = newperson;
            _title = newtitle;
            _rate = newrate;
        }

        public double Rate
        {
            get
            {
                return _rate;
            }
            set
            {
                _rate = value;
            }
        }

        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value;
            }
        }

        public override string ToString()
        {
            return _author.ToString() + " title " + _title + " rate " + _rate;
        }

        public virtual object DeepCopy()
        {
            Article a = new Article((Person)_author.DeepCopy(), _title, _rate);
            return a;
        }
    }
}
