using System;
using System.Collections.Generic;
using System.Linq;

namespace InterviewColoring
{
    class Program
    {
        static void Main(string[] args)
        {
            var image = GenerateImage(15);

            PrintImage(image);
            
            Colorize(image);

            PrintImage(image);

            Console.WriteLine("Press enter to quit.");
            Console.ReadLine();
        }

        private static void Colorize(int [,] image)
        {
            var needsNewColor = new HashSet<Pixel>();
            var needsCurrentColor = new Stack<Pixel>();

            needsNewColor.Add(new Pixel(0, 0));

            var newColor = 1;

            while (needsNewColor.Count > 0)
            {
                var startingPixel = needsNewColor.First();

                if (image[startingPixel.X, startingPixel.Y] > 1)
                {
                    needsNewColor.Remove(startingPixel);
                    continue;
                }

                var currentColor = image[startingPixel.X, startingPixel.Y];

                needsCurrentColor.Push(startingPixel);

                newColor++;

                while (needsCurrentColor.Count > 0)
                {
                    var needsColorPixel = needsCurrentColor.Pop();

                    foreach (var direction in Directions.All)
                    {
                        var neighborPixel = GetNewPixel(needsColorPixel, direction, image.GetLength(0));

                        if (neighborPixel == null)
                        {
                            continue;
                        }
                        else if (image[neighborPixel.X, neighborPixel.Y] >= 2) // already colored
                        {
                            continue;
                        }
                        else if (image[neighborPixel.X, neighborPixel.Y] == currentColor) // needs current color
                        {
                            needsCurrentColor.Push(neighborPixel);
                        }
                        else // needs a new color
                        {
                            needsNewColor.Add(neighborPixel);
                        }
                    }

                    image[needsColorPixel.X, needsColorPixel.Y] = newColor;
                }

                needsNewColor.Remove(startingPixel);
            }
        }

        private class Directions
        {
            public static Pixel Up = new Pixel(0, -1);
            public static Pixel Left = new Pixel(-1, 0);
            public static Pixel Down = new Pixel(0, 1);
            public static Pixel Right = new Pixel(1, 0);

            public static List<Pixel> All = new List<Pixel> { Up, Left, Down, Right };
        }

        private static Pixel GetNewPixel(Pixel start, Pixel direction, int size)
        {
            var newPixel = new Pixel(start.X + direction.X, start.Y + direction.Y);

            if (newPixel.X < 0 || newPixel.X >= size || newPixel.Y < 0 || newPixel.Y >= size)
            {
                return null;
            }

            return newPixel;
        }

        private static int[,] GenerateImage(int size)
        {
            var image = new int[size, size];

            var random = new Random();
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    image[i, j] = random.Next(2);
                }
            }

            return image;
        }

        private static void PrintImage(int[,] image)
        {
            for (int i = 0; i < image.GetLength(0); i++)
            {
                for (int j = 0; j < image.GetLength(1); j++)
                {
                    if (image[i, j] < 10)
                    {
                        Console.Write(" " + image[i, j] + ",");
                    }
                    else
                    {
                        Console.Write(image[i, j] + ",");
                    }
                }

                Console.WriteLine();
            }

            Console.WriteLine();
        }
    }

    public class Pixel
    {
        public Pixel(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public int X { get; set; }

        public int Y { get; set; }

        public override int GetHashCode()
        {
            return ("" + X + Y).ToString().GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj is Pixel pixel)
            {
                return this.X == pixel.X && this.Y == pixel.Y;
            }

            return false;
        }
    }
}
