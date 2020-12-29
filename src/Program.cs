using System;
using System.Threading.Tasks;
namespace FileRepeater
{
    class Program
    {
        static async Task Main(string[] args)
        {
            IFileParam fileParam = new FileParam();
            fileParam.Parse(args);

            await new FileCopier().ProcessFileAsync(fileParam);

            Console.WriteLine("Done!");
        }
    }
}
