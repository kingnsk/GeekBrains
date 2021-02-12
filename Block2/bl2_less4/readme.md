Организация поиска строки в массиве из 10к строк:

// * Summary *

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.18363.1316 (1909/November2018Update/19H2)
Intel Core i3-6100U CPU 2.30GHz (Skylake), 1 CPU, 4 logical and 2 physical cores
  [Host]     : .NET Framework 4.8 (4.8.4300.0), X86 LegacyJIT
  DefaultJob : .NET Framework 4.8 (4.8.4300.0), X86 LegacyJIT


|       Method |         Mean |        Error |       StdDev |
|------------- |-------------:|-------------:|-------------:|
| searchString | 42,250.46 ns | 1,792.590 ns | 5,285.493 ns |
|   searchHash |     44.11 ns |     2.238 ns |     6.422 ns |


Значение не найдено:


|       Method |         Mean |        Error |       StdDev |
|------------- |-------------:|-------------:|-------------:|
| searchString | 39,156.31 ns | 1,086.395 ns | 3,186.207 ns |
|   searchHash |     31.32 ns |     1.360 ns |     3.945 ns |