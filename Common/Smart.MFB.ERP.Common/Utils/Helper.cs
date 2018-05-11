using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart.MFB.ERP.Common.Utils
{
    public class Helper
    {
        public static string GetNullIfEmpty(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return null;
            }
            return value;
        }

        public static byte[] ImageToByte2(Image img)
        {
            byte[] byteArray = new byte[0];
            using (MemoryStream stream = new MemoryStream())
            {
                img.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                stream.Close();

                byteArray = stream.ToArray();
            }
            return byteArray;
        }

    }
}
