using System.ComponentModel;
using vizibicikli;
using System.Linq;

namespace Vizibicikli
{
    internal class Program
    {
        static List<Kolcsonzes> kolcsonzesek = new List<Kolcsonzes>();
        static void Main(string[] args)
        {
            //Hagyományos technika
            StreamReader sr = new StreamReader("DataSource\\kolcsonzesek.txt");
            sr.ReadLine();
            while (!sr.EndOfStream)
            {
                var mezok = sr.ReadLine().Split(';');

                Kolcsonzes uj = new Kolcsonzes(mezok[0],
                                               mezok[1][0],
                                               int.Parse(mezok[2]),
                                               int.Parse(mezok[3]),
                                               int.Parse(mezok[4]),
                                               int.Parse(mezok[5]));
            }
            sr.Close();

            // LINQ + Foreach
            kolcsonzesek.Clear();

            foreach (var sor in File.ReadAllLines("DataSource\\kolcsonzesek.txt"))
            {
                kolcsonzesek.Add(new Kolcsonzes(sor));
            }



            //LINQ
            List<Kolcsonzes> masikLista
                = File.ReadAllLines("DataSource\\kolcsonzesek.txt")
                      .Skip(1)
                      .Select(x => new Kolcsonzes(x))
                      .ToList();

            
            Console.WriteLine($"5. feladat: Napi kölcsönzések száma: {kolcsonzesek.Count}");


            Console.Write($"6. feladat: Kérek egy nevet:");
            String nev = "Kata";
            Console.WriteLine(nev);

            if (kolcsonzesek.Count(x => x.Nev == "Kata") == 0)
            {
                Console.WriteLine("Nem volt ilyen nevű kölcsönző");

            }
            else {
                Console.WriteLine($"\t{nev} kölcsönzései: ");

                
                }
                 
            }
        }
    }
