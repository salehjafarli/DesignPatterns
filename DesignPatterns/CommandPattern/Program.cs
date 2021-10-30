using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CommandPattern
{
    interface ICommand
    {
        public FileManager FileManager { get; set; }
        void Execute();
    }

    class CreateCommand : ICommand
    {
        public CreateCommand(FileManager FileManager)
        {
            this.FileManager = FileManager;
        }

        public FileManager FileManager { get; set; }

        public void Execute()
        {
            FileManager.Create();
        }
    }
    class WriteCommand : ICommand
    {
        public WriteCommand(FileManager FileManager, string Text)
        {
            this.FileManager = FileManager;
            this.Text = Text;
        }

        public FileManager FileManager { get; set; }
        public string Text { get; set; }

        public void Execute()
        {
            FileManager.AddLine(Text);
        }
    }


    class FileManager 
    {
        public void Create() 
        {
            var stream = File.Create(@"C:\Users\User\source\repos\DesignPatterns\DesignPatterns\CommandPattern\test.txt");
            stream.Dispose();
        }
        public void AddLine(string text) 
        {
            using (StreamWriter outputFile =  File.AppendText(@"C:\Users\User\source\repos\DesignPatterns\DesignPatterns\CommandPattern\test.txt"))
            {
                outputFile.WriteLine(text);
            }
        } 
    }
   




    class Program
    {
        static void Main(string[] args)
        {
            var fileman = new FileManager();
            List<ICommand> commands = new List<ICommand>();
            commands.Add(new CreateCommand(fileman));
            var x = 10;
            Iteration:
            if (x > 0)
            {
                commands.Add(new WriteCommand(fileman, "test"));
                x--;
                goto Iteration;
            }

            commands.ForEach(x => x.Execute());

        }
    }
}
