using System;
using System.Collections.Generic;
using System.Collections.Specialized;
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
            // Start timer
            Stopwatch time = new Stopwatch();
            time.Start();

            /*
             * Find the root directory
             */
            string root = Directory.GetDirectoryRoot(@"C:\");
            // find all directories in the root
            var dics = Directory.GetDirectories(root);
            foreach (string dic in dics)
            {
                Scan(dic); // scan each sub directory
            }


            // stop timer and print out result
            time.Stop();
            TimeSpan timeUsed = time.Elapsed;
            Console.WriteLine();
            Console.WriteLine($"Used time is {timeUsed.Minutes} min {timeUsed.Seconds} sec and {timeUsed.Milliseconds} msec" );

            Console.WriteLine("Number of files is " + noOfFiles);

        }

        /// <summary>
        /// Count the number of files in this directory,
        /// and make a recursive call for subdirectories in the directory
        /// </summary>
        /// <param name="path">The path to the directory</param>
        public void Scan(String path)
        {
            // show a dot for approx each 10000 dictionary - to show System status (Jacob Nielsen heuristic)
            counter++;
            if (counter % 10000 == 0) Console.Write('.');

            try
            {
                // gets all subdirectories
                var dics = Directory.GetDirectories(path);

                foreach (string d in dics)
                {
                    // recursive call for each subdirectory
                    Scan(d);
                }


                // count the number of files in this directory (specified by the parameter) 
                noOfFiles += Directory.GetFiles(path).Length;
                
            }
            catch (Exception ex)
            {
                // if unauthorized access to a file/dictionary i.e. not administrator
                // just skip
                return;
            }
        }
    }
}