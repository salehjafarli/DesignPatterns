using System;

namespace InterpreterPattern
{
    class Employee 
    {
        public Employee(string FirstName,string LastName)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }


    }

    //The Interpreter Design Pattern Provides a way to evaluate language grammar or expression.
    //This pattern is used in SQL parsing,property formatting, symbol processing engine, etc

    interface IInterpreter<T> { void Interpret(T o); }

    class FNameFirst : IInterpreter<Employee>
    {
        public void Interpret(Employee o)
        {
            o.FullName = $"{o.FirstName} {o.LastName}";
        }
    }
    class LNameFirst : IInterpreter<Employee>
    {
        public void Interpret(Employee o)
        {
            o.FullName = $"{o.LastName} {o.FirstName}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            IInterpreter <Employee> FirstNameFirst = new FNameFirst();
            IInterpreter<Employee> LastNameFirst = new LNameFirst();
            Employee e = new Employee("Foo", "Bar");
            FirstNameFirst.Interpret(e);
            Console.WriteLine(e.FullName);
            LastNameFirst.Interpret(e);
            Console.WriteLine(e.FullName);

        }
    }
}
