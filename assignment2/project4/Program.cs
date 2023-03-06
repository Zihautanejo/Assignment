using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] a = new int[3, 4] { { 1, 2, 3, 4}, { 5, 1, 2, 3 }, { 9, 5, 1, 2 } };
            Console.WriteLine(ToeplitzMatrix(a));
            int[,] b = new int[3, 4] { { 1, 2, 3, 4 }, { 5, 1, 2, 3 }, { 9, 7, 1, 2 } };
            Console.WriteLine(ToeplitzMatrix(b));
            Console.ReadKey();
        }
        static bool ToeplitzMatrix(int[,] a)
        {
            int row = a.GetLength(0); 
            int col = a.GetLength(1);//获取二维数组的行数和列数
            for(int i = 0;i < col; i++)//最上面的一行中的元素
            {
                if (!CheckDiagonal(a, 0, i, row, col))
                    return false;
            }
            for(int i = 1; i < row; i++)//最左边的一列中的元素
            {
                if (!CheckDiagonal(a, i, 0, row, col))
                    return false;
            }
            return true;
        }

        //用于确定每一对角线上的元素是否相等
        //(n,m)为这一对角线上最左上角的元素的坐标
        static bool CheckDiagonal(int[,]a,int n,int m,int row,int col)
        {
            //确定对角线的长度
            int diagonLength = Math.Min(col - m, row - n);
            for(int i = 1; i < diagonLength; i++)
            {
                if (a[n, m] != a[n + i, m + i])
                    return false;
            }
            return true;
        }
    }
}
