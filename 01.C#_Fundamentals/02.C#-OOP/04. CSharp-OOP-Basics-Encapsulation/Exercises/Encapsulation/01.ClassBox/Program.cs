using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace _01.ClassBox
{
    class Program
    {
        static void Main(string[] args)
        {




            Type boxType = typeof(Box);
            FieldInfo[] fields = boxType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
            Console.WriteLine(fields.Count());

            try
            {
                double lenght = double.Parse(Console.ReadLine());
                double widht = double.Parse(Console.ReadLine());
                double height = double.Parse(Console.ReadLine());
                Box box = new Box(lenght, widht, height);
                Console.WriteLine($"Surface Area - {box.SurfaceArea():F2}");
                Console.WriteLine($"Lateral Surface Area - {box.LateralSurfaceArea():F2}");
                Console.WriteLine($"Volume - {box.Volume():F2}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }



        }
    }

    public class Box
    {
        private double lenght;
        private double widht;
        private double height;

        public Box(double lenght, double widht, double height)
        {
            this.Length = lenght;
            this.Width = widht;
            this.Height = height;
        }

        public double Length
        {
            get
            {
                return this.lenght;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"{nameof(this.Length)} cannot be zero or negative.");
                }
                this.lenght = value;
            }
        }

        public double Height
        {
            get { return this.height; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"{nameof(this.Height)} cannot be zero or negative.");
                }
                this.height = value;
            }
        }

        public double Width
        {
            get { return this.widht; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"{nameof(this.Width)} cannot be zero or negative.");
                }
                this.widht = value;
            }
        }

        public double SurfaceArea()
        {
            var result = 2 * this.lenght * this.widht + 2 * this.lenght * this.height + 2 * this.widht * this.height;
            return result;
        }
        public double LateralSurfaceArea()
        {
            var result = 2 * this.lenght * this.height + 2 * this.widht * this.height;
            return result;
        }
        public double Volume()
        {
            var result = this.lenght * this.height * this.widht;
            return result;
        }
    }
}
