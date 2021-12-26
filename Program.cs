using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Shapes;

namespace AdventOfCodeStartProject
{
    static class AdventOfCode
    {
        //this field contains whats written in your input.txt
        //each line in the list of strings represents one line in the txt file
        //copy the data you get on the adventofcode website into the txt file and start coding!
        private static List<string> _inputData;

        static void Main(string[] args)
        {
            //EXAMPLE CODE
            //hit F5 to run it

            //read data from input.txt and write it into inputdata field
            readInput();
            //var intlist = _inputData.Select(i => int.Parse(i)).ToList();
            //lets write the contents of the input.txt into the console

            Console.WriteLine("Content of input.txt:");
            _inputData.ForEach(i => Console.WriteLine(i));
            Console.WriteLine($"--END OF FILE--{Environment.NewLine}");

            //Dictionary<Point, Point> lines = new Dictionary<Point, Point>();
            List<Point> allPoints = new List<Point>();
            int counter = 0;    
            for (int i = 0; i < _inputData.Count; i++)
            {
                var points = _inputData[i].Split(' ').ToList();
                Point start = new Point();
                start.X = int.Parse(points[0].Split(',')[0]);
                start.Y = int.Parse(points[0].Split(',')[1]);
                Point end = new Point();
                end.X = int.Parse(points[2].Split(',')[0]);
                end.Y = int.Parse(points[2].Split(',')[1]);

                Console.WriteLine(start.X + "/" + start.Y);
                Console.WriteLine(end.X + "/" + end.Y);

                int minX = Math.Min(start.X, end.X);
                int minY = Math.Min(start.Y, end.Y);
                int maxX = Math.Max(start.X, end.X);
                int maxY = Math.Max(start.Y,end.Y);


                if (start.X == end.X) //line is vertical
                {
                    for (int j = minY; j <= maxY-minY; j++)
                    {   
                        allPoints.Add(new Point(start.X, j));
                        if (allPoints.Contains(new Point(start.X, j)))
                            counter++;
                    }
                }
                if (start.Y == end.Y) //line is horizontal
                { 
                    for (int j = minX ; j <= maxX-minX; j++)
                    {
                        allPoints.Add(new Point(j, start.Y));
                        if (allPoints.Contains(new Point(start.X, j)))
                            counter++;

                    }
                }
            }
        
            foreach(Point p in allPoints)
            {
                Console.WriteLine(p);
            }
            Console.WriteLine("Counter     "  + counter );


            //keep console open
            Console.WriteLine("Hit any key to close this window...");
                Console.ReadKey();
            
        }
        private static void readInput()
        {
            _inputData = System.IO.File.ReadAllLines("Input.txt").ToList();
        }
    }
}
