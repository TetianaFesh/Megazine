using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            Edition ed1 = new Edition("Hello", new DateTime(2018, 09, 10), 3);
            Edition ed2 = new Edition("Hello", new DateTime(2018, 09, 10), 3);
            Console.WriteLine(ed1 == ed2);
            Console.WriteLine(ed1.GetHashCode() + "\n" + ed2.GetHashCode() + '\n');
            try
            {
                ed1.Circulation = -1;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Magazine magazine = new Magazine();
            Article[] article = new Article[3];
            article[0] = new Article(new Person("Tess", "Geritsen", new DateTime(1990, 10, 6)), "Fire!", 4.2);
            article[1] = new Article(new Person("Lion", "Getenberg", new DateTime(1995, 6, 13)), "Vegetables can go!", 4.8);
            article[2] = new Article(new Person("Jey", "Hirston", new DateTime(1997, 11, 24)), "Fruits can go!", 4.0);
            magazine.AddArticle(article);
            Person[] editors = new Person[3];
            editors[0] = new Person("Tony", "Stark", new DateTime(1990, 10, 6));
            editors[1] = new Person("Natasha", "Roman", new DateTime(1990, 10, 6));
            editors[2] = new Person("Black", "widow", new DateTime(1990, 10, 6));
            magazine.AddEditors(editors);
            Console.WriteLine(magazine.ToString());
            Console.WriteLine(magazine.EditionBase);
            Magazine magazine1 = new Magazine();
            magazine1 = (Magazine) magazine.DeepCopy();
            magazine.Circulation = 10;
            magazine.Name = "Tania";
            Console.WriteLine("Original:\n" + magazine.ToString());
            Console.WriteLine("Copy:\n" + magazine1.ToString());
            Console.WriteLine("Hello \n");
            foreach (Article art in magazine.GetArticle(4.0F))
            {
                Console.WriteLine(art);
            }
            Console.WriteLine("\n");
            foreach (Article art in magazine.ContainWord("can"))
            {
                Console.WriteLine(art);
            }
            Console.ReadLine();
        }
    }
}
