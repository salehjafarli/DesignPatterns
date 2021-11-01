using System;

namespace TemplateMethodPattern
{
    //The Template Method Design Pattern defines a sequence of steps of an algorithm
    //and allows the subclasses to override the steps but not allowed to change the sequence.
    //The Key to the Template Design Pattern is that we put the general logic in the abstract parent class
    //and let the child classes define the specifics.
    abstract class House 
    {
        public House()
        {
            BuildHouse();
        }
        public void BuildHouse()
        {
            BuildFoundation();
            BuildPillars();
            BuildWalls();
            BuildWindows();
            Console.WriteLine("House is built");
        }
        public abstract void BuildFoundation();
        public abstract void BuildPillars();
        public abstract void BuildWalls();
        public abstract void BuildWindows(); 
    }

    class Villa : House
    {
        public override void BuildFoundation()
        {
            Console.WriteLine($"Foundation is built for {nameof(Villa)}");
        }

        public override void BuildPillars()
        {
            Console.WriteLine($"Pillars is built for {nameof(Villa)}");

        }

        public override void BuildWalls()
        {
            Console.WriteLine($"Walls is built for {nameof(Villa)}");
        }

        public override void BuildWindows()
        {
            Console.WriteLine($"Windows is built for {nameof(Villa)}");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            House villa = new Villa();
        }
    }
}
