using System;

namespace _13.DrawingTool
{
    class Program
    {
        static void Main(string[] args)
        {
            string shapeCommand = Console.ReadLine();
            if (shapeCommand == "Square")
            {
                int side = int.Parse(Console.ReadLine());
                CorDraw corDraw = new CorDraw(new Square(side));
                corDraw.shape.Draw();
            }
            else
            {
                int witdh = int.Parse(Console.ReadLine());
                int height = int.Parse(Console.ReadLine());
                CorDraw corDraw = new CorDraw(new Rectangle(witdh, height));
                corDraw.shape.Draw();
            }
        }
    }
}