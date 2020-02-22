using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace ASD.Models.Labirynt
{
    public class LabiryntViewModel
    {

        public int[,] Labirynt { get; set; }
        public int[,] Odleglosci { get; set; }
        public Point Poczatek { get; set; }
        public Point Koniec { get; set; }
        public List<Point> Sciezka { get; set; }

        public LabiryntViewModel(int x, int y, int p) {
            if (p < 0 || p > 100)
                throw new ArgumentException("p z zkresu 0 - 100");

            Labirynt = new int[x, y];
            Odleglosci = new int[x, y];

            Random r = new Random();
            Poczatek = new Point(r.Next(x), r.Next(y));
            Koniec = new Point(r.Next(x), r.Next(y));
            

            Sciezka = new List<Point>();

            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    Labirynt[i, j] = 1;
                    Odleglosci[i, j] = -1;
                    //Labirynt[Poczatek.X, Poczatek.Y] = 'P';
                    //Labirynt[Koniec.X, Koniec.Y] = 'K';
                }
            }

            int procent = x * y * p / 100;

            for (int i = 0; i < procent; i++)
            {
                var xx = r.Next(x);
                var yy = r.Next(x);
                Labirynt[xx, yy] = 0;
            }

            Labirynt[Poczatek.X, Poczatek.Y] = 1;
            Labirynt[Koniec.X, Koniec.Y] = 1;
        }


    }
}