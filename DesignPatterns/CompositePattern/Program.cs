using System;
using System.Collections.Generic;

namespace CompositePattern
{
    //Composite pattern allows reation of a tree structure
    //A node which has no next nodes is leaf
    //A node which has 1 or more nodes called branch or composite


    public abstract class Component
    {
        protected string name;
        public Component(string name)
        {
            this.name = name;
        }
        public abstract void Add(Component c);
        public abstract void Remove(Component c);
        public abstract void Display(int depth);
    }


    // The 'Composite' class
    public class Composite : Component
    {
        List<Component> children = new List<Component>();
        // Constructor
        public Composite(string name)
            : base(name)
        {
        }
        public override void Add(Component component)
        {
            children.Add(component);
        }
        public override void Remove(Component component)
        {
            children.Remove(component);
        }
        public override void Display(int depth)
        {
            Console.WriteLine(new String('-', depth) + name);
            foreach (Component component in children)
            {
                component.Display(depth + 2);
            }
        }
    }


    // The 'Leaf' class
    public class Leaf : Component
    {
        // Constructor
        public Leaf(string name)
            : base(name)
        {
        }
        public override void Add(Component c)
        {
            Console.WriteLine("Cannot add to a leaf");
        }
        public override void Remove(Component c)
        {
            Console.WriteLine("Cannot remove from a leaf");
        }
        public override void Display(int depth)
        {   
            Console.WriteLine(new String('-', depth) + name);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Composite root = new Composite("root");
            //Adding child nodes to composite element
            root.Add(new Leaf("Leaf A"));
            root.Add(new Leaf("Leaf B"));
            Composite comp = new Composite("Composite X");
            comp.Add(new Leaf("Leaf XA"));
            comp.Add(new Leaf("Leaf XB"));
            // you can add another composite element as child node as well
            root.Add(comp);

            root.Display(1);
        }
    }
}
