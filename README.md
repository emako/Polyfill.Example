[简体中文](README.zh-CN.md)

# Polyfill.Example

This repository demonstrates how to provide polyfill support for C# 9.0+ features (such as record, init-only setter, Index/Range, etc.) in legacy .NET environments like .NET Framework 4.8.

## Directory Structure

```
Polyfill.Example.slnx
src/
    Polyfill.Example.IndexRange/        // Index/Range feature demo
        Program.cs
        ...
    Polyfill.Example.IsExternalInit/    // isExternalInit feature demo
        Program.cs
        ...
    Polyfill.Example.CommonFileDialogs/ // CommonFileDialogs polyfill demo
        Program.cs
        ...
    Polyfill.Example.WindowsLauncher/   // Windows Launcher polyfill demo
        Program.cs
        ...
```

## Background

C# 9.0 introduces features like `record` types and `init` accessors, but these require .NET 5+ runtime support. In older versions such as .NET Framework 4.8, the lack of `System.Runtime.CompilerServices.IsExternalInit` causes compilation errors. This project demonstrates how to add custom types and code to enable compatibility with these new features.

## Main Content

- `Polyfill.Example.IsExternalInit`: Shows how to provide the `IsExternalInit` type for .NET Framework to support `init` setters and `record`.
- `Polyfill.Example.IndexRange`: Demonstrates using C# 8.0 Index/Range syntax in legacy .NET environments.
- `Polyfill.Example.CommonFileDialogs`: Demonstrates how to use Windows API Code Pack's CommonFileDialogs in legacy .NET (net48) with modern C# syntax.
- `Polyfill.Example.WindowsLauncher`: Shows how to use Windows 10+ Launcher API (WinRT) from .NET Framework apps, with fallback for older Windows.

## Getting Started

### 1. Clone the repository

```bash
git clone https://github.com/yourname/Polyfill.Example.IsExternalInit.git
cd Polyfill.Example.IsExternalInit
```

### 2. Build and Run


For `Polyfill.Example.IsExternalInit`:

```bash
cd src/Polyfill.Example.IsExternalInit
msbuild /p:Configuration=Debug
bin\Debug\net48\Polyfill.Example.IsExternalInit.exe
```

For `Polyfill.Example.IndexRange`:

```bash
cd src/Polyfill.Example.IndexRange
msbuild /p:Configuration=Debug
bin\Debug\net48\Polyfill.Example.IndexRange.exe
```

For `Polyfill.Example.CommonFileDialogs`:

```bash
cd src/Polyfill.Example.CommonFileDialogs
msbuild /p:Configuration=Debug
bin\Debug\net48\Polyfill.Example.CommonFileDialogs.exe
```

For `Polyfill.Example.WindowsLauncher`:

```bash
cd src/Polyfill.Example.WindowsLauncher
msbuild /p:Configuration=Debug
bin\Debug\net48\Polyfill.Example.WindowsLauncher.exe
```

## DEMO

### 1. isExternalInit Polyfill Example

`src/Polyfill.Example.IsExternalInit/Program.cs`:

```csharp
// Polyfill for IsExternalInit (only needed for legacy .NET)
namespace System.Runtime.CompilerServices
{
    public class IsExternalInit { }
}

public record Person(string Name) { public int Age { get; init; } }

class Program
{
    static void Main()
    {
        var p = new Person("Zhang San") { Age = 18 };
        Console.WriteLine($"{p.Name}, {p.Age}");
    }
}
```

Output:
```
Zhang San, 18
```

### 2. Index/Range Polyfill Example

`src/Polyfill.Example.IndexRange/Program.cs`:

```csharp
class Program
{
    static void Main()
    {
        int[] arr = { 1, 2, 3, 4, 5 };
        // Use Index/Range syntax
        int last = arr[^1]; // 5
        int[] sub = arr[1..^1]; // {2,3,4}
        Console.WriteLine(last);
        Console.WriteLine(string.Join(",", sub));
    }
}
```

Output:
```
5
2,3,4
```

## Reference
- [What's new in C# 9.0](https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-9)
- [Index and Range](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/proposals/csharp-8.0/ranges)

## License

[MIT](LICENSE)
