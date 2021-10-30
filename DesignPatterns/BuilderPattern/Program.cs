using System;

namespace BuilderPattern
{
    abstract class Shape 
    {
        public int Area { get; set; }
        public string Color { get; set; }
    }

    class Square : Shape 
    {
        public int Side => Area / 2;
    }

    class Circle : Shape 
    {
        public double Radius => Math.Sqrt(Area / Math.PI);
    }

    interface IShapeBuilder 
    {
        IShapeBuilder SetColor(string color);
        IShapeBuilder SetArea(int area);
        public Shape Build();
    }

    class CircleBuilder : IShapeBuilder
    {
        private Shape Circle = new Circle();

        public IShapeBuilder SetArea(int area)
        {
            Circle.Area = area;
            return this;
        }

        public IShapeBuilder SetColor(string color)
        {
            Circle.Color = color;
            return this;
        }

        public Shape Build() 
        {
            return Circle;
        }
    }
    class SquareBuilder : IShapeBuilder
    {
        private Shape Square = new Square();

        public IShapeBuilder SetArea(int area)
        {
            Square.Area = area;
            return this;
        }

        public IShapeBuilder SetColor(string color)
        {
            Square.Color = color;
            return this;
        }

        public Shape Build()
        {
            return Square;
        }
    }

    class Program
    {
        //This is fluent builder pattern with method chaining

        static void Main(string[] args)
        {
            IShapeBuilder squareBuilder = new SquareBuilder();
            var square = squareBuilder.SetArea(16).SetColor("green").Build() as Square;
            Console.WriteLine($"Side of square : {square.Side} and color of square : {square.Color}");
            Console.WriteLine("--------------------------------");
            IShapeBuilder circleBuilder = new CircleBuilder();
            var circle = circleBuilder.SetArea(16).SetColor("yellow").Build() as Circle;
            Console.WriteLine($"Radius of circle : {circle.Radius} and color of circle : {circle.Color}");
        }
    }
}
