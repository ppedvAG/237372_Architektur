namespace HalloDecorator
{
    interface IComponent
    {
        string Name { get; }
        decimal Price { get; }
    }

    class Pizza : IComponent
    {
        public string Name => "Pizza";

        public decimal Price => 6.9m;
    }

    class Brot : IComponent
    {
        public string Name => "Stulle";

        public decimal Price => 3.5m;
    }

    abstract class Decorator : IComponent
    {
        protected IComponent parent;

        protected Decorator(IComponent parent)
        {
            this.parent = parent;
        }

        public abstract string Name { get; }
        public abstract decimal Price { get; }
    }

    class Salami : Decorator
    {
        public Salami(IComponent parent) : base(parent)
        { }

        public override string Name => parent.Name + " Salami";

        public override decimal Price => parent.Price + 2.5m;
    }

    class Käse : Decorator
    {
        public Käse(IComponent parent) : base(parent)
        { }

        public override string Name => parent.Name + " Käse";

        public override decimal Price => parent.Price + 1.7m;
    }
}
