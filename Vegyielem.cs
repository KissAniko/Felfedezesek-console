using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kétbalkezesek
{
    internal class Vegyielem
    {
   

        // Év;     Elem;    Vegyjel;     Rendszám;     Felfedező
        // Ókor;   Arany;   Au;          79;           Ismeretlen

        string ev;
        string elem;
        string vegyjel;
        int rendszam;
        string felfedező;

        public Vegyielem(string ev, string elem, string vegyjel, int rendszam, string felfedező)
        {
            this.ev = ev;
            this.elem = elem;
            this.vegyjel = vegyjel;
            this.rendszam = rendszam;
            this.felfedező = felfedező;
        }

        public string Ev { get => ev; set => ev = value; }
        public string Elem { get => elem; set => elem = value; }
        public string Vegyjel { get => vegyjel; set => vegyjel = value; }
        public int Rendszam { get => rendszam; set => rendszam = value; }
        public string Felfedező { get => felfedező; set => felfedező = value; }
    }
}

