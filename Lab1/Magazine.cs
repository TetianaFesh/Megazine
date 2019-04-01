using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    enum Frequency
    {
        Weekly,
        Monthly,
        Yearly
    }

    class Magazine
    {
        private string _name { get; set; }
        private Frequency _frequency { get; set; }
        private DateTime _date { get; set; }
        private int _circulation { get; set; }
        private Article[] _articles { get; set; }

        public Magazine()
        {
            _name = "";
            _date = DateTime.Now;
            _circulation = 0;
            _articles = new Article[0];
            _frequency = Frequency.Weekly;
        }

        public Magazine(string newname, Frequency newfrequency, DateTime newdate, int newcirculation, Article[] article)
        {
            _name = newname;
            _frequency = newfrequency;
            _date = newdate;
            _circulation = newcirculation;
            _articles = article;
        }

        public double averagerate()
        {
            if (_articles.Length == 0)
            {
                return 0.0F;
            }
            else
            {
                double value = 0.0;
                for (int i = 0; i < _articles.Length; i++)
                {
                    value += _articles[i].Rate;
                }
            return value/_articles.Length;
            }
        }

        public Boolean this[Frequency index]
        {
            get
            {
                return _frequency == index;
            }
        }

        public void AddArticles(Article[] Article)
        {
            if (_articles.Length == 0)
            {
                for (int i = 0; i < Article.Length; i++)
                {
                    _articles[i] = Article[i];
                }
            }
            else
            {
                int j = 0;
                Article[] temp = _articles;
                _articles = new Article[_articles.Length + Article.Length];
                for (int i = 0; i < temp.Length; i++)
                {
                    _articles[i] = temp[i];
                }
                for (int i = temp.Length; i < _articles.Length; i++)
                {
                    _articles[i] = Article[j++];
                }
            }  
        }

        public override string ToString()
        {
            string text = null;
            for (int i = 0; i < _articles.Length; i++)
            {
                text += _articles[i].ToString() + '\n';
            }
            return "name " + _name + "\nfrequency " + _frequency + "\ndate " + _date + "\ncirculation " + _circulation + "\narticles " + text;
        }

        public virtual string ToShortString()
        {
            return "name " + _name + "\nfrequency " + _frequency + "\ndate " + _date + "\ncirculation " + _circulation + "\naverage rate " + averagerate();
        }
    }
}
