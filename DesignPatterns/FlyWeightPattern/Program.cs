using System;
using System.Collections;
using System.Collections.Generic;

namespace FlyWeightPattern
{
    interface IShape 
    {
        void Print();
        void SetColor(ConsoleColor color);
        public ConsoleColor Color { get; set; }
    }
    class Circle : IShape
    {
        public ConsoleColor Color { get; set; }

        public void Print()
        {
            Console.WriteLine($"{nameof(Circle)} with {Color} color is being printed");
        }

        public void SetColor(ConsoleColor color)
        {
            Color = color;
        }
    }
    class Rectangle : IShape
    {
        public ConsoleColor Color { get; set; }

        public void Print()
        {
            Console.WriteLine($"{nameof(Rectangle)} with {Color} color is being printed");
        }
        public void SetColor(ConsoleColor color)
        {
            Color = color;
        }
    }

    //Flyweight pattern is used to reduce the number of objects created,
    //to decrease memory and resource usage. As a result, it increases performance.
    //Flyweight pattern tries to reuse already existing similar kind objects by storing them
    //and creates a new object when no matching object is found

    //There are wo states in flyweight pattern: 
    //Intrinsic - Intrinsic states are things that are constants and stored in memory.
    //In our case shapes are constant

    //Extrinsic - Extrinsic states are things that are generally calculated in runtime.
    //Color of shape is extrinsic
    static class ShapeFac 
    {
        private static Dictionary<string,IShape> Shapes = new Dictionary<string, IShape>();
        public static IShape GetData(string key) 
        {
            var lowered = key.ToLower();
            IShape SwitchKey(string lowered) => key switch
            {
                "circle" => new Circle(),
                "rectangle" => new Rectangle(),
                _ => null
            };
            return Shapes.ContainsKey(lowered) ? Shapes[lowered] : SwitchKey(lowered);
        }
    }

    class Program
    {

        static void Main(string[] args)
        {
            Circle circ = (Circle)ShapeFac.GetData("circle");
            circ.Color = ConsoleColor.DarkRed;
            Circle circ2 = (Circle)ShapeFac.GetData("circle");
            circ2.Color = ConsoleColor.Blue;
            //Same circle data but with different colors:
            circ.Print();
            circ2.Print(); 
        }
    }
}
