using System;

namespace CountFilesOnDisk
{
    class Program
    {
        static void Main(string[] args)
        {
            AWorker worker = new AWorker();
            worker.Start();

            Console.Write("Strike a key : ");
            Console.ReadKey();
        }
    }
}
