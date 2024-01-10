using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HalloBuilder
{
    internal class Schrank
    {
        private Schrank()
        { }

        public int AnzahlTüren { get; private set; }
        public int AnzahlBöden { get; private set; }
        public string Farbe { get; private set; }
        public Oberfläche Oberfläche { get; private set; }

        internal class Builder
        {
            Schrank schrank = new Schrank();
            public Schrank Create() { return schrank; } 

            public Builder SetTüren(int anzTüren)
            {
                if (anzTüren < 2 || anzTüren > 7)
                    throw new ArgumentException("Zuviele oder zuwenig Türen :-O");

                schrank.AnzahlTüren = anzTüren;

                return this;
            }

            public Builder SetBöden(int anzBöden)
            {
                if (anzBöden < 0 || anzBöden > 6)
                    throw new ArgumentException("Zuviele oder zuwenig Böden :-O");

                schrank.AnzahlBöden = anzBöden;

                return this;
            }

            public Builder SetFarbe(string farbe)
            {
                schrank.Oberfläche = Oberfläche.Lackiert;
                schrank.Farbe = farbe;

                return this;
            }

            public Builder SetOberfläche(Oberfläche oberfläche)
            {
                if (oberfläche == Oberfläche.Natur)
                    schrank.Farbe = "";

                schrank.Oberfläche = oberfläche;

                return this;
            }
        }
    }

    internal enum Oberfläche
    {
        Natur,
        Lackiert
    }
}
