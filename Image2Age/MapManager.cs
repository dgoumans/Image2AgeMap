using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            // map.aoe2scenario file
            // decompress and extract values. Recompress as new map
            //  8 + 7*size*size

            // lazy load
            byte[] buffer = new byte[] { 49, 46, 51, 55, 0, 0, 0, 0, 5, 0, 0, 0, 3, 135, 169, 94, 1, 0, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 232, 3, 0, 0, 1, 0, 0, 0, 6, 0, 0, 0, 2, 0, 0, 0, 3, 0, 0, 0, 4, 0, 0, 0, 5, 0, 0, 0, 6, 0, 0, 0, 7, 0, 0, 0, 6, 0, 0, 0, 68, 105, 122, 122, 121, 0, 0, 0, 0, 0, 236, 219, 189, 138, 19, 81, 24, 128, 225, 51, 155, 253, 49, 254, 182, 218, 45, 104, 161, 141, 133, 157, 90, 40, 9, 66, 74, 193, 194, 198, 194, 97, 29, 48, 133, 9, 100, 131, 120, 1, 54, 130, 197, 130, 149, 130, 151, 32, 94, 134, 94, 133, 215, 224, 21, 24, 231, 36, 25, 55, 102, 51, 103, 97, 119, 10, 179, 62, 47, 124, 60, 201, 30, 51, 159, 78, 214, 114, 66, 217, 173, 103, 95, 31, 68, 37, 73, 146, 36, 73, 210, 217, 238, 215, 100, 50, 57, 205, 100, 229, 53, 226, 220, 40, 103, 115, 254, 58, 86, 189, 175, 58, 235, 239, 79, 90, 117, 191, 194, 181, 208, 237, 118, 199, 197, 254, 248, 105, 62, 46, 70, 183, 243, 97, 113, 103, 127, 175, 24, 228, 163, 254, 176, 238, 222, 175, 186, 94, 107, 213, 181, 85, 83, 182, 212, 231, 154, 187, 122, 236, 117, 18, 103, 27, 137, 179, 197, 111, 107, 185, 212, 111, 215, 86, 226, 108, 59, 113, 182, 147, 56, 59, 151, 56, 107, 39, 206, 206, 39, 206, 46, 36, 206, 46, 38, 206, 46, 37, 206, 46, 39, 206, 174, 148, 19, 191, 195, 227, 126, 243, 223, 150, 55, 254, 230, 245, 217, 253, 55, 198, 252, 159, 35, 73, 146, 36, 73, 146, 36, 73, 146, 36, 73, 146, 36, 73, 146, 36, 73, 235, 210, 73, 159, 119, 249, 171, 172, 145, 7, 161, 254, 153, 226, 243, 58, 167, 153, 120, 79, 171, 238, 215, 236, 120, 94, 62, 52, 19, 167, 124, 210, 229, 231, 151, 31, 211, 39, 132, 222, 204, 231, 94, 8, 241, 147, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 172, 21, 237, 16, 235, 117, 103, 243, 189, 115, 56, 139, 63, 95, 239, 179, 248, 111, 188, 26, 158, 236, 21, 131, 124, 212, 31, 238, 62, 122, 209, 31, 15, 71, 187, 143, 95, 230, 131, 241, 240, 85, 184, 251, 250, 67, 231, 219, 187, 247, 157, 94, 232, 133, 208, 14, 173, 208, 154, 21, 63, 155, 149, 179, 153, 152, 121, 15, 15, 95, 206, 139, 183, 182, 126, 101, 8, 7, 229, 95, 238, 224, 207, 202, 106, 103, 252, 100, 188, 108, 106, 109, 60, 107, 98, 229, 124, 103, 181, 50, 181, 118, 163, 169, 149, 179, 157, 139, 43, 235, 214, 78, 255, 80, 35, 43, 167, 59, 151, 87, 214, 173, 109, 104, 101, 220, 185, 106, 229, 242, 218, 173, 6, 87, 150, 59, 235, 86, 46, 174, 221, 110, 114, 229, 236, 91, 74, 253, 7, 137, 107, 119, 82, 43, 143, 252, 112, 69, 159, 62, 198, 178, 163, 23, 144, 244, 127, 247, 123, 0 };
            int length = 8 + 7 * 120 * 120;

            var mapHeader = buffer.Take(79).ToArray();

            // content
            var compressed = buffer.Skip(79).ToArray(); 
            var uncompressedMapContent = decompress(compressed);
            int index = Array.FindIndex(uncompressedMapContent, element => element.Equals(120));

            //header
            var header = uncompressedMapContent.Take(index).ToArray();
            //foot
            var foot = uncompressedMapContent.Skip(index + length).ToArray();

            // body
    
             var tempMap = uncompressedMapContent.Take(index + length).ToArray();
             var map = tempMap.Skip(index).ToArray();
            //var map = convertMap();

           // Console.WriteLine(string.Join(", ", map));
           // Console.WriteLine(string.Join(", ", mapTest));

            //combine
            byte[] newMapContent = new byte[header.Length + map.Length + foot.Length];
            Buffer.BlockCopy(header, 0, newMapContent, 0, header.Length);
            Buffer.BlockCopy(map, 0, newMapContent, header.Length, map.Length);
            Buffer.BlockCopy(foot, 0, newMapContent, header.Length + map.Length, foot.Length);

            //recompress as new map
            var compressedMapContent0 = compress(newMapContent, 0);
            var compressedMapContent1 = compress(newMapContent,1);
            var compressedMapContent2 = compress(newMapContent, 2);
            var compressedMapContent3 = compress(newMapContent, 3);
            var compressedMapContent4 = compress(newMapContent, 4);
            var compressedMapContent5 = compress(newMapContent, 5);
            var compressedMapContent6 = compress(newMapContent, 6);
            var compressedMapContent7 = compress(newMapContent, 7);
            var compressedMapContent8 = compress(newMapContent, 8);
            var compressedMapContent9 = compress(newMapContent, 9);
            // Console.WriteLine(string.Join(", ", mapTest));
            Console.WriteLine("Orig: " + string.Join(", ", compressed));
            Console.WriteLine("lvl0: " + string.Join(", ", compressedMapContent0));
            Console.WriteLine("lvl1: " + string.Join(", ", compressedMapContent1));
            Console.WriteLine("lvl2: " + string.Join(", ", compressedMapContent2));
            Console.WriteLine("lvl3: " + string.Join(", ", compressedMapContent3));
            Console.WriteLine("lvl4: " + string.Join(", ", compressedMapContent4));
            Console.WriteLine("lvl5: " + string.Join(", ", compressedMapContent5));
            Console.WriteLine("lvl6: " + string.Join(", ", compressedMapContent6));
            Console.WriteLine("lvl7: " + string.Join(", ", compressedMapContent7));
            Console.WriteLine("lvl8: " + string.Join(", ", compressedMapContent8));
            Console.WriteLine("lvl9: " + string.Join(", ", compressedMapContent9));


            var compressedMapContent = compress(newMapContent, 9);

            byte[] combined = new byte[mapHeader.Length + compressedMapContent.Length];
            Buffer.BlockCopy(mapHeader, 0, combined, 0, mapHeader.Length);
            Buffer.BlockCopy(compressedMapContent, 0, combined, mapHeader.Length, compressedMapContent.Length);

            newMap = combined;
        }


        public int[] convertMap()
        {
            MapConverter mapConverter = new MapConverter();
            return mapConverter.Convert(outputImage);
        }

        private byte[] decompress(byte[] a)
        {
                using (var ms = new MemoryStream())
                {
                    using (var decompressor = new DeflateStream(ms, CompressionMode.Decompress, CompressionLevel.Level9))
                    {
                        decompressor.Write(a, 0, a.Length);
                    }
                    return ms.ToArray();
                }           
        }

        private byte[] compress(byte[] a, int level)
        {
            using (var ms = new MemoryStream())
            {
                CompressionLevel compressionLevel = CompressionLevel.Default;

                switch (level)
                {
                    case 0:
                        compressionLevel = CompressionLevel.Level0;
                        break;
                    case 1:
                        compressionLevel = CompressionLevel.Level1;
                        break;
                    case 2:
                        compressionLevel = CompressionLevel.Level2;
                        break;
                    case 3:
                        compressionLevel = CompressionLevel.Level3;
                        break;
                    case 4:
                        compressionLevel = CompressionLevel.Level4;
                        break;
                    case 5:
                        compressionLevel = CompressionLevel.Level5;
                        break;
                    case 6:
                        compressionLevel = CompressionLevel.Level6;
                        break;
                    case 7:
                        compressionLevel = CompressionLevel.Level7;
                        break;
                    case 8:
                        compressionLevel = CompressionLevel.Level8;
                        break;
                    case 9:
                        compressionLevel = CompressionLevel.Level9;
                        break;
                }

                using (var compresssor = new Ionic.Zlib.DeflateStream(ms, CompressionMode.Compress, compressionLevel))
                {
                    compresssor.Write(a, 0, a.Length);
                }
                return ms.ToArray();
            }
        }
    }
}
