using System;

namespace VisitorPattern
{
    interface IVisitable
    {
        void Accept(IVisitor visitor);
    }
    class Circle : IVisitable
    {
        public Circle(int Radius)
        {
            this.Radius = Radius;
        }
        public int Radius { get; set; }
        public double Area => Radius * Radius * Math.PI;
        public string Color { get; set; }

        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    interface IVisitor
    {
        void Visit(IVisitable v)
        {
            Console.WriteLine("Not implemented functionality");
        }
    }
    class RadiusVisitor :IVisitor
    {
        public RadiusVisitor(int Modifier)
        {
            this.Modifier = Modifier;
        }
        public int Modifier { get; set; }
        void IVisitor.Visit(IVisitable v)
        {
            var circle = v as Circle;
            circle.Radius *= Modifier;
        }
    }
    class ColorVisitor : IVisitor
    {
        public ColorVisitor(string Color)
        {
            this.Color = Color;
        }
        public string Color { get; set; }
        void IVisitor.Visit(IVisitable v)
        {
            var circle = v as Circle;
            circle.Color = Color;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Circle c = new Circle(3);
            Console.WriteLine($"Color:{c.Color ?? "none"} and Area:{c.Area}");
            IVisitor colorv = new ColorVisitor("green");
            IVisitor radiusv = new RadiusVisitor(2);
            Console.WriteLine("--------------");
            c.Accept(colorv);
            Console.WriteLine($"Color:{c.Color ?? "none"} and Area:{c.Area}");
            Console.WriteLine("--------------");
            c.Accept(radiusv);
            Console.WriteLine($"Color:{c.Color ?? "none"} and Area:{c.Area}");

        }
    }
}
