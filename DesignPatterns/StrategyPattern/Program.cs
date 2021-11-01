using System;

namespace StrategyPattern
{
    interface IStrategy
    {
        void Do();
    }
    class Strategy1 : IStrategy
    {
        public void Do()
        {
            Console.WriteLine("Use first strategy");
        }
    }
    class Strategy2 : IStrategy
    {
        public void Do()
        {
            Console.WriteLine("Use second strategy");
        }
    }

    class Context
    {
        IStrategy Strategy;
        public void SetStrategy(IStrategy Strategy)
        {
            this.Strategy = Strategy;
        }
        public void Do()
        {
            Strategy.Do();
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Context c = new Context();
            c.SetStrategy(new Strategy1());
            c.Do();
            c.SetStrategy(new Strategy2());
            c.Do();
        }
    }
}
