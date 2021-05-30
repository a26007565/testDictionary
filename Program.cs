using System;
using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using RandomNameGenerator;

namespace testDictionary
{
    [RPlotExporter, RankColumn]
    public class DictionaryBenchmarks{
        private  IDictionary<string, string> dict = new Dictionary<string, string>();
        private  IDictionary<string, string> IgnoreCaseDict;

        private  IEnumerable<string> keys;

        [Params(10, 100, 1000)]
        public int N;
        
        [GlobalSetup]
        public void Setup()
        {
            for(var i = 0; i < N; i++){
                string key = NameGenerator.GenerateFirstName(Gender.Male).ToUpper();
                if(!dict.ContainsKey(key)){
                    dict.Add(key, NameGenerator.GenerateLastName());
                }
            }
            IgnoreCaseDict = dict.ToDictionary(
                x => x.Key,
                x => x.Value,
                StringComparer.OrdinalIgnoreCase);
            keys = RandomValues(dict)
                .Take(Math.Min(N, dict.Count)/2)
                .Select(x => x.ToLower());
        }

        [Benchmark]
        public bool GetWithDictionary() => keys.All(x => dict.TryGetValue(x.ToUpper(), out _));

        [Benchmark]
        public void GetWithDictionaryForLoop() { 
            foreach (var key in keys){
                dict.TryGetValue(key.ToUpper(), out _);
            }
        }

        [Benchmark]
        public bool GetWithIgnoreCaseDictionary() => keys.All(x => IgnoreCaseDict.TryGetValue(x, out _));

        [Benchmark]
        public void GetWithIgnoreCaseDictionaryForLoop() { 
            foreach (var key in keys){
                IgnoreCaseDict.TryGetValue(key, out _);
            };
        }

        public IEnumerable<TValue> RandomValues<TKey, TValue>(IDictionary<TKey, TValue> dict)
        {
            var rand = new Random();
            var values = Enumerable.ToList(dict.Values);
            var size = dict.Count;
            while(true)
            {
                yield return values[rand.Next(size)];
            }
        }
    }

    class Program
    {
        static void Main (string[] args) {
            var summary = BenchmarkRunner.Run<DictionaryBenchmarks> ();
        }
    }
}
