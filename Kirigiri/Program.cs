using System;
using System.IO;
using ExifLibrary;

namespace Kirigiri
{
    class Program
    {
        static void Main(string[] args)
        {
            if(args.Length == 0){
                Console.WriteLine("Please pass a directory or a file path");
                return;
            }
            if(File.Exists(args[0])){
                //Console.WriteLine("Passed a valid file, will process");
                ProcessFile(args[0]);
            }else if(Directory.Exists(args[0])){
                //Console.WriteLine("Passed a valid folder, will process");
                ProcessFolder(args[0]);
            }else{
                Console.WriteLine($"Cannot find the path {args[0]}");
                return;
            }
        }

        private static void ProcessFolder(string folderPath){
            foreach (var file in Directory.EnumerateFiles(folderPath))
            {
                ProcessFile(file);
            }
        }

        private static void ProcessFile(string filePath){
            var im = ImageFile.FromFile(filePath);
            var api = new SauceNao();
            var res = api.Search(filePath);
            Console.WriteLine($"Found source URL {res.Results[0].URLs[0]} with {res.Results[0].Similarity}% similarity");
            im.Properties.Set(ExifTag.ImageDescription, res.Results[0].URLs[0]);
            im.Save(filePath);
        }
    }
}
