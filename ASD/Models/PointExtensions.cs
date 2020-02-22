using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace ASD.Models
{
    public static class PointExtensions 
    {
        public static string Wyswietl(this Point point)
        {
            return $"[X:{point.Y}, Y:{point.X}]";
        }
    }
}