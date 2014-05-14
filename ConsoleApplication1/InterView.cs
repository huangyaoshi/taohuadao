using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApplication1
{
    interface IDuplicationFinder
    {
        string FindDuplication(int[] input, uint minTimes);
    }

    public class ShineDuplicationFinder : IDuplicationFinder
    {
        public string FindDuplication(int[] input, uint minTimes)
        {
            if (input == null || input.Length == 0)
            {
                throw new ArgumentException("input can not be null or empty!");
            }

            var inputGroup = input.GroupBy(i => i);
            var resultGroup = inputGroup.Where(g => g.Count() >= minTimes);
            return string.Join(",", resultGroup.Select(g => g.Key));
        }
    }

    interface IStringInverter
    {
        string PiecewiseInvert(string input);
    }

    public class ShineStringInverter : IStringInverter
    {
        public string PiecewiseInvert(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentNullException("input can not be null or empty!");
            }

            if (!input.Contains("，") && !input.Contains("。"))
            {
                return input;
            }

            List<string> resultList = new List<string>();
            IEnumerable<string> commaArray = input.Split(new string[] { "，" }, StringSplitOptions.None).ToList();
            for (int i = 0; i < commaArray.Count(); i++)
            {
                string commaItem = commaArray.ElementAt(i);
                if (commaItem.Contains("。"))
                {
                    IEnumerable<string> periodArray = commaItem.Split(new string[] { "。" }, StringSplitOptions.None);
                    for (int j = 0; j < periodArray.Count(); j++)
                    {
                        string periodItem = periodArray.ElementAt(j);
                        resultList.Add(string.Join(string.Empty, periodItem.Reverse()));
                        if (j < periodArray.Count() - 1)
                        {
                            resultList.Add("。");
                        }
                    }
                }
                else
                {
                    resultList.Add(commaItem);
                }
                if (i < commaArray.Count() - 1)
                {
                    resultList.Add("，");
                }
            }

            return string.Join(string.Empty, resultList);
        }
    }

    public class Shape
    {
        public static bool IsCrossBetween(Rectangle rectangle, Circle circle)
        {
            double xDistance = Math.Abs(circle.Centre.X - rectangle.Centre.X);
            double yDistance = Math.Abs(circle.Centre.Y - rectangle.Centre.Y);
            double centreDistance = Point.DistanceBetween(rectangle.Centre, circle.Centre);
            double longthGap = rectangle.Longth / 2 + circle.Radius;
            double widthGap = rectangle.Width / 2 + circle.Radius;
            return (xDistance < longthGap) && (yDistance < widthGap) && (centreDistance < longthGap || centreDistance < widthGap);
        }
    }

    public class Point
    {
        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double X { get; set; }
        public double Y { get; set; }

        public static double DistanceBetween(Point p1, Point p2)
        {
            double xGap = p1.X - p2.X;
            double yGap = p1.Y - p2.Y;
            return Math.Sqrt(xGap * xGap + yGap * yGap);
        }
    }

    public class Rectangle : Shape
    {
        public Rectangle(double x, double y, double longth, double width)
        {
            BottomLeftPoint = new Point(x, y);
            Longth = longth;
            Width = width;
        }

        public Point BottomLeftPoint { get; set; }

        public double Longth { get; set; }

        public double Width { get; set; }

        public Point BottomRightPoint
        {
            get
            {
                return new Point(BottomLeftPoint.X + Longth, BottomLeftPoint.Y);
            }
        }

        public Point TopLeftPoint
        {
            get
            {
                return new Point(BottomLeftPoint.X, BottomLeftPoint.Y + Width);
            }
        }

        public Point TopRightPoint
        {
            get
            {
                return new Point(BottomRightPoint.X, TopLeftPoint.Y);
            }
        }

        public Point Centre
        {
            get
            {
                return new Point(BottomLeftPoint.X + Longth / 2, BottomLeftPoint.Y + Width / 2);
            }
        }
    }

    public class Circle : Shape
    {
        public Circle(double x, double y, double radius)
        {
            Centre = new Point(x, y);
            Radius = radius;
        }

        public Point Centre { get; set; }

        public double Radius { get; set; }
    }
}
