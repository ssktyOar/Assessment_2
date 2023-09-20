using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace LightEngine.IO
{
    public static class Terminal
    {
        private static readonly Dictionary<string, Action> actions = new();
        private static Thread? t;

        static bool work = true;

        private static void Command(string command)
        {
            if (actions.TryGetValue(command, out Action? action))
            {
                action();
                Console.WriteLine("Command" + command + "added");
            }
            else
            {
                Console.WriteLine("Error 0000: Command not found");
            }
        }

        private static void Work()
        {
            while (work)
            {
                Command(@Console.ReadLine() + "");
            }
        }

        private static void Stop()
        {
            work = false;
        }

        public static void Start()
        {
            actions.Add("STOP", Stop);

            t = new(Work);
            t.Start();
        }
    }
    public struct ActionData
    {
        public Action action;
        public string command;

        public ActionData(Action _action, string _command)
        {
            action = _action;
            command = _command;
        }
    }
}
