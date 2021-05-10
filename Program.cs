using System;
using System.Collections.Generic;
using System.Threading;

namespace ConsoleApp38
{
    interface IFigura : IComparable<IFigura>
    {
        ConsoleColor K1 { get; set; }

        double Pole();
    }
    class Kolo : IFigura
    {
        private readonly double promien;
        public ConsoleColor K1 { get; set; }
        public Kolo(double promien)
        {
            this.promien = promien;
        }
        public double Pole()
        {
            return Math.Pow(promien, 2) * 3.14;
        }
        public override string ToString()
        {
            Console.ForegroundColor = K1;
            return $"Obiekt: {GetType().Name} \nPromień: {promien} \nPole: {Pole()}";
        }
        public int CompareTo(IFigura f1)
        {
            if (Pole() == f1.Pole())
                return 0;
            else if (Pole() < f1.Pole())
                return -1;
            else return 1;
        }
    }
    class Prostokat : IFigura
    {
        private readonly double a;
        private readonly double b;
        public ConsoleColor K1 { get; set; }
        public Prostokat(double a, double b)
        {
            this.a = a;
            this.b = b;
        }
        public double Pole()
        {
            return a * b;
        }
        public int CompareTo(IFigura f1)
        {
            if (Pole() == f1.Pole())
                return 0;
            else if (Pole() < f1.Pole())
                return -1;
            else return 1;
        }
        public override string ToString()
        {
            Console.ForegroundColor = K1;
            return $"Obiekt: {GetType().Name} \nPole: {Pole()}";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<IFigura> lista = new List<IFigura>
            {
                new Kolo(3),
                new Kolo(8),
                new Prostokat(4, 8),
                new Prostokat(10, 30)
            };

            lista[0].K1 = ConsoleColor.Blue;
            lista[1].K1 = ConsoleColor.Red;
            lista[2].K1 = ConsoleColor.Green;
            lista[3].K1 = ConsoleColor.Yellow;

            Console.WriteLine("Przed sortowaniem");
            Thread.Sleep(2000);
            foreach (IFigura x in lista)
            {
                Console.WriteLine(x);
            }
            Console.WriteLine("Po sortowaniu");
            Thread.Sleep(2000);
            lista.Sort();
            Console.ResetColor();
            foreach (IFigura x in lista)
            {
                Console.WriteLine(x);
            }
            Console.ReadKey();
        }
    }
}
