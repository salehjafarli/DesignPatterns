using System;

namespace DecoratorPattern
{
    interface IRepository 
    {
        void Create();
        void GetAll();
    }
    class Repository : IRepository
    {
        public void Create()
        {
            Console.WriteLine("Data is being created...");
        }

        public void GetAll()
        {
            Console.WriteLine("Data is being fetched...");
        }
    }
    //Suppose you have Repository class.But it doesnt have a functionality that you need(For example error logging)
    //You cant change that because it is written in another library.You can apply a decorator pattern and add extra functionality
    abstract class LoggerDecorator : IRepository
    {
        public IRepository Repo { get; set; }
        public LoggerDecorator(IRepository Repo)
        {
            this.Repo = Repo;
        }
        //You can make them virtual and implement another functionality or just leave it abstract as a base decorator class
        public virtual void Create()
        {
            try
            {
                Repo.Create();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception : {e.Message}");
            }
            
        }
        public virtual void GetAll()
        {
            try
            {
                Repo.GetAll();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception : {e.Message}");
            }
        }
    }

    class MoreDetailedLoggerDecorator : LoggerDecorator
    {
        public MoreDetailedLoggerDecorator(IRepository Repo) : base(Repo)
        {

        }

        public override void Create()
        {
            Console.WriteLine($"Starting to execute {nameof(Create)} method");
            base.Create();
            Console.WriteLine($"execution of {nameof(Create)} method is ended");
        }

        public override void GetAll()
        {
            Console.WriteLine($"Starting to execute {nameof(GetAll)} method");
            base.GetAll();
            Console.WriteLine($"execution of {nameof(GetAll)} method is ended");
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            IRepository repo = new Repository();
            Console.WriteLine("Without decorator:");
            repo.Create();
            repo.GetAll();
            Console.WriteLine("----------------------------");
            LoggerDecorator dec = new MoreDetailedLoggerDecorator(repo);
            Console.WriteLine("With decorator:");
            dec.Create();
            dec.GetAll();


            //NOTE - Decorator pattern has similary syntax
        }
    }
}
