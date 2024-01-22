using BenchmarkDotNet.Attributes;
using OtusCProHomework4.Deserialize;
using OtusCProHomework4.Models;
using OtusCProHomework4.Serialize;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace OtusCProHomework4
{
    public class Benchmark
    {
        private F[] testObjects;
        private CsvSerializer csvSerializer;
        private CsvDeserializer csvDeserializer;

        public Benchmark()
        {
            // Prepare an array of test objects of varying sizes
            testObjects = Enumerable.Range(1, 10).Select(i => F.Get(i)).ToArray();
            csvSerializer = new CsvSerializer();
            csvDeserializer = new CsvDeserializer();
        }

        [Params(0, 1, 2, 3, 4)] // Corresponds to the index of testObjects
        public int ObjectIndex { get; set; }

        private F CurrentObject => testObjects[ObjectIndex];
        private string CurrentCsvData => csvSerializer.Serialize(CurrentObject);

        [Benchmark]
        public void CsvSerialization()
        {
            csvSerializer.Serialize(CurrentObject);
        }

        [Benchmark]
        public void JsonSerialization()
        {
            JsonSerializer.Serialize(CurrentObject);
        }

        [Benchmark]
        public void CsvDeserialization()
        {
            csvDeserializer.Deserialize<F>(CurrentCsvData);
        }

        [Benchmark]
        public void JsonDeserialization()
        {
            JsonSerializer.Deserialize<F>(JsonSerializer.Serialize(CurrentObject));
        }
    }
}
