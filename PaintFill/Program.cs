using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintFill
{
    enum Color
    {
        Black,
        White,
        Green,
        Blue
    };


    class Program
    {
        static void Main(string[] args)
        {
            Color[,] image = {
                                 {Color.Black, Color.Black},
                                 {Color.Black, Color.Black},
                             };

            int x = 0;
            int y = 1;
            int xSize = 2;
            int ySize = 2;

            Console.WriteLine("Original image is");

            for (int i = 0; i < ySize; i++)
            {
                for (int j = 0; j < xSize; j++)
                {
                    Console.Write(image[i, j] + " ");
                }

                Console.WriteLine();
            }

            if (paintFill(image, x, y, xSize, ySize, Color.Blue))
            {
                Console.WriteLine("Painted image is");

                for (int i = 0; i < ySize; i++)
                {
                    for (int j = 0; j < xSize; j++)
                    {
                        Console.Write(image[i, j] + " ");
                    }

                    Console.WriteLine();
                }
            }
        }

        // Returns true if paintFill was successful
        // else returns false
        static bool paintFill(Color[,] image, int x, int y, int xSize, int ySize, Color newColor)
        {
            return paintFill(image, x, y, xSize, ySize, image[y, x], newColor);
        }

        static bool paintFill(Color[,] image, int x, int y, int xSize, int ySize, Color origColor, Color newColor)
        {
            if ((x < 0 || x >= xSize) ||
                (y < 0 || y >= ySize))
            {
                return false;
            }

            if (image[y, x] == origColor)
            {
                image[y, x] = newColor;

                // Go left
                paintFill(image, x - 1, y, xSize, ySize, origColor, newColor);

                // Go right
                paintFill(image, x + 1, y, xSize, ySize, origColor, newColor);

                // Go bottom
                paintFill(image, x, y - 1, xSize, ySize, origColor, newColor);

                // Go top
                paintFill(image, x, y + 1, xSize, ySize, origColor, newColor);
            }

            return true;
        }

    }
}
