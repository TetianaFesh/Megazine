using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    enum Frequency
    {
        Weekly,
        Monthly,
        Yearly

    }

    class Magazine : Edition, IRateandCopy
    {
        private Frequency _frequency;
        private List<Person> _personList;
        private List<Article> _articleList;
        public double _Rating { get { return _Rating; } }

        public Magazine(Frequency newfrequency, string newname, DateTime newdate, int newcirculation, List <Person> editors, List<Article> article) : base(newname, newdate, newcirculation)
        {
            _frequency = newfrequency;
            _personList = new List<Person>(editors);
            _articleList = new List<Article>(article);
        }

        public Magazine() : base()
        {
            _frequency = Frequency.Monthly;
            _personList = new List<Person>();
            _articleList = new List<Article>();
        }

        public double averagerate
        {
            get
            {
                if (_articleList == null)
                {
                    return 0.0F;
                }
                else
                {
                    double value = 0.0;
                    foreach (Article article in _articleList)
                    {
                        value += article.Rate;
                    }
                    return value / _articleList.Count;
                }
            }
        }

        public List <Article> ArticleList
        {
            get
            {
                return _articleList;
            }
        }
        
        public List <Person> PersonList
        {
            get
            {
                return _personList;
            }
        }

        public void AddArticle(params Article[] article)
        {
            if (_articleList == null)
            {

                _articleList = new List <Article>(article);
            }
            else
            {
                    _articleList.AddRange(article);
            }
        }

        public void AddEditors(params Person[] editors)
        {
            if (_personList == null)
            {

                _personList = new List<Person>(editors);
            }
            else
            {
                _personList.AddRange(editors);
            }
        }

        public override string ToString()
        {
            string articles = null;
            string editors = null;
            foreach (Article article in _articleList)
            {
                articles += article.ToString() + '\n';
            }
            foreach (Person editor in _personList)
            {
                editors += editor.ToString() + '\n';
            }
            return "name " + _name + "\nfrequency " + _frequency + "\ndate " + _date + "\ncirculation " + _circulation + "\narticles\n" + articles + "\neditors\n" + editors;
        }

        public virtual string ToShortString()
        {
            return "name " + _name + "\nfrequency " + _frequency + "\ndate " + _date + "\ncirculation " + _circulation + "\naverage rate " + averagerate;
        }

        public override object DeepCopy()
        {
            List<Person> personlist = new List<Person>();
            foreach (Person editor in _personList)
            {
                personlist.Add((Person)editor.DeepCopy());
            }
            List<Article> articlelist = new List<Article>();
            foreach (Article article in _articleList)
            {
                articlelist.Add((Article)article.DeepCopy());
            }
            Magazine a = new Magazine(_frequency, _name, _date, _circulation, personlist, articlelist);
            return a;
        }

        public Edition EditionBase
        {
            get
            {
                return new Edition(_name, _date, _circulation);
            }
            set
            {
                _name = value.Name;
                _date = value.Date;
                _circulation = value.Circulation;
            }
        }

        public IEnumerable<Article> GetArticle(double rating)
        {
            foreach (Article article in _articleList)
            {
                if (article.Rate > rating)
                    yield return article;
            }
        }

        public IEnumerable<Article> ContainWord(string word)
        {
            foreach (Article article in _articleList)
            {
                string[] nameofarticle = article.Title.Split(' ');
                foreach (string words in nameofarticle)
                {
                    if (words == word)
                    {
                        yield return article;
                    }
                }
            }
        }
    }
}
