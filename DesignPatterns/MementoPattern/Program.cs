using System;
using System.Collections.Generic;

namespace MementoPattern
{
    class Product
    {
        public string Name { get; set; }
        public int Cost { get; set; }
    }
    class User 
    {
        public string Username { get; set; }
        public int  Budget { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();
        public void MakePayment(Product p) 
        {
            Products.Add(p);
            Budget -= p.Cost;
            Console.WriteLine($"Payment has been made : Current budget : {Budget}");
        }
        public UserMemento CreateMemento() 
        {
            UserMemento m = new UserMemento()
            {
                Username = Username,
                Budget = Budget
            };
            foreach (var item in Products)
            {
                m.Products.Add(item);
            }
            return m;
        }
        public void Restore(UserMemento m) 
        {
            Console.WriteLine("Restoring Old State...");
            Username = m.Username;
            Budget = m.Budget;
            Products = m.Products;
        }


    }

    class UserMemento 
    {
        public string Username { get; set; }
        public int Budget { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();
    }
    class Caretaker 
    {
        List<UserMemento> mementos = new List<UserMemento>();
        public void AddMemento(UserMemento m) 
        {
            mementos.Add(m);
        }
        public UserMemento Get(int index) 
        {
            return mementos[index];

        }
    }




    class Program
    {
        static void Main(string[] args)
        {
            Caretaker c = new Caretaker();
            Product p = new Product()
            {
                Name = "Banana",
                Cost = 50
            };
            User u = new User()
            {
                Username = "Foo",
                Budget = 200
            };
            var payment1 = u.CreateMemento();
            u.MakePayment(p);
            c.AddMemento(payment1);
            var payment2 = u.CreateMemento();
            u.MakePayment(p);
            c.AddMemento(payment2);

            Console.WriteLine($"User's budget is :{u.Budget} ");
            Console.WriteLine("Products:");
            foreach (var item in u.Products)
            {
                Console.WriteLine("Name:" + item.Name + " Cost:" + item.Cost);
            }

            Console.WriteLine("------------");
            u.Restore(c.Get(1));
            Console.WriteLine($"User's budget is :{u.Budget} ");
            Console.WriteLine("Products:");
            foreach (var item in u.Products)
            {
                Console.WriteLine("Name:"+item.Name+" Cost:"+ item.Cost);
            }

            Console.WriteLine("------------");
            u.Restore(c.Get(0));
            Console.WriteLine($"User's budget is :{u.Budget} ");
            Console.WriteLine("Products:");
            foreach (var item in u.Products)
            {
                Console.WriteLine("Name:" + item.Name + " Cost:" + item.Cost);
            }

            Console.WriteLine("------------");
            u.Restore(c.Get(1));
            Console.WriteLine($"User's budget is :{u.Budget} ");
            Console.WriteLine("Products:");
            foreach (var item in u.Products)
            {
                Console.WriteLine("Name:" + item.Name + " Cost:" + item.Cost);
            }

        }
    }
}
