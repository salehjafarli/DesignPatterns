using System;

namespace ChainofResponsibilityPattern
{
    abstract class AtmMoneyHandler
    {
        public AtmMoneyHandler Next { get; set; }
        public abstract void HandleCash(int amount);
    }
    class AtmHandler : AtmMoneyHandler
    {
        public AtmHandler()
        {
            Next = new HundredDollarHandler();
        }
        public override void HandleCash(int amount)
        {
            Next.HandleCash(amount);
        }
    }
    class HundredDollarHandler : AtmMoneyHandler
    {
        public HundredDollarHandler()
        {
            Next = new FiftyDollarHandler();
        }
        public override void HandleCash(int amount)
        {
            var cash = amount / 100;
            amount = amount % 100;
            if (cash > 0)
                Console.WriteLine($"{cash} hundred dollars were given");
            Next.HandleCash(amount);
        }
    }
    class FiftyDollarHandler : AtmMoneyHandler
    {
        public FiftyDollarHandler()
        {
            Next = new FiveDollarHandler();
        }
        public override void HandleCash(int amount)
        {
            var cash = amount / 50;
            amount = amount % 50;
            if (cash > 0)
                Console.WriteLine($"{cash} fifty dollars were given");
            Next.HandleCash(amount);
        }
    }
    class FiveDollarHandler : AtmMoneyHandler
    {
        public FiveDollarHandler()
        {
            Next = new OneDollarHandler();
        }
        public override void HandleCash(int amount)
        {
            var cash = amount / 5;
            amount = amount % 5;
            if (cash > 0)
                Console.WriteLine($"{cash} five dollars were given");
            Next.HandleCash(amount);
        }
    }
    class OneDollarHandler : AtmMoneyHandler
    {
        public OneDollarHandler()
        {
            Next = null;
        }
        public override void HandleCash(int amount)
        {
            if (amount > 0)
                Console.WriteLine($"{amount} one dollars were given");
        }
    }

    class Program
    {
        // chain of responsibility design pattern creates a chain of receiver objects for a given request.
        // In this design pattern, normally each receiver contains a reference to another receiver.
        // If one receiver cannot handle the request then it passes the same request to the next receiver and so on.
        // One receiver handles the request in the chain or one or more receivers handle the request.
        static void Main(string[] args)
        {
            AtmMoneyHandler atmMoneyHandler = new AtmHandler();
            atmMoneyHandler.HandleCash(100);
        }
    }
}
