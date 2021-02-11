using System;
using System.IO;
using System.Numerics;
using System.Diagnostics;

namespace ProceduralVMF
{
    class Program
    {
        public static int MAX_MAP_SIZE = 32768;


        static void Error(string err)
        {
            Console.WriteLine("Error: " + err);
            Console.ReadKey();
        }

        public static void Main()
        {
            Console.Write("Enter the file you want to write to: ");
            string newpath = Console.ReadLine() + ".vmf";

            if (File.Exists(newpath))
            {
                Console.Write("File " + newpath + " already exists, overwrite? [y/n]: ");
                if (Console.ReadLine().ToLower() != "y")
                {
                    return;
                }

                File.Delete(newpath);
            }

            ReAsk:;

            Console.Write("Box size: ");
            if (!int.TryParse(Console.ReadLine(), out int BoxSize))
            {
                goto ReAsk;
            }

            Console.Write("Fill with displacements? [y/n]: ");
            bool UseDisplacement = Console.ReadLine().ToLower() == "y";

            Console.WriteLine("\nAssembling map...");
            Generator generator = new Generator();

            Stopwatch watch = new Stopwatch();
            watch.Start();

            for (int i = 1; i <= MAX_MAP_SIZE / BoxSize - 1; i++)
            {
                if (UseDisplacement) {
                    generator.MakeSolid(generator.MakeDisplacement(new Vector3((i * BoxSize) - (MAX_MAP_SIZE * 0.5f), 0, 0), new Vector3(BoxSize, BoxSize, 128)));
                } else {
                    generator.MakeSolid(generator.MakeCube(new Vector3((i * BoxSize) - (MAX_MAP_SIZE * 0.5f), 0, 0), new Vector3(BoxSize, BoxSize, 128)));
                }

                for (int j = 1; j <= MAX_MAP_SIZE / BoxSize - 1; j++)
                {
                    if (UseDisplacement) {
                        generator.MakeSolid(generator.MakeDisplacement(new Vector3((i * BoxSize) - (MAX_MAP_SIZE * 0.5f), (j * BoxSize) - (MAX_MAP_SIZE * 0.5f), 128),
                                                                       new Vector3(BoxSize, BoxSize, 128)));
                    } else {
                        generator.MakeSolid(generator.MakeCube(new Vector3((i * BoxSize) - (MAX_MAP_SIZE * 0.5f), (j * BoxSize) - (MAX_MAP_SIZE * 0.5f), 128), new Vector3(BoxSize, BoxSize, 128)));
                    }
                }
            }

            //generator.MakeSolid(generator.MakeCube(new Vector3(0, 0, 0), new Vector3(1024, 1024, 128)));

            Console.WriteLine("Generating...");
            string MapToWrite = generator.Generate();

            Console.WriteLine("Writing to file...");
            File.WriteAllText(newpath, MapToWrite);

            Console.WriteLine("Created file " + newpath);

            watch.Stop();
            TimeSpan time = watch.Elapsed;
            Console.WriteLine("Took: " + time.Seconds + " seconds");
            
            Console.ReadLine();
        }
    }
}