namespace DigitalCookbook
{
    static public class ImageHelper
    {
        static public byte[] ImageToByteArray(Image imageIn)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                Bitmap bm = new Bitmap(imageIn);
                bm.Save(ms, imageIn.RawFormat);
                return ms.ToArray();
            }
        }
    }
}
