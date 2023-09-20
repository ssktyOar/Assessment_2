using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightEngine.IO
{
    public static class IOController
    {
        public static string ReadProgram(string @path)
        {
            if (File.Exists(@path))
            {
                Console.WriteLine(@path);
                return File.ReadAllText(@path, Encoding.UTF8);
            }
            else
            {
                return string.Empty;
            }
        }

        public static void WriteData(string data, string path, string @fileName, string @fileType)
        {
            string number = string.Empty;
            int count = 0;
            if (!Directory.Exists(@path))
            {
                Directory.CreateDirectory(@path);
            }
            while (File.Exists(@path + fileName + number + fileType))
            {
                count++;
                number = " " + count.ToString();
            }

            File.Create(@path + fileName + number + fileType);

            File.WriteAllText(@path + fileName + number + fileType, data);
        }
    }
}
