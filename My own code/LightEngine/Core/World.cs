using LightEngine.Physics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LightEngine.Core
{
    public static class World
    {
        static readonly Dictionary<(int, int, int), Area> areas = new();

        public static string @Path { get; private set; } = string.Empty;

        public static void SaveAreas()
        {
            string @aPath = @Path + @"\areas";
            if (!Directory.Exists(aPath))
            {
                Directory.CreateDirectory(aPath);
            }

            foreach(Area area in areas.Values) 
            {
                string @number = area.xPosition.ToString() + " " + area.yPosition.ToString() + " " + area.zPosition.ToString() + @".area";
                File.Create(number);
                File.WriteAllLines(number, area.SaveObjects(), Encoding.UTF8);
            }
        }

        public static Area GetArea(int x, int y, int z)
        {
            if(areas.TryGetValue((x, y, z), out Area? value))
            {
                return value;
            }
            else
            {
                string @filePath = @Path + @"\areas" + @"\" + x.ToString() + " " + y.ToString() + " " + z.ToString() + @".area";
                if (File.Exists(filePath))
                {
                    try
                    {
                        string[] lines = File.ReadAllLines(filePath, Encoding.UTF8);

                        int i = 2;

                        value = new(new(), x, y, z);

                        while (i < lines.Length)
                        {
                            value.activeObjects.Add(new(value, lines[i], Convert.ToSingle(lines[i + 1]), Convert.ToSingle(lines[i + 2]), Convert.ToSingle(lines[i + 3]), Convert.ToSingle(lines[i + 4]), Convert.ToSingle(lines[i + 5]), Convert.ToSingle(lines[i + 6]), Convert.ToSingle(lines[i + 7]), Convert.ToSingle(lines[i + 8])));
                            i += 9;
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.HelpLink + Environment.NewLine + e.HResult + Environment.NewLine + e.Message + Environment.NewLine + e.StackTrace);
                        value = new(new(), x, y, z);
                        areas.Add((x, y, z), value);
                    }
                    return value;
                }
                else
                {
                    value = new(new(), x, y, z);
                    areas.Add((x, y, z), value);
                    return value;
                }
            }
        }
    }

    struct Intector3
    {
        public int x;
        public int y;
        public int z;

        public Intector3(int X, int Y, int Z)
        {
            x = X;
            y = Y;
            z = Z;
        }
    }
}
