using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Server
{
    public static class NetworkDecoder
    {


        private const long code = 4689057803456780;

        public static (int, int) FindData(ref byte[] data, int offset)
        {
            int start, end, l;
            l = data.Length;
            if(offset >= l)
            {
                return (-1, -1);
            }

            long number;
            (start, end) = (-1, -1);
            byte[] dat = new byte[8];
            while (offset < l)
            {
                dat[0] = data[offset];
                dat[1] = data[offset + 1];
                dat[2] = data[offset + 2];
                dat[3] = data[offset + 3];
                dat[4] = data[offset + 4];
                dat[5] = data[offset + 5];
                dat[6] = data[offset + 6];
                dat[7] = data[offset + 7];
                number = BitConverter.ToInt64(dat);
                if(number == code)
                {
                    if (start == -1)
                    {
                        start = offset + 8;
                    }
                    else
                    {
                        end = offset + 8;
                        break;
                    }
                }
                offset++;
            }
            return (start, end);
        }

        public static int ReadAction(ref byte[] data, int start)
        {
            return BitConverter.ToInt32(new byte[] { data[start], data[start + 1], data[start + 2], data[start + 3] });
        }

        public static float[] DecodeFloatArray(ref byte[] data, int start, int end)
        {
            int l = (end - start)/4;

            float[] result = new float[l];

            for(int i = 0; i < l; i++)
            {
                result[i] = BitConverter.ToSingle(new byte[] { data[start + i * 4], data[start + i * 4 + 1], data[start + i * 4 + 2], data[start + i * 4 + 3] });
            }

            return result;
        }

        public static string DecodeStringUTF8(ref byte[] data, int start, int stop)
        {
            return Encoding.UTF8.GetString(data, start, stop-start);
        }

        public static void ChooseAction(int key, ref byte[] data, int start, int end)
        {

        }
    }
}
