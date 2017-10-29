using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.EventImplementation
{
    public class Program
    {
        static void Main(string[] args)
        {
            var dispacher = new Dispatcher();
            var handler = new Handler();
            dispacher.NameChange += handler.OnDispatcherNameChange;

            string input = Console.ReadLine();

            while (input != "End")
            {
                dispacher.Name = input;

                input = Console.ReadLine();
            }
        }
    }

    public class NameChangeEventArgs : EventArgs
    {
        private string name;

        public NameChangeEventArgs(string name)
        {
            this.Name = name;
        }

        public string Name { get; private set; }
    }

    public delegate void NameChangeEventHandler(object sender, NameChangeEventArgs args);

    public class Dispatcher
    {
        private string name;

        public event NameChangeEventHandler NameChange;

        public string Name
        {
            get { return this.name; }
            set
            {
                this.name = value;
                this.OnNameChange(new NameChangeEventArgs(value));
            }
        }

        private void OnNameChange(NameChangeEventArgs args)
        {
            this.NameChange?.Invoke(this, args);
        }
    }

    public class Handler
    {
        public void OnDispatcherNameChange(object sender, NameChangeEventArgs args)
        {
            Console.WriteLine($"Dispatcher's name changed to {args.Name}.");
        }
    }
}
