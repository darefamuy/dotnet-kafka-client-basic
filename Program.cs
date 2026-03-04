using System;
using System.Threading.Tasks;

Console.WriteLine("Starting Producer ...");
await Producer.RunAsync();

Console.WriteLine();
Console.WriteLine("Starting Consumer ...");
Consumer.Run();

Console.WriteLine();
Console.WriteLine("Done...");