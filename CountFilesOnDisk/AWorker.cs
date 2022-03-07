using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace CountFilesOnDisk
{
    public class AWorker
    {
        private static int noOfFiles = 0;
        private static int counter = 0;
        
        public AWorker()
        {
        }

        public void Start()
        {
            Stopwatch time = new Stopwatch();
            time.Start();
            
            string root = Directory.GetDirectoryRoot(@"\");
            var dics = Directory.GetDirectories(root);
            foreach (string dic in dics)
            {
                Scan(dic);
            }

            time.Stop();
            TimeSpan timeUsed = time.Elapsed;
            Console.WriteLine();
            Console.WriteLine($"Used time is {timeUsed}");

            Console.WriteLine("Number of files is " + noOfFiles);

        }

        public void Scan(String path)
        {
            counter++;
            if (counter % 10000 == 0) Console.Write('.');

            try
            {
                var dics = Directory.GetDirectories(path);

                foreach (string d in dics)
                {
                    Scan(d);
                }

                noOfFiles += Directory.GetFiles(path).Length;
            }
            catch (Exception ex)
            {
                // if unautorized acces to a file/dictionary i.e. not administrator
                // just skip
                return;
            }
        }
    }
}