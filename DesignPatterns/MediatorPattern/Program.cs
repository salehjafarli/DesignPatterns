using System;
using System.Collections.Generic;

namespace MediatorPattern
{
     class User
    {
        public IMediator MessageMediator { get; set; }
        public string Username { get; set; }
        public void SendMessage(string message) 
        {
            Console.WriteLine($"{Username} sents message");
            MessageMediator.Handle(message,this);
        }
        public void ReceiveMessage(string msg) 
        {
            Console.WriteLine($"{Username} is received message : {msg}" );
        }
    }
    interface IMediator
    {
        void Handle(params object[] args); 
    }


    //The Mediator object acts as the communication center for all objects.

    //That means when an object needs to communicate to another object,
    //then it does not call the other object directly, instead, it calls the mediator object
    //and it is the responsibility of the mediator object to route the message to the destination object.
    class UserMessageMediator : IMediator
    {
        public List<User> Users = new List<User>();
        public void Handle(params object[] args)
        {
            string message = args[0].ToString();
            User sender = (User)args[1];
            Users.ForEach(item => { if (item != sender) item.ReceiveMessage(message); });
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            UserMessageMediator messageMediator = new UserMessageMediator();
            var user1 = new User()
            {
                Username = "Foo",
                MessageMediator = messageMediator
            };
            messageMediator.Users.Add(user1);
            var user2 = new User()
            {
                Username = "Bar",
                MessageMediator = messageMediator
            };
            messageMediator.Users.Add(user2);
            var user3 = new User()
            {
                Username = "FooBar",
                MessageMediator = messageMediator
            };
            messageMediator.Users.Add(user3);


            user1.SendMessage("Hello world!");

        }
    }
}
