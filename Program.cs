using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kétbalkezesek
{
    internal class Program
    {

        static List<Vegyielem> vegyielemek = new List<Vegyielem>();
        static void Main(string[] args)
        {
         /*   var ell = File.ReadAllLines("felfedezesek.csv");
            foreach (var line in ell)
            {
                Console.WriteLine(line);
            }*/

            string[] read = File.ReadAllLines("felfedezesek.csv", Encoding.UTF8).Skip(1).ToArray();
            for (int i = 0; i < read.Length; i++)
            {
                string[] data = read[i].Split(';');
               Vegyielem vegyielem = new Vegyielem(
                                        data[0],
                                        data[1],
                                        data[2],
                                        Convert.ToInt32(data[3]),
                                        data[4]);
                vegyielemek.Add(vegyielem);

            }

            Console.WriteLine($"1.feladat: Sorok szama : {vegyielemek.Count} ");


// ----------------------------------------------------------------------------------------------

            string keresettElemNeve = null;

            for (int i = 4; i < vegyielemek.Count; i++)
            {
                keresettElemNeve = vegyielemek[i].Elem;
                break;
            }
            Console.WriteLine($"2.feladat: A lista 5.indexű elemének neve: {keresettElemNeve}");


            // LINQ:
            string elemNeve = (from adat in vegyielemek.Skip(4)
                               select adat.Elem).FirstOrDefault();

            Console.WriteLine($"2.feladat: A lista 5.indexű elemének neve: {elemNeve}");

//-----------------------------------------------------------------------------------------------

            int keresettRendszam = 80;

            var keresettElem = vegyielemek
                               .Where(x => x.Rendszam == keresettRendszam)
                               .FirstOrDefault();
                        
            Console.WriteLine($"3.feladat: A vegyielemek 80. rendszamú elemének neve:{keresettElem.Elem}, jele:{keresettElem.Vegyjel}");

//-----------------------------------------------------------------------------------------------


            Console.WriteLine("4.feladat: 1774-ben felfedezett elemek listaja:");
            List<string> okoriak = new List<string>();

            foreach (var x in vegyielemek)
            {
                if (x.Ev == "1774")
                {
                    okoriak.Add($"Elem neve:{x.Elem},  rendszama:{x.Rendszam},  vegyjele:{x.Vegyjel}");
                }                
            }

            foreach (var okoriElem in okoriak)
            {
                Console.WriteLine($"\t {okoriElem}");
            }

//-----------------------------------------------------------------------------------------------


            Console.Write("5.feladat: Adjon meg egy évszamot:");
            string bekertEv =Console.ReadLine();

            if (int.TryParse(bekertEv, out int ev))
            {
                int felfedezettElemekSzama = vegyielemek
                    .Where(x => x.Ev == bekertEv)
                    .Count();

                Console.WriteLine($"Az {bekertEv}-ban/ben {felfedezettElemekSzama} elemet fedeztek fel.");
            }
            else
            {
                Console.WriteLine("Érvénytelen évszámformátum.");
            }
            Console.WriteLine();
//-------------------------------------------------------------------------------------------------------------------

            // Összes olyan elemet jelenítse meg, ami H. Davy nevéhez fűződik... 
            

            string felfedezoNev = "H. Davy";

          
          //  Console.WriteLine($"{felfedezoNev} nevéhez fűződő összes elem listaja:");

            var thompsonElemek = vegyielemek
                .Where(x => x.Felfedező == felfedezoNev) 
                .ToList();

            Console.WriteLine("6.feladat: H. Davy nevéhez fűződő összes elem listaja:");

            foreach (var elem in thompsonElemek)
            {
                Console.WriteLine($"\t {elem.Elem},{elem.Rendszam},{elem.Vegyjel}");
            }
         
        // .... ezt mentse el a "vegyielemek.txt" allomanyba.


           StreamWriter sw = new StreamWriter("vegyielemek.txt");
           foreach (var x in vegyielemek)
            {
                if(x.Felfedező== "H. Davy")
                {
                    sw.WriteLine($"\t {x.Elem},{x.Rendszam},{x.Vegyjel}");
                }
            }
            Console.WriteLine("7.feladat:vegyielemek.txt");
            sw.Close();        
        }
    }
}

/*  1.feladat: Sorok szama : 117
2.feladat: A lista 5.indexű elemének neve: ?lom
2.feladat: A lista 5.indexű elemének neve: ?lom
3.feladat: A vegyielemek 80. rendszamú elemének neve:Higany, jele:Hg
4.feladat: 1774-ben felfedezett elemek listaja:
         Elem neve:Oxig?n,  rendszama:8,  vegyjele:O
         Elem neve:Kl?r,  rendszama:17,  vegyjele:Cl
         Elem neve:Mang?n,  rendszama:25,  vegyjele:Mn
5.feladat: Adjon meg egy évszamot:1804
Az 1804-ban/ben 2 elemet fedeztek fel.

6.feladat: H. Davy nevéhez fűződő összes elem listaja:
         K?lium,19,K
         N?trium,11,Na
         B?rium,56,Ba
         Kalcium,20,Ca
         Magn?zium,12,Mg
7.feladat:vegyielemek.txt
Press any key to continue . . . */

