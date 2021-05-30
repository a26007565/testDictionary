# Summary

測試 `N筆` Dictionary 用 `N/2` 去查找`忽略大小` 寫的效能測試

BenchmarkDotNet=v0.13.0, OS=macOS Big Sur 11.4 (20F71) [Darwin 20.5.0]
Intel Core i5-8279U CPU 2.40GHz (Coffee Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK=5.0.202
  [Host]     : .NET 5.0.5 (5.0.521.16609), X64 RyuJIT
  DefaultJob : .NET 5.0.5 (5.0.521.16609), X64 RyuJIT

|                             Method |    N |      Mean |     Error |    StdDev |    Median | Rank |
|----------------------------------- |----- |----------:|----------:|----------:|----------:|-----:|
|                  GetWithDictionary |   10 |  2.101 us | 0.0237 us | 0.0198 us |  2.102 us |    2 |
|           GetWithDictionaryForLoop |   10 |  2.570 us | 0.0351 us | 0.0328 us |  2.566 us |    4 |
|        GetWithIgnoreCaseDictionary |   10 |  2.075 us | 0.0535 us | 0.1420 us |  2.028 us |    1 |
| GetWithIgnoreCaseDictionaryForLoop |   10 |  2.416 us | 0.0286 us | 0.0268 us |  2.428 us |    3 |
|                  GetWithDictionary |  100 |  2.437 us | 0.0464 us | 0.0411 us |  2.434 us |    3 |
|           GetWithDictionaryForLoop |  100 |  8.470 us | 0.0957 us | 0.0895 us |  8.484 us |    8 |
|        GetWithIgnoreCaseDictionary |  100 |  2.384 us | 0.0263 us | 0.0246 us |  2.384 us |    3 |
| GetWithIgnoreCaseDictionaryForLoop |  100 |  6.898 us | 0.0868 us | 0.0725 us |  6.899 us |    7 |
|                  GetWithDictionary | 1000 |  4.236 us | 0.0724 us | 0.0677 us |  4.246 us |    5 |
|           GetWithDictionaryForLoop | 1000 | 40.806 us | 0.2914 us | 0.2584 us | 40.773 us |   10 |
|        GetWithIgnoreCaseDictionary | 1000 |  4.546 us | 0.0795 us | 0.0704 us |  4.550 us |    6 |
| GetWithIgnoreCaseDictionaryForLoop | 1000 | 34.608 us | 0.6920 us | 1.5190 us | 34.706 us |    9 |
