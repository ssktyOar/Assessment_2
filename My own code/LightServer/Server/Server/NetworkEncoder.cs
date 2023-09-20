using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Server
{
    public static class NetworkEncoder
    {
        private static readonly byte[] codeBytes = BitConverter.GetBytes(4689057803456780);

        private static void WriteKey(ref byte[] result, int offset)
        {
            result[0] = codeBytes[0];
            result[1] = codeBytes[1];
            result[2] = codeBytes[2];
            result[3] = codeBytes[3];
            result[4] = codeBytes[4];
            result[5] = codeBytes[5];
            result[6] = codeBytes[6];
            result[7] = codeBytes[7];
            result[offset] = codeBytes[0];
            result[offset + 1] = codeBytes[1];
            result[offset + 2] = codeBytes[2];
            result[offset + 3] = codeBytes[3];
            result[offset + 4] = codeBytes[4];
            result[offset + 5] = codeBytes[5];
            result[offset + 6] = codeBytes[6];
            result[offset + 7] = codeBytes[7];
        }

        public static byte[] EncodeAction(int action)
        {
            byte[] result = new byte[20];
            WriteKey(ref result, 12);
            byte[] dat = BitConverter.GetBytes(action);
            result[8] = dat[0];
            result[9] = dat[1];
            result[10] = dat[2];
            result[11] = dat[3];
            return result;
        }

        public static byte[] EncodeFloatArray(float[] data)
        {
            int l = data.Length;
            int i = 0;
            byte[] dat;
            byte[] result = new byte[l * 4 + 16];
            while (i < l)
            {
                dat = BitConverter.GetBytes(data[i]);
                result[i * 4 + 8] = dat[0];
                result[i * 4 + 9] = dat[1];
                result[i * 4 + 10] = dat[2];
                result[i * 4 + 11] = dat[3];
                i++;
            }
            WriteKey(ref result, i * 4 + 8);
            return result;
        }

        public static byte[] EncodeStringUTF8(string s)
        {
            return Encoding.UTF8.GetBytes(s);
        }
    }
}
