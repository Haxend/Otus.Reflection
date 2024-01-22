using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using Newtonsoft.Json;

public class F
{
    public int i1, i2, i3, i4, i5;

    public static F Get() => new F() { i1 = 1, i2 = 2, i3 = 3, i4 = 4, i5 = 5 };
}

public class Program
{
    public static void Main()
    {
        Stopwatch sw = new Stopwatch();
        sw.Start();

        // Serialize
        var obj = F.Get();
        var json = JsonConvert.SerializeObject(obj);
        Console.WriteLine("Serialized JSON: " + json);

        sw.Stop();
        Console.WriteLine("Serialization time: " + sw.Elapsed);

        sw.Reset();
        sw.Start();

        // Deserialize
        var objDeserialized = JsonConvert.DeserializeObject<F>(json);
        Console.WriteLine("Deserialized object: " + objDeserialized);

        sw.Stop();
        Console.WriteLine("Deserialization time: " + sw.Elapsed);
    }
}