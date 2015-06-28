using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SRD.Utils
{
    static class ArrayHelper
    {
        public static int maxValue(this int[,] array)
        {
            int max = Int32.MinValue;

            foreach (var item in array)
            {
                if (item > max)
                    max = item;
            }
            return max;
        }

        public static int maxValue(this int[, ,] array, int t)
        {
            int max = Int32.MinValue;

            for (int i = 0; i < array.GetLength(1); i++)
            {
                for (int j = 0; j < array.GetLength(2); j++)
                {
                    if (array[t, i, j] > max)
                        max = array[t, i, j];
                }
            }
            return max;
        }

        public static void normalize(this int[,] array, int top)
        {
            int maxValue = array.maxValue();

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = (int)((double)array[i, j] / (double)maxValue * (double)top);
                }
            }
        }

        public static void normalize(this int[, ,] array, int top)
        {

            for (int i = 0; i < array.GetLength(0); i++)
            {
                int maxValue = array.maxValue(i);

                for (int j = 0; j < array.GetLength(1); j++)
                {
                    for (int k = 0; k < array.GetLength(2); k++)
                    {
                        array[i, j, k] = (int)((double)array[i, j, k] / (double)maxValue * (double)top);
                    }
                }
            }
        }

        public static int[,] UpperTreshold(this int[,] array, int top)
        {
            int[,] retarr = new int[array.GetLength(0), array.GetLength(1)];

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (array[i, j] > top)
                        retarr[i, j] = 255;
                }
            }

            return retarr;
        }

        public static int[,] UpperTreshold(this int[,] array, int top, int yBeneath)
        {
            int[,] retarr = new int[array.GetLength(0), array.GetLength(1)];

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (array[i, j] > top)
                        retarr[i, j] = 255;
                }
            }

            return retarr;
        }
    }
}
