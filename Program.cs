﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Nepesseg
{
    internal class Program
    {
        public static List<Adat> adatok;
        static void Main(string[] args)
        {
            adatok = new List<Adat>();
            beolvasas();
            f3();
            f4();
            Console.ReadLine();
        }

        static void beolvasas()
        {
            StreamReader sr = new StreamReader("adatok-utf8.txt");
            sr.ReadLine();
            while (!sr.EndOfStream)
            {
                adatok.Add(new Adat(sr.ReadLine()));
            }
            sr.Close();
        }
        static void f3()
        {
            Console.WriteLine("f3");
            Console.WriteLine($"az állomány {adatok.Count} ország adatait tartalmazza");
            Console.WriteLine();
        }
        static void f4()
        {
            Console.WriteLine("f4");
            Console.WriteLine($"Kína népsűrűsége: {adatok.Find(item=>item.Orszag=="Kína").nepsuruseg()}fő/km2");
            Console.WriteLine();
        }
        static void f5()
        {

        }
    }

    class Adat
    {
        public string Orszag;
        public int Terulet;
        public int Nepesseg;
        public string FoVaros;
        public int FoVarosNepesseg;

        public Adat(string sor)
        {
            string[] tomb = sor.Split(';');
            Orszag = tomb[0];
            Terulet = int.Parse(tomb[1]);
            Nepesseg = int.Parse(tomb[2].Contains("g") ? tomb[2].Replace("g","0000") : tomb[2] );
            FoVaros = tomb[3];
            FoVarosNepesseg = int.Parse(tomb[4]);
        }

        public double nepsuruseg()
        {
            return Math.Round(Convert.ToDouble(Nepesseg) / Convert.ToDouble(Terulet),0);
        }
    }
}
