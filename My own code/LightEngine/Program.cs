using LightEngine.PROCESSOR;

namespace LightEngine
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Hello, World!");
            var a = new ThreadController();
            a.Info();
            Console.ReadLine();
        }
    }
}
