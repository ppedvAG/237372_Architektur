// See https://aka.ms/new-console-template for more information
using HalloBuilder;

Console.WriteLine("Hello, World!");


Schrank schrank = new Schrank.Builder()
                             .SetTüren(4)
                             .SetBöden(6)
                             .Create();


Schrank schrankBlau = new Schrank.Builder()
                             .SetTüren(4)
                             .SetBöden(6)
                             .SetFarbe("blau")
                             .Create();

Console.WriteLine("Ende");