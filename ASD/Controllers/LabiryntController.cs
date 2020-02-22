using ASD.Models.Labirynt;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASD.Controllers
{
    public class LabiryntController : Controller
    {
        public ActionResult Index()
        {
            LabiryntViewModel model = new LabiryntViewModel(10, 10, 30);
            WyznaczOdleglosci(model);
            WyznaczSciezke(model);


            return View(model);
        }

        private static void WyznaczOdleglosci(LabiryntViewModel model)
        {
            Queue<Point> kolejka = new Queue<Point>();
            model.Odleglosci[model.Poczatek.X, model.Poczatek.Y] = 0;
            kolejka.Enqueue(model.Poczatek);


            while (kolejka.Count > 0)
            {
                int x, y;

                if (kolejka.Dequeue() is Point punkt && !(punkt.X == model.Koniec.X && punkt.Y == model.Koniec.Y))
                {
                    // gora
                    x = punkt.X;
                    y = punkt.Y - 1;

                    if (y >= 0 && model.Labirynt[x, y] == 1 && model.Odleglosci[x, y] == -1)
                    {
                        kolejka.Enqueue(new Point(x, y));
                        model.Odleglosci[x, y] = model.Odleglosci[punkt.X, punkt.Y] + 1;
                    }

                    // dol
                    x = punkt.X;
                    y = punkt.Y + 1;

                    if (y < model.Labirynt.GetLength(1) && model.Labirynt[x, y] == 1 && model.Odleglosci[x, y] == -1)
                    {
                        kolejka.Enqueue(new Point(x, y));
                        model.Odleglosci[x, y] = model.Odleglosci[punkt.X, punkt.Y] + 1;
                    }

                    // lewo
                    x = punkt.X - 1;
                    y = punkt.Y;

                    if (x >= 0 && model.Labirynt[x, y] == 1 && model.Odleglosci[x, y] == -1)
                    {
                        kolejka.Enqueue(new Point(x, y));
                        model.Odleglosci[x, y] = model.Odleglosci[punkt.X, punkt.Y] + 1;
                    }

                    // prawo
                    x = punkt.X + 1;
                    y = punkt.Y;

                    if (x < model.Labirynt.GetLength(0) && model.Labirynt[x, y] == 1 && model.Odleglosci[x, y] == -1)
                    {
                        kolejka.Enqueue(new Point(x, y));
                        model.Odleglosci[x, y] = model.Odleglosci[punkt.X, punkt.Y] + 1;
                    }
                }
                else
                {
                    break;
                }
            }
        }
        private static void WyznaczSciezke(LabiryntViewModel model)
        {
            if (model.Odleglosci[model.Koniec.X, model.Koniec.Y] > 0)
            {
                Point skoczek = new Point(model.Koniec.X, model.Koniec.Y);
                model.Sciezka.Add(model.Koniec);

                while (model.Odleglosci[skoczek.X, skoczek.Y] > 0)
                {
                    int x, y;


                    // if (skoczek is Point punkt && !(punkt.X == start.X && punkt.Y == start.Y))
                    {
                        // gora
                        x = skoczek.X;
                        y = skoczek.Y - 1;

                        if (y >= 0 && model.Odleglosci[x, y] == model.Odleglosci[skoczek.X, skoczek.Y] - 1)
                        {
                            model.Sciezka.Insert(0, new Point(x, y));
                            skoczek = new Point(x, y);
                            continue;
                        }

                        // dol
                        x = skoczek.X;
                        y = skoczek.Y + 1;

                        if (y < model.Labirynt.GetLength(1) && model.Odleglosci[x, y] == model.Odleglosci[skoczek.X, skoczek.Y] - 1)
                        {
                            model.Sciezka.Insert(0, new Point(x, y));
                            skoczek = new Point(x, y);
                            continue;
                        }

                        // lewo
                        x = skoczek.X - 1;
                        y = skoczek.Y;

                        if (x >= 0 && model.Odleglosci[x, y] == model.Odleglosci[skoczek.X, skoczek.Y] - 1)
                        {
                            model.Sciezka.Insert(0, new Point(x, y));
                            skoczek = new Point(x, y);
                            continue;
                        }

                        // prawo
                        x = skoczek.X + 1;
                        y = skoczek.Y;

                        if (x < model.Labirynt.GetLength(0) && model.Odleglosci[x, y] == model.Odleglosci[skoczek.X, skoczek.Y] - 1)
                        {
                            model.Sciezka.Insert(0, new Point(x, y));
                            skoczek = new Point(x, y);
                            continue;
                        }
                    }
                }
            }
        }
    }
}