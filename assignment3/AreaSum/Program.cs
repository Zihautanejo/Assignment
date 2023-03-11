using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace AreaSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CreatShape R =new CreatShape();
            Console.WriteLine("图形的面积之和为"+R.RandomShapeSum(10,3,1,10));
            Console.ReadKey();
        }
    }
    //工厂类
    public class  CreatShape
    {
        AreaCalculate areacal = new AreaCalculate();
        Shape theshape;//生成的图形类型
        public double RandomShapeSum(int n,int m,int s1,int s2)
         // n为要生成的图形个数,m为图形的种类个数-1，边的长度范围从s1到s2
        { 
            double areaSum=0;
            
            for (int i = 0; i < n; i++)
            {
                //随机生成图形的序号
                Random rd = new Random();
                int shapenumble=rd.Next(0,m);
                Random rs = new Random();//随机生成边的长度
                //进行计算
                switch (shapenumble)
                {
                    case 0:
                        theshape = new Rectangle();
                        theshape[0] = rs.Next(s1, s2);
                        theshape[1] = rs.Next(s1, s2);
                        break;
                    case 1:
                        theshape = new  Triangle();
                        theshape[0] = rs.Next(s1, s2);
                        theshape[1] = rs.Next(s1, s2);
                        theshape[2] = rs.Next(s1, s2);
                        break;
                    case 2:
                        theshape = new Square();
                        theshape[0] = rs.Next(s1, s2);
                        theshape[1] = theshape[0];
                        break;
                    case 3:
                        theshape = new Circle();
                        theshape[0] = rs.Next(s1, s2);
                        break;
                }
                //三角形的定义不一定合法，如果不合法，则抛出异常
                if (theshape.ShapeLegitimate())
                {
                    areaSum += areacal.calculateShape(theshape);
                    continue;
                }
                i--;//这次的不合法三角形做废
            }
            return areaSum;
        }
    }
    //抽象产品类
    public class AreaCalculate
    { 
        public double calculateShape(Shape shape)
        {
            return shape.CalculateArea();
        }
    }
    //抽限产品类
    //抽象形状类，包含边长，面积计算
    public abstract class Shape
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
        public abstract double CalculateArea();
        virtual public bool ShapeLegitimate() { return true; }
    }
    //几种形状的面积计算override
    class Rectangle:Shape
    {
        public override double CalculateArea()
        {
            return this[0] * this[1];
        }
    }
    class Triangle : Shape
    {
        public override double CalculateArea()
        {
            double p = (this[0] + this[1] + this[2]) / 2;
            return Math.Sqrt(p * (p - this[0]) * (p - this[1]) * (p - this[2]));
        }
        public override bool ShapeLegitimate()
        {
            List<double> list = new List<double>() { this[0], this[1], this[2] };
            list.Sort((x, y) => -x.CompareTo(y));
            //俩边之和大于第三边
            if (list[0] < list[1] + list[2]
                && this[0] > 0 && this[1] > 0 && this[2] > 0)
                return true;
            else
                return false;
        }
    }
    class Square : Rectangle { }
    class Circle : Shape
    {
        public override double CalculateArea()
        {
            return this[0] * this[0] * (3.1415926);
        }
    }

}
