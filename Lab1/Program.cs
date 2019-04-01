using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            Magazine one = new Magazine();
            Article[] article = new Article[3];
            article[0] = new Article(new Person("Tess", "Geritsen", new DateTime(1990, 10, 6)), "Fire!", 4.2);
            article[1] = new Article(new Person("Lion", "Getenberg", new DateTime(1995, 6, 13)),"Vegetables!", 4.8);
            article[2] = new Article(new Person("Jey", "Hirston", new DateTime(1997, 11, 24)), "Fruits!", 4.0);
            one = new Magazine("Viva", Frequency.Monthly, DateTime.Now, 3, article);
            Console.WriteLine(one.ToShortString());
            Console.WriteLine(one.ToString());
            Console.WriteLine(one[Frequency.Yearly]);
            Article[] articles = new Article[2];
            articles[0] = new Article(new Person("Stephen", "King", new DateTime(1989, 5, 6)), "Joyland!", 5.0);
            articles[1] = new Article(new Person("Dan", "Braun", new DateTime(1970, 12, 23)), "Digital castle!", 4.8);
            one.AddArticles(articles);
            Console.WriteLine(one.ToString());
            string dimension = Console.ReadLine();
            string[] dim = dimension.Split(' ');
            int rows = Convert.ToInt32(dim[0]);
            int column = Convert.ToInt32(dim[1]);

            Stopwatch stopwatch1 = new Stopwatch();
            stopwatch1.Start();
            Article[] art1 = new Article[rows * column];
            for (int i = 0; i < column * rows; i++)
            {
                art1[i] = new Article();
            }
            stopwatch1.Stop();
            TimeSpan ts = stopwatch1.Elapsed;
            string elasedTime = String.Format("{0:00}:{1:00}:{2:00}:{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds);
            Console.WriteLine("RunTime1 = " + elasedTime);

            Stopwatch stopwatch2 = new Stopwatch();
            stopwatch2.Start();
            Article[,] art2 = new Article[rows, column];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    art2[i,j] = new Article();
                }
            }
            stopwatch2.Stop();
            TimeSpan ts2 = stopwatch2.Elapsed;
            string elasedTime2 = String.Format("{0:00}:{1:00}:{2:00}:{3:00}", ts2.Hours, ts2.Minutes, ts2.Seconds, ts2.Milliseconds);
            Console.WriteLine("RunTime2 = " + elasedTime2);

            Stopwatch stopwatch3 = new Stopwatch();
            stopwatch3.Start();
            Article[][] art3 = new Article[rows][];
            for (int i = 0; i < rows; i++)
            {
                art3[i] = new Article[column];
                for (int j = 0; j < column; j++)
                {
                    art3[i][j] = new Article();
                }
            }
            stopwatch3.Stop();
            TimeSpan ts3 = stopwatch3.Elapsed;
            string elasedTime3 = String.Format("{0:00}:{1:00}:{2:00}:{3:00}", ts3.Hours, ts3.Minutes, ts3.Seconds, ts3.Milliseconds);
            Console.WriteLine("RunTime3 = " + elasedTime3);
            Console.ReadLine();
        }
    }
}
