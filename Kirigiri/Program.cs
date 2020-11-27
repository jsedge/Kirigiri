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
            var im = ImageFile.FromFile(args[0]);
            var api = new SauceNao();
            var res = api.Search(args[0]);
            im.Properties.Set(ExifTag.ImageDescription, res.Results[0].URLs[0]);
            im.Save(args[0]);
        }
    }
}
