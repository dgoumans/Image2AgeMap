using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Image2Age
{
    class ImageChecker
    {
        byte[] png = { 137, 80, 78, 71 };    // PNG

       public  Boolean checkIfImageIsPNG(byte[] image)
        {
            if (png.SequenceEqual(image.Take(png.Length)))
            {
                return true;
            }
            return false;
        }
    }
}
