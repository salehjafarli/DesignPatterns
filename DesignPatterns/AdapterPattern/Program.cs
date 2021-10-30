using System;
using System.Collections.Generic;

namespace AdapterPattern
{
    // Employee - This class serves as an entity.
    class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    //RecordServer - assume this class has only one functionality of return all employees to the caller
    class RecordServer 
    {
        private List<Employee> Employees = new List<Employee>
        {
            new Employee{Id = 1,Name = "Foo" },
            new Employee{Id = 2,Name = "Bar" }
        };

        public List<Employee> GetEmployees() 
        {
            return Employees;
        }

    }


    //Client - This is the client class.It has to return 2 dimensional employee array.As you can see record server
    //and Client class are not incompatible.So we need another wrapper adapter class to make conversion between them
    class Client 
    {
        public Client(IAdapter Adapter)
        {
            this.Adapter = Adapter;
        }

        private IAdapter Adapter { get; }

        public string[] GetEmployees() 
        {
            return Adapter.GetEmployees();
        }
    }

    //Interface for Adapter class.
    interface IAdapter
    {
        string[] GetEmployees();
    }


    //This is the adapter class.Its main functionality is making 2 classes compatible with each other
    class Adapter : IAdapter
    { 
        public Adapter(RecordServer recordServer)
        {
            RecordServer = recordServer;
        }
        public RecordServer RecordServer { get; }
        
        public string[] GetEmployees()
        {
            var emplist = RecordServer.GetEmployees();
            string[] res = new string[emplist.Count];
            int indx = 0;
            foreach (var item in emplist)
            {
                var mystr = item.Id.ToString() + " " + item.Name;
                res[indx] = mystr;
                indx++;
            }

            return res;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //With the help of Adapter pattern we dont need to make changes in two classes.We keep their own functionality
            //but making them compatible with each other
            RecordServer recServer = new RecordServer();
            Adapter adapter = new Adapter(recServer);
            Client client = new Client(adapter);

            string[] arr = client.GetEmployees();
            foreach (var item in arr)
            {
                Console.WriteLine(item);
            }
        }
    }
}
