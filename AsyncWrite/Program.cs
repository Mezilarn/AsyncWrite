using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace AsyncWrite
{
    class Program
    {
        async static Task Main(string[] args)
        {
            var consoleTime = NumberWrite();
            var fileTIme = WriteToFile();
            await consoleTime;
            await fileTIme;
            Console.WriteLine($"Время вывода в консоль: {consoleTime.Result} миллисекунд");
            Console.WriteLine($"Время записи в файл: {fileTIme.Result} миллисекунд");
        }

        async static Task<long> NumberWrite()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            int i = 1;
            while (i <= 1000)
            {
                Console.WriteLine(i.ToString());
                await Task.Delay(1);
                i++;
            }
            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
        }
        async static Task<long> WriteToFile()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            string path = @"c:\Файлы\number.txt";
            int i = 1;
            while (i <= 1000)
            {
                File.AppendAllText(path, $"\n{i.ToString()}");
                await Task.Delay(1);
                i++;
            }
            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
        }
    }
}
