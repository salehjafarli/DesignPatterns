using System;
using System.Collections.Generic;

namespace FacadePattern
{
    class User 
    {
        public string Username { get; set; }
        public string  Password { get; set; }

        static List<User> AuthUsers = new List<User>()
        {
            new User(){ Username = "foo", Password="foo" },
            new User(){ Username = "bar", Password="bar" }
        };
        public static bool Authorize(User u)
        {
            return AuthUsers.Exists(x => x.Username == u.Username && x.Password == u.Password);
        }
    }
    class Product 
    {
        public string ProductName { get; set; }
        public double Cost { get; set; }
    }
    class CardDetails 
    {
        public string CardNum { get; set; }
        public string Code { get; set; }
        public string ExpMonth { get; set; }
        public string ExpYear { get; set; }

        public static bool CheckValidity(CardDetails details) 
        {
            return details.CardNum.Length + details.Code.Length + details.ExpMonth.Length + details.ExpYear.Length == 23;
        }
    }
    class PaymentManager 
    {
        public PaymentManager(CardDetails cardDetails,Product p,int amount)
        {
            CardDetails = cardDetails;
            P = p;
            Amount = amount;
        }

        public CardDetails CardDetails { get; }
        public Product P { get; }
        public int Amount { get; }

        public void MakePayment() 
        {
            Action a = CardDetails.CheckValidity(CardDetails) ?
            new Action(() => 
            {
                Console.WriteLine($"Your payment has been made.Product: {P.ProductName},Total purchase : {P.Cost * Amount}$");
            }) : 
            new Action(() => 
            {
                Console.WriteLine("Something went wrong");
            });
            a.Invoke();
        }
    }


    //Facade pattern hides complexities of the system and provides an interface to the client
    //using which the client can access the system
    class Order 
    {
        public Order(User u,Product p,int amount,CardDetails card)
        {
            U = u;
            P = p;
            Amount = amount;
            Card = card;
        }

        public User U { get; }
        public Product P { get; }
        public int Amount { get; }
        public CardDetails Card { get; }

        public void MakeOrder() 
        {
            if (User.Authorize(U))
            {
                PaymentManager manager = new PaymentManager(Card,P,Amount);
                manager.MakePayment();
            }
            else
            {
                Console.WriteLine("Unauthorized");
            }
        }
    }



    class Program
    {
        static void Main(string[] args)
        {

            User u = new User() { Username = "foo", Password = "foo" };
            Product shampoo = new Product() { ProductName = "Shampoo", Cost = 12 };
            CardDetails Card = new CardDetails()
            {
                CardNum = "1234123412341234",
                Code = "123",
                ExpMonth = "12",
                ExpYear = "12"
            };
            Order order = new Order(u,shampoo,12,Card);
            order.MakeOrder();
            Console.WriteLine("-----------------------------");
            User u2 = new User() { Username = "foo", Password = "bar" };
            Order order2 = new Order(u2, shampoo, 12, Card);
            order2.MakeOrder();
        }
    }
}
