using System;

namespace _13.DrawingTool
{
    public class Rectangle : Shape
    {
        public int width;
        public int height;

        public Rectangle(int width, int height)
        {
            this.width = width;
            this.height = height;
        }
        public override void Draw()
        {
            Console.WriteLine("{0}{1}{0}", '|', new string('-', this.width));
            for (int i = 0; i < this.height - 2; i++)
            {
                Console.WriteLine("{0}{1}{0}", '|', new string(' ', this.width));
            }
            Console.WriteLine("{0}{1}{0}", '|', new string('-', this.width));
        }
    }
}