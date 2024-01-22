using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;
using OtusCProHomework4;
using OtusCProHomework4.Deserialize;
using OtusCProHomework4.Models;
using OtusCProHomework4.Serialize;
using System;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using System.Text.Json;

public class Program
{
    public static void Main()
    {
        var csvSerializer = new CsvSerializer();
        var csvDeserializer = new CsvDeserializer();
        var stopwatch = new Stopwatch();

        // Serialize and Deserialize with various object sizes
        foreach (var size in Enumerable.Range(1, 5))
        {
            Console.Write(size + ". ");
            var f = F.Get(size);

            // CSV Serialization
            stopwatch.Restart();
            for (int i = 0; i < 100000; i++)
            {
                csvSerializer.Serialize(f);
            }
            stopwatch.Stop();
            Console.WriteLine($"CSV serialization time for object size {size}: {stopwatch.ElapsedMilliseconds} ms");

            // JSON Serialization
            stopwatch.Restart();
            for (int i = 0; i < 100000; i++)
            {
                JsonSerializer.Serialize(f);
            }
            stopwatch.Stop();
            Console.WriteLine($"JSON serialization time for object size {size}: {stopwatch.ElapsedMilliseconds} ms");

            // CSV Deserialization
            var csvData = csvSerializer.Serialize(f);
            stopwatch.Restart();
            for (int i = 0; i < 100000; i++)
            {
                csvDeserializer.Deserialize<F>(csvData);
            }
            stopwatch.Stop();
            Console.WriteLine($"CSV deserialization time for object size {size}: {stopwatch.ElapsedMilliseconds} ms");

            // JSON Deserialization
            var jsonData = JsonSerializer.Serialize(f);
            stopwatch.Restart();
            for (int i = 0; i < 100000; i++)
            {
                JsonSerializer.Deserialize<F>(jsonData);
            }
            stopwatch.Stop();
            Console.WriteLine($"JSON deserialization time for object size {size}: {stopwatch.ElapsedMilliseconds} ms");
        }
    }

}