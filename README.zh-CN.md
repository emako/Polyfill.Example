# Polyfill.Example

本仓库演示了如何为 .NET Framework 4.8 等较老版本的 .NET 环境提供 C# 9.0+ 新特性（如 record、init-only setter、Index/Range 等）所需的 polyfill 支持。

## 目录结构

```
Polyfill.Example.slnx
src/
  Polyfill.Example.IndexRange/    // Index/Range 特性演示
    Program.cs
    ...
  Polyfill.Example.IsExternalInit/ // isExternalInit 特性演示
    Program.cs
    ...
```

## 背景

C# 9.0 引入了 `record` 类型和 `init` 访问器等新特性，但这些特性依赖于 .NET 5+ 的运行时支持。对于 .NET Framework 4.8 等老版本，缺少 `System.Runtime.CompilerServices.IsExternalInit` 类型会导致编译失败。本项目通过自定义类型和相关代码演示如何兼容这些新特性。

## 主要内容

- `Polyfill.Example.IsExternalInit`：演示如何为 .NET Framework 提供 `IsExternalInit` 类型以支持 `init` setter 和 `record`。
- `Polyfill.Example.IndexRange`：演示如何在低版本 .NET 环境下使用 C# 8.0 的 Index/Range 语法。

## 快速开始

### 1. 克隆仓库

```bash
git clone https://github.com/yourname/Polyfill.Example.IsExternalInit.git
cd Polyfill.Example.IsExternalInit
```

### 2. 编译与运行

以 `Polyfill.Example.IsExternalInit` 为例：

```bash
cd src/Polyfill.Example.IsExternalInit
msbuild /p:Configuration=Debug
bin\Debug\net48\Polyfill.Example.IsExternalInit.exe
```

以 `Polyfill.Example.IndexRange` 为例：

```bash
cd src/Polyfill.Example.IndexRange
msbuild /p:Configuration=Debug
bin\Debug\net48\Polyfill.Example.IndexRange.exe
```

## DEMO

### 1. isExternalInit Polyfill 示例

`src/Polyfill.Example.IsExternalInit/Program.cs`：

```csharp
// Polyfill for IsExternalInit (仅在低版本 .NET 环境下需要)
namespace System.Runtime.CompilerServices
{
    public class IsExternalInit { }
}

public record Person(string Name) { public int Age { get; init; } }

class Program
{
    static void Main()
    {
        var p = new Person("张三") { Age = 18 };
        Console.WriteLine($"{p.Name}, {p.Age}");
    }
}
```

输出：
```
张三, 18
```

### 2. Index/Range Polyfill 示例

`src/Polyfill.Example.IndexRange/Program.cs`：

```csharp
class Program
{
    static void Main()
    {
        int[] arr = { 1, 2, 3, 4, 5 };
        // 使用 Index/Range 语法
        int last = arr[^1]; // 5
        int[] sub = arr[1..^1]; // {2,3,4}
        Console.WriteLine(last);
        Console.WriteLine(string.Join(",", sub));
    }
}
```

输出：
```
5
2,3,4
```

## 参考
- [C# 9.0 新特性](https://docs.microsoft.com/zh-cn/dotnet/csharp/whats-new/csharp-9)
- [Index 和 Range](https://docs.microsoft.com/zh-cn/dotnet/csharp/language-reference/proposals/csharp-8.0/ranges)

## License

[MIT](LICENSE)
