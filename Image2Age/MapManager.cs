using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ionic.Zlib;

namespace Image2Age
{
    class MapManager
    {
        public Image inputImage { get; set; }
        public Image outputImage {get;set;}
        public Byte[] newMap { get; set; }

        public Boolean CheckAndSaveValidImage(byte[] rawInputByteArray)
        {
            ImageChecker imageChecker = new ImageChecker();
            if (imageChecker.checkIfImageIsPNG(rawInputByteArray))
            {
                inputImage = ImageFromByteArray(rawInputByteArray);
                return true;
            }
            return false;
        }

        private Image ImageFromByteArray(byte[] rawBytes)
        {
            using (var ms = new MemoryStream(rawBytes))
            {
                return Bitmap.FromStream(ms);
            }
        }

        public void Resize(int size)
        {
            byte[] result = null;
            using (MemoryStream stream = new MemoryStream())
            using (var newImage = new Bitmap(size, size))
            using (var graphics = Graphics.FromImage(newImage))
            {
                graphics.SmoothingMode = SmoothingMode.AntiAlias;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                graphics.DrawImage(inputImage, new Rectangle(0, 0, size, size));
                newImage.Save(stream, ImageFormat.Png);
                result = stream.ToArray();
            }
            outputImage = ImageFromByteArray(result);
        }


        public void SaveMap()
        {
            // tinymap.aoe2scenario file
            // decompress and extract values. Recompress as new map
            //  8 + 3*size*size
            //  e.g. 120
            // array[120,0,0,0,120,0,0,0,<terrainvalue>,<height>,<zero>,...,32,0,0,......

            // lazy load
            byte[] buffer = new byte[]{ 49, 46, 50, 49, 0, 0, 0, 0, 3, 0, 0, 0, 101, 221, 135, 88, 1, 0, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 232, 3, 0, 0, 1, 0, 0, 0, 5, 0, 0, 0, 2, 0, 0, 0, 3, 0, 0, 0, 4, 0, 0, 0, 5, 0, 0, 0, 6, 0, 0, 0, 236, 220, 207, 106, 19, 81, 24, 192, 209, 73, 211, 54, 173, 255, 151, 226, 170, 224, 198, 149, 11, 247, 82, 137, 136, 1, 55, 130, 15, 32, 67, 13, 52, 11, 39, 208, 22, 209, 181, 46, 93, 184, 85, 112, 225, 11, 248, 2, 62, 153, 27, 227, 124, 77, 166, 142, 215, 222, 169, 216, 80, 104, 61, 63, 206, 37, 189, 36, 157, 79, 39, 51, 6, 132, 182, 168, 251, 250, 248, 203, 118, 60, 74, 146, 36, 73, 146, 164, 139, 221, 143, 217, 108, 118, 154, 213, 171, 143, 209, 172, 213, 197, 99, 180, 178, 216, 55, 245, 147, 125, 124, 221, 222, 175, 37, 251, 245, 100, 63, 72, 246, 27, 201, 126, 51, 217, 95, 74, 246, 151, 147, 253, 149, 100, 127, 53, 217, 95, 75, 246, 215, 147, 253, 141, 197, 190, 249, 251, 22, 183, 138, 253, 242, 85, 89, 85, 229, 238, 243, 131, 73, 245, 230, 110, 57, 29, 223, 219, 223, 25, 87, 229, 222, 100, 154, 59, 121, 173, 227, 29, 21, 39, 170, 233, 232, 224, 202, 212, 75, 250, 156, 57, 171, 39, 30, 167, 227, 185, 184, 148, 115, 181, 223, 173, 180, 246, 229, 146, 22, 151, 123, 174, 184, 244, 115, 197, 109, 144, 107, 163, 227, 185, 184, 61, 114, 197, 173, 146, 43, 110, 155, 92, 113, 11, 229, 138, 219, 41, 87, 220, 90, 185, 226, 54, 139, 247, 240, 164, 43, 255, 93, 125, 226, 239, 220, 158, 159, 127, 203, 178, 254, 207, 37, 73, 146, 36, 73, 146, 36, 73, 146, 36, 73, 146, 36, 73, 146, 36, 73, 231, 165, 127, 253, 121, 151, 223, 234, 117, 254, 168, 202, 95, 85, 255, 49, 36, 73, 210, 25, 231, 243, 91, 146, 164, 243, 151, 207, 111, 73, 146, 206, 95, 237, 207, 226, 248, 125, 81, 167, 89, 241, 127, 250, 77, 199, 253, 150, 176, 215, 139, 181, 13, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 156, 185, 205, 162, 171, 209, 195, 139, 253, 220, 175, 226, 60, 220, 44, 158, 237, 140, 171, 114, 111, 50, 221, 122, 244, 98, 114, 48, 221, 219, 122, 186, 91, 86, 7, 211, 151, 197, 219, 193, 183, 225, 251, 251, 79, 134, 163, 98, 20, 47, 237, 23, 253, 121, 241, 157, 189, 122, 173, 118, 172, 69, 15, 254, 24, 57, 171, 203, 143, 44, 138, 15, 195, 88, 205, 200, 102, 102, 124, 103, 28, 182, 107, 108, 60, 183, 140, 145, 139, 153, 205, 200, 174, 177, 43, 203, 26, 57, 159, 217, 30, 153, 27, 123, 248, 162, 165, 140, 60, 156, 153, 142, 204, 141, 93, 210, 200, 152, 121, 220, 200, 116, 236, 218, 18, 71, 214, 51, 115, 35, 219, 99, 215, 151, 57, 114, 254, 46, 117, 221, 32, 49, 118, 208, 53, 242, 211, 199, 232, 123, 253, 175, 85, 171, 159, 3, 0 };
            int index = 23995;
            int lenght = 8 + 3 * 120 * 120;
                                  
            var mapHeader = buffer.Take(61).ToArray();
            var compressed = buffer.Skip(61).ToArray();

            var decompress = new Func<byte[], byte[]>(a => {
                using (var ms = new MemoryStream())
                {

                    using (var decompressor = new DeflateStream(ms, CompressionMode.Decompress, CompressionLevel.Level9))
                    {
                        decompressor.Write(a, 0, a.Length);
                    }
                    return ms.ToArray();
                }
            });

            var uncompressedMapContent = decompress(compressed);
            
            //header
            var header = uncompressedMapContent.Take(index).ToArray();

            // body
            var map = convertMap();

            //foot
            var foot = uncompressedMapContent.Skip(index + lenght).ToArray();

            //combine
            byte[] newMapContent = new byte[header.Length + map.Length + foot.Length];
            Buffer.BlockCopy(header, 0, newMapContent, 0, header.Length);
            Buffer.BlockCopy(map, 0, newMapContent, header.Length, map.Length);
            Buffer.BlockCopy(foot, 0, newMapContent, header.Length + map.Length, foot.Length);

            //recompress as new map
            var compress = new Func<byte[], byte[]>(a => {
                using (var ms = new MemoryStream())
                {

                    using (var compressor = new DeflateStream(ms, CompressionMode.Compress, CompressionLevel.Level9))
                    {
                        compressor.Write(a, 0, a.Length);
                    }
                    return ms.ToArray();
                }
            });

            var compressedMapContent = compress(newMapContent);

            newMap = compressedMapContent;
            // FIX THIS
        }


        public int[] convertMap()
        {
            MapConverter mapConverter = new MapConverter();
            return mapConverter.Convert(outputImage);
        }
    }
}
