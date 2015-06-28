using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;

namespace SRD.Utils
{
    static class BitmapHelper
    {
        public static void fromArray(this Bitmap image, int[,] array)
        {
            //BitmapData imageBD = image.LockBits(
            //    new Rectangle(0, 0, image.Width, image.Height),
            //    ImageLockMode.ReadOnly, image.PixelFormat);

            //int imwith = image.Width;
            //int imheight = image.Height;
            //int imstride = imageBD.Stride;

            //unsafe
            //{
            //    byte* imagePtr = (byte*)(imageBD.Scan0);

            //    for (int i = 0; i < array.GetLength(0); i++)
            //    {
            //        for (int j = 0; j < array.GetLength(1); j++)
            //        {
            //            imagePtr = (byte*)(imageBD.Scan0);
            //            imagePtr += image.setPointerValue(i, j, imstride, imwith);

            //            *imagePtr = (byte)array[i, j];
            //            *(imagePtr + 1) = (byte)array[i, j];
            //            *(imagePtr + 2) = (byte)array[i, j];

            //            //if (4 == imstride / imwith)
            //                //*(imagePtr + 3) = 255;
            //        }
            //    }

            //    image.UnlockBits(imageBD);
            //}

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    image.SetPixel(i, j, Color.FromArgb((byte)array[i, j], (byte)array[i, j], (byte)array[i, j]));
                }
            }
        }

        public static void fromArray(this Bitmap image, int[,] array, int beneathY)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if(j < beneathY)
                        image.SetPixel(i, j, Color.FromArgb((byte)array[i, j], (byte)array[i, j], (byte)array[i, j]));
                    else if (array[i, j] != 0)
                        image.SetPixel(i, j, Color.FromArgb(255, 0, 0));
                    else
                        image.SetPixel(i, j, Color.FromArgb(0, 0, 0));
                }
            }
        }

        public static void fromArray(this Bitmap image, int[,] array, Point mouseDownP, Point mouseUpP)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (mouseDownP.Y < j && j < mouseUpP.Y && mouseDownP.X < i && i < mouseUpP.X && array[i, j] != 0)
                        image.SetPixel(i, j, Color.FromArgb(255, 0, 0));
                    else
                        image.SetPixel(i, j, Color.FromArgb((byte)array[i, j], (byte)array[i, j], (byte)array[i, j]));
                }
            }
        }

        //public static void fromArray(this Bitmap image, int[, ,] array, int t)
        //{
        //    BitmapData imageBD = image.LockBits(
        //        new Rectangle(0, 0, image.Width, image.Height),
        //        ImageLockMode.ReadOnly, image.PixelFormat);

        //    int imwith = image.Width;
        //    int imheight = image.Height;
        //    int imstride = imageBD.Stride;

        //    unsafe
        //    {
        //        byte* imagePtr = (byte*)(imageBD.Scan0);

        //        for (int i = 0; i < array.GetLength(0); i++)
        //        {
        //            for (int j = 0; j < array.GetLength(1); j++)
        //            {
        //                imagePtr = (byte*)(imageBD.Scan0);
        //                imagePtr += image.setPointerValue(i, j, imstride, imwith);

        //                *imagePtr = (byte)array[t, i, j];
        //                *(imagePtr + 1) = (byte)array[t, i, j];
        //                *(imagePtr + 2) = (byte)array[t, i, j];

        //                if (4 == imstride / imwith)
        //                    *(imagePtr + 3) = 255;
        //            }
        //        }

        //        image.UnlockBits(imageBD);
        //    }
        //}

        public static int setPointerValue(this Bitmap img, int row, int column, int stride, int width)
        {
            return (row * stride) + (column * (stride / width));
        }
    }
}
