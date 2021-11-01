using System;
using System.Collections.Generic;

namespace ObserverPattern
{
    class UserObserver 
    {
        public string Name { get; set; }
        User Subject { get; set; }
        public UserObserver(User Subject,string Name)
        {
            this.Subject = Subject;
            this.Name = Name;
        }
        public void Update()
        {
            Console.WriteLine($"({Name}) : Username is changed to : {Subject.Username}");
        }
    }
    class User 
    {
        private List<UserObserver> Observers = new List<UserObserver>();

        public void AddObserver(UserObserver o)
        {
            Observers.Add(o);
        }
        public void RemoverObserver(UserObserver o)
        {
            Observers.Remove(o);
        }
        public void Notify()
        {
            foreach (var item in Observers)
            {
                item.Update();
            }
        }


        private string username;

        public string Username
        {
            get => username;
            set { username = value;Notify(); }
        }

    }






    class Program
    {
        static void Main(string[] args)
        {
            var user = new User() {Username = "Foo" };
            var observer1 = new UserObserver(user, "Observer1");
            var observer2 = new UserObserver(user, "Observer2");
            user.AddObserver(observer1);
            user.AddObserver(observer2);
            user.Username = "Bar";
            user.Username = "Foo";
        }
    }
}
