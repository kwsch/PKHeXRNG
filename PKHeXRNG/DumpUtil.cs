using System;
using System.Text;

namespace PKHeXRNG
{
    public static class DumpUtil
    {
        public static string HexDump(byte[] data)
        {
            var sb = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                if (i != 0)
                {

                    if ((i & 0xF) == 0)
                        sb.Append(Environment.NewLine);
                    else
                        sb.Append(' ');
                }
                sb.Append(data[i].ToString("X2"));
            }
            return sb.ToString();
        }

        public static byte[] ReadHex(string data)
        {
            var str = data.Replace(" ", string.Empty);
            return StringToByteArrayFastest(str);
        }

        public static byte[] StringToByteArrayFastest(string hex)
        {
            if (hex.Length % 2 == 1)
                throw new Exception("The binary key cannot have an odd number of digits");

            byte[] arr = new byte[hex.Length >> 1];

            for (int i = 0; i < hex.Length >> 1; ++i)
            {
                arr[i] = (byte)((GetHexVal(hex[i << 1]) << 4) + (GetHexVal(hex[(i << 1) + 1])));
            }

            return arr;
        }

        public static int GetHexVal(char hex)
        {
            int val = hex;
            //Or the two combined, but a bit slower:
            return val - (val < 58 ? 48 : (val < 97 ? 55 : 87));
        }
    }
}