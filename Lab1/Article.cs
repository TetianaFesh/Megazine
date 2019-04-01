using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class Article
    {
        Person _author { get; set; }
        private string _title { get; set; }
        private double _rate;

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

        public Person person
        {
            get
            {
                return _author;
            }
            set
            {
                _author = value;
            }
        }

        public override string ToString()
        {
            return _author.ToString() + " title " + _title + " rate " + _rate;
        }
    }
}
