using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LightEngine.Core
{
    public static class Kernel
    {
        public static bool Rendering { get; private set; } = false;

        static byte[,,] world = new byte[100, 100, 100];

        public static void Start()
        {
            Physics();
        }



        static void Physics()
        {
            Task[] tasks;
            while (Rendering)
            {
                tasks = new Task[2];
                
                Task.WaitAll(tasks);
            }
        }

        static void AI()
        {

        }
    }
}

