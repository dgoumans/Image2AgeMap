using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Image2Age
{
    class MapConverter
    {
        public int[] Convert(Image image)
        {
            var valueArray = GetImageRGBValues(image);

            List<int> map = new List<int>(new int[] { image.Width, 0, 0, 0, image.Height, 0, 0, 0 });

            for (int i=0; i < valueArray.Length; i++)
            {
                map.Add(58);
                map.Add(0);
                map.Add(0);
                map.Add(255);
                map.Add(255);
                map.Add(255);
                map.Add(255);
            }
            return map.ToArray();
        }


        private int[] GetImageRGBValues(Image image)
        {
            List<int> result = new List<int>();
            
            Bitmap myBitmap = new Bitmap(image);

            for (int i = 0; i < myBitmap.Width; i++)
            {
                for (int j = 0; j < myBitmap.Height; j++)
                {
                    Color pixel = myBitmap.GetPixel(i, j);
                 
                    var closestColorValue = GetClosestColorValue(Color.FromArgb(pixel.ToArgb()));

                    result.Add(closestColorValue);
                }
            }
            return result.ToArray();
        }

        private static Color[] ColorArray =
        {
            Color.FromArgb(255, 101, 127, 180), // water
            Color.FromArgb(255, 207, 171, 136), // desert
            Color.FromArgb(255, 65, 133, 70)  // grass
        };

        private int GetClosestColorValue(Color baseColor)
        {
            var colors = ColorArray.Select(x => new { Value = x, Diff = GetDiff(x, baseColor) }).ToList();
            var min = colors.Min(x => x.Diff);
            var closest = colors.Find(x => x.Diff == min).Value;

           if(closest == ColorArray[0]) // water
            {
                return 23;
            }
            if (closest == ColorArray[1]) // dirt
            {
                return 23;
            }

            if (closest == ColorArray[2])  // grass
            {
                return 23;
            }      
            return 23; // desert
        }

        private int GetDiff(Color color, Color baseColor)
        {
            int a = color.A - baseColor.A,
                r = color.R - baseColor.R,
                g = color.G - baseColor.G,
                b = color.B - baseColor.B;
            return a * a + r * r + g * g + b * b;
        }

        
    }
}
