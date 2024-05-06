using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Png;

namespace catScanner
{
    static class imageSharpExtension
    {
        public static byte[] ToArray(this SixLabors.ImageSharp.Image imageIn)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                imageIn.Save(ms, PngFormat.Instance);
                return ms.ToArray();
            }
        }

        public static System.Drawing.Image ToDrawingImage(this byte[] byteArrayIn)
        {
            using (MemoryStream ms = new MemoryStream(byteArrayIn))
            {
                System.Drawing.Image returnImage = System.Drawing.Image.FromStream(ms);
                return returnImage;
            }
        }
    }

}
