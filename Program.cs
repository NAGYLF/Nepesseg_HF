using System;
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
            f5();
            f6();
            f7();
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
            Console.WriteLine("f5");
            Console.WriteLine($"A vizsgálat idején {adatok.Find(item => item.Orszag == "Kína").Nepesseg - adatok.Find(item => item.Orszag == "India").Nepesseg} fővel éltek többen Kínában mint indiában");
            Console.WriteLine();
        }
        static void f6()
        {
            Console.WriteLine("f6");
            Adat ideiglenef6 = adatok.Find(item7 => item7.Nepesseg == (adatok.FindAll(item => item.Nepesseg != adatok.Max(item2 => item2.Nepesseg)).FindAll(item3 => item3.Nepesseg != adatok.FindAll(item => item.Nepesseg != adatok.Max(item4 => item4.Nepesseg)).Max(item5 => item5.Nepesseg))).Max(item6 => item6.Nepesseg));
            Console.WriteLine($"A 3. legnépesebb ország: {ideiglenef6.Orszag} népessége: {ideiglenef6.Nepesseg}");
            Console.WriteLine();
        }
        static void f7()
        {
            Console.WriteLine("f7");
            List<Adat> ideiglenesf7 = adatok.FindAll(item=>item.FoVaros30_koncentracio());
            Console.WriteLine("A következő országok lakossága több mint 30% a fővárosban lakik:");
            foreach (Adat item in ideiglenesf7)
            {
                Console.WriteLine($"{"\t"}{item.Orszag}  ({item.FoVaros})");
            }
            Console.WriteLine();
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
            FoVarosNepesseg = int.Parse(tomb[4])*1000;
        }

        public double nepsuruseg()
        {
            return Math.Round(Convert.ToDouble(Nepesseg) / Convert.ToDouble(Terulet),0);
        }

        public bool FoVaros30_koncentracio()
        {
            return Convert.ToDouble(Nepesseg)/100*30<FoVarosNepesseg;
        }
    }
}
