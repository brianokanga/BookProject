using System;

namespace LiskovSubstitution
{
    class Program
    {
        public static int Area(Rectangle r) => r.Width * r.Height;
        static void Main(string[] args)
        {
            var rc = new Rectangle(222,333);
            Console.WriteLine($"{rc} has an area of {Area(rc)}");

            Console.WriteLine();

            Rectangle sq = new Square();
            sq.Width = 4;

            Console.WriteLine($"{sq} has an area of {Area(sq)}");
        }
    }
}
