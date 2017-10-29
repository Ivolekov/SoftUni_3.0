using System;

namespace _13.DrawingTool
{
    public class Square : Shape
    {
        public int side;

        public Square(int side)
        {
            this.side = side;
        }
        public override void Draw()
        {
            Console.WriteLine("{0}{1}{0}", '|', new string('-', this.side));
            for (int i = 0; i < this.side - 2; i++)
            {
                Console.WriteLine("{0}{1}{0}", '|', new string(' ', this.side));
            }
            Console.WriteLine("{0}{1}{0}", '|', new string('-', this.side));
        }
    }
}