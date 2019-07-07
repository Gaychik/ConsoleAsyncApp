using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;

namespace ConsoleWorkFilesApp
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 1; i < 8; i++)
            {
                WriteASync(i.ToString());
            }
            Thread.Sleep(5000);
            Console.WriteLine("Loading....");
            Console.Read();
        }
        static async void WriteASync(string NameFile)
        {
            string path = @"D:\Task" + NameFile;
            Random gen = new Random();
            using (StreamWriter writer = new StreamWriter(File.Open(path, FileMode.Create), Encoding.Default))
            {
                //await Task.Run(() =>
                //{
                //    for (int i = 0; i < 1000000; i++)
                //    {
                //        writer.Write(gen.Next(0, 1000) + " ");
                //    }
                //});
                for (int i = 0; i < 1000000; i++)
                {
                    await writer.WriteAsync(gen.Next(0, 10000) + " ");
                }
                Console.WriteLine($"The task №{NameFile} is complete!");
            }
        }
        
    }
}
