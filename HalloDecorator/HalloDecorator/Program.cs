// See https://aka.ms/new-console-template for more information
using HalloDecorator;

Console.WriteLine("Hello Decorator");


var p1 = new Käse(new Salami(new Käse(new Pizza())));

Console.WriteLine($"{p1.Name} {p1.Price}");


var b1 = new Käse(new Salami(new Käse(new Brot())));

Console.WriteLine($"{b1.Name} {b1.Price}");

var p = new Party();
p.Start += P_Start;
p.Start += P_Start;
p.Start += P_Start;
p.Start += P_Start;
p.Start -= P_Start;
p.Start -= P_Start;

void P_Start()
{
    Console.WriteLine("SAUFEN!!!");
}

p.StarteParty();


class Party
{
    public event Action Start;

    public void StarteParty()
    {
        Start.Invoke();
    }
}
