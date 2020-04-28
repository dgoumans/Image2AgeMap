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
                map.Add(valueArray[i]);
                map.Add(0);
                map.Add(0);
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
            Color.FromArgb(255, 0, 128, 255), // water
            Color.FromArgb(255, 255, 250, 250), // snow
            Color.FromArgb(255, 0, 255, 0)  // grass
        };

        private int GetClosestColorValue(Color baseColor)
        {
            var colors = ColorArray.Select(x => new { Value = x, Diff = GetDiff(x, baseColor) }).ToList();
            var min = colors.Min(x => x.Diff);
            var closest = colors.Find(x => x.Diff == min).Value;

           if(closest == Color.FromArgb(255, 0, 128, 255)) // water
            {
                return 58;
            }
            if (closest == Color.FromArgb(255, 255, 250, 250)) // snow
            {
                return 32;
            }

            if (closest == Color.FromArgb(255, 0, 255, 0))  // grass
            {
                return 12;
            }      
            return 14; // desert
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
