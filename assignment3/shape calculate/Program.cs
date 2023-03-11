using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace shape_calculate
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("请输入要选择的形状类型，输入rectangl，triangle，square中的一个即可");
            string s = Console.ReadLine();
            Console.WriteLine("请输入该形状所有边的长度，用逗号进行分隔");
            string t = Console.ReadLine();
            string []stringSide = t.Split(',');
            switch (s)
            {
                case "rectangle":
                    Rectangle rect = new Rectangle();
                    try
                    {
                        rect[0] = Convert.ToInt32(stringSide[0]);
                        rect[1] = Convert.ToInt32(stringSide[1]);
                        rect[2] = Convert.ToInt32(stringSide[2]);
                        rect[3] = Convert.ToInt32(stringSide[3]);
                        Console.WriteLine("矩形面积为"+rect.CalculateArea());
                        Console.WriteLine("矩形合法性为"+rect.ShapeLegitimate());
                    }
                    catch
                    {
                        Console.WriteLine("请输入正确的四个边长");
                    }
                    break;
                case "triangle":
                    Triangle tri = new Triangle();
                    try
                    {
                        tri[0] = Convert.ToInt32(stringSide[0]);
                        tri[1] = Convert.ToInt32(stringSide[1]);
                        tri[2] = Convert.ToInt32(stringSide[2]);
                        Console.WriteLine("三角形面积为"+tri.CalculateArea());
                        Console.WriteLine("三角形的合法性为"+tri.ShapeLegitimate());
                    }
                    catch
                    {
                        Console.WriteLine("请输入正确的三个边长");
                    }
                    break;
                case "square":
                    Square squ = new Square();
                    try
                    {
                        squ[0] = Convert.ToInt32(stringSide[0]);
                        squ[1] = Convert.ToInt32(stringSide[1]);
                        squ[2] = Convert.ToInt32(stringSide[2]);
                        squ[3] = Convert.ToInt32(stringSide[3]);
                        Console.WriteLine("正方形的面积为"+squ.CalculateArea());
                        Console.WriteLine("正方形的合法性为"+squ.ShapeLegitimate());
                    }
                    catch
                    {
                        Console.WriteLine("请输入正确的四个边长");
                    }
                    break;
                default:
                    Console.WriteLine("请输入正确的形状类型");
                    break;
            }
            Console.ReadKey();
        }
    }
    class Shape
    {
        public double[] side = new double[4];
        public double this[int ind]
        {
            get
            {
                return side[ind];
            }
            set
            {
                side[ind] = value;
            }
        }
    }
    public interface ShapeCalculate
    {
        double CalculateArea();
        bool ShapeLegitimate();
    }
    class Rectangle : Shape ,ShapeCalculate
    {
        public double CalculateArea()
        {
            if (ShapeLegitimate())
            {
                return this[0] * this[1];
            }
            else
                return -1;
        }
        public bool ShapeLegitimate()
        {
            if (this[0] == this[2] && this[1] == this[3]&&
                this[0] > 0 && this[1] > 0 && this[2] > 0 && this[3]>0)
                return true;
            else
                return false;
        }
    }
    class Triangle : Shape ,ShapeCalculate
    {
        public double CalculateArea()
        {
            if (ShapeLegitimate())
            {
                //海伦公式，s=根号下(p(p-a)(p-b)(p-c)),p为周长的一半
                double p = (this[0] + this[1] + this[2])/2;
                return Math.Sqrt(p*(p-this[0])*(p-this[1])*(p-this[2]));
            }
            else
                return -1;
        }
        public bool ShapeLegitimate()
        {
            List<double> list = new List<double>() { this[0], this[1], this[2] };
            list.Sort((x, y) => -x.CompareTo(y));
            //俩边之和大于第三边
            if (list[0] < list[1] + list[2]
                && this[0] > 0 && this[1] > 0 && this[2] > 0 )
                return true;
            else
                return false;
        }
    }
    class Square : Rectangle, ShapeCalculate
    {
        new public bool ShapeLegitimate()
        {
            if (this[0] == this[1] && this[1] == this[2] && this[2] == this[3]
                && this[0] > 0 && this[1] > 0 && this[2] > 0 && this[3] > 0)
                return true;
            else
                return false;
        }
    }

}
