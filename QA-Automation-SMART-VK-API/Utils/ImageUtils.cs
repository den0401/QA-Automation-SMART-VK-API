using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;

namespace QA_Automation_SMART_VK_API.Utils
{
    public static class ImageUtils
    {
        public static void DownloadImage(string address, string path)
        {
            using (WebClient webClient = new WebClient())
            {
                byte[] data = webClient.DownloadData(address);

                using (MemoryStream mem = new MemoryStream(data))
                {
                    using (var yourImage = Image.FromStream(mem))
                    {
                        yourImage.Save(path, ImageFormat.Jpeg);
                    }
                }
            }
        }

        public static bool CompareImages(string pathToImage1, string pathToImage2)
        {            
            string img1_ref, img2_ref;
            int countPixelMatch = 0;
            int countPixelMismatch = 0;
            int minMatchingPercent = 80;

            Bitmap bitMap1 = new Bitmap(pathToImage1);
            Bitmap bitMap2 = new Bitmap(pathToImage2);

            if (bitMap1.Width == bitMap2.Width && bitMap1.Height == bitMap2.Height)
            {
                for (int i = 0; i < bitMap1.Width; i++)
                {
                    for (int j = 0; j < bitMap1.Height; j++)
                    {
                        img1_ref = bitMap1.GetPixel(i, j).ToString();
                        img2_ref = bitMap2.GetPixel(i, j).ToString();
                        if (img1_ref != img2_ref)
                        {
                            countPixelMismatch++;
                            break;
                        }
                        countPixelMatch++;
                    }
                }

                if (countPixelMismatch == 0 || countPixelMatch / countPixelMismatch * 100 >= minMatchingPercent)
                    return true;
                else
                    return false;
            }
            else
                return false;
        }
    }
}