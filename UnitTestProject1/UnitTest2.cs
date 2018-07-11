using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Linq;
using System.Drawing;
using System.Collections.Generic;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest2
    {
        string newFilePath2 = @"C:\Users\Administrator\Desktop\图片\newbit2.png";
        void ImageCheck()
        {
            /*  70x20=1400  rgb */
            var files = Directory.GetFiles(@"C:\Users\Administrator\Desktop\图片");
            files.ToList().ForEach(file =>
            {
                clearFile(file);
            });
        }

        private void clearFile(string file)
        {
            int width;
            int height;
            var list = new List<PointLink>();

            using (Bitmap bit = (Bitmap)Image.FromFile(file))
            {
                width = bit.Width;
                height = bit.Height;
                for (int x = 0; x < bit.Width; x++)
                {
                    for (int y = 0; y < height; y++)
                    {
                        if (y < height - 1)
                        {
                            list.Add(new PointLink { X1 = x, Y1 = y, Color1 = bit.GetPixel(x, y), X2 = x, Y2 = y + 1, Color2 = bit.GetPixel(x, y + 1) });
                        }

                        if (x < width - 1)
                        {
                            list.Add(new PointLink { X1 = x, Y1 = y, Color1 = bit.GetPixel(x, y), X2 = x + 1, Y2 = y, Color2 = bit.GetPixel(x + 1, y) });
                            if (y < height - 1)
                            {
                                list.Add(new PointLink { X1 = x, Y1 = y, Color1 = bit.GetPixel(x, y), X2 = x + 1, Y2 = y + 1, Color2 = bit.GetPixel(x + 1, y + 1) });
                            }
                        }
                    }
                }
            }

            list = list.OrderByDescending(m => m.Avg).Take(600).ToList();
            var list2 = list.OrderBy(m => m.Avg).Take(600).ToList();
            list = list.Concat(list2).ToList();

            Bitmap newBitmap = new Bitmap(width, height);
            list.ForEach(link =>
            {
                if (link.Color1.IsOld())
                {
                    newBitmap.SetPixel(link.X1, link.Y1, Color.Black);
                } if (link.Color2.IsOld())
                {
                    newBitmap.SetPixel(link.X2, link.Y2, Color.Black);
                }
            });
            string newFilePath = string.Format(@"C:\Users\Administrator\Desktop\图片\{0}.png", Guid.NewGuid());
            newBitmap.Save(newFilePath);
        }

        [TestMethod]
        public void TestMethod1()
        {
            ImageCheck();
        }

        private void tt1(char chat)
        {
            string newFilePath = string.Format(@"C:\Users\Administrator\Desktop\图片\base_{0}.png", chat);
            Bitmap newBitmap = new Bitmap(20, 20);
            CreateBigmap(newBitmap, chat);
            newBitmap.Save(newFilePath);
            //UpdateBgColor(newFilePath, Color.Red, Color.Black);
        }

        private void UpdateBgColor(string path, Color color, Color backColor)
        {
            using (Bitmap newBitmap = (Bitmap)Image.FromFile(path))
            {
                Bitmap bitmap = new Bitmap(newBitmap.Width, newBitmap.Height);
                for (int x = 0; x < newBitmap.Width; x++)
                {
                    for (int y = 0; y < newBitmap.Height; y++)
                    {
                        var pixelColor = newBitmap.GetPixel(x, y);

                        if (pixelColor.A == backColor.A && pixelColor.R == backColor.R && pixelColor.G == backColor.G && pixelColor.B == backColor.B)
                        {
                            bitmap.SetPixel(x, y, Color.FromArgb(new Random(GetRandomSeed()).Next(256), new Random(GetRandomSeed()).Next(256), new Random(GetRandomSeed()).Next(256)));
                        }
                        else
                        {
                            bitmap.SetPixel(x, y, color);
                        }
                    }
                }
                bitmap.Save(newFilePath2);
            }
        }

        static int GetRandomSeed()
        {
            byte[] bytes = new byte[4];
            System.Security.Cryptography.RNGCryptoServiceProvider rng = new System.Security.Cryptography.RNGCryptoServiceProvider();
            rng.GetBytes(bytes);
            return BitConverter.ToInt32(bytes, 0);
        }

        private void CreateBigmap(Bitmap newBitmap, char str)
        {
            Graphics g = Graphics.FromImage(newBitmap);
            Font font = new Font("宋体", 13);
            SolidBrush sbrush = new SolidBrush(Color.Black);
            g.DrawString("" + str, font, sbrush, 0, 0);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var chats = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            chats.ToCharArray().ToList().ForEach(tt1);
        }

    }

    public static class ColorExt
    {
        public static bool IsOld(this Color color)
        {
            if (((int)color.R + (int)color.G + (int)color.B) / 3 < 128)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public class PointLink
    {
        public int X1 { get; set; }

        public int Y1 { get; set; }

        public Color Color1 { get; set; }

        public int X2 { get; set; }

        public int Y2 { get; set; }

        public Color Color2 { get; set; }

        public int Avg
        {
            get
            {
                return (Math.Abs(Color1.R - Color2.R) + Math.Abs(Color1.G - Color2.G) + Math.Abs(Color1.B - Color2.B)) / 3;
            }
        }
    }
}
