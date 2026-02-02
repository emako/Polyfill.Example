using Windows.Storage;
using Windows.System;

namespace Polyfill.Example.WindowsLauncher;

internal sealed class Program
{
    private static void Main()
    {
        // Although Windows.System.Launcher was introduced in Windows 8,
        // calling WinRT APIs from desktop apps via Microsoft.Windows.SDK.Contracts
        // is officially supported and stable on Windows 10+ (Build 10240+).
        // On Windows 8/8.1, we fallback to Process.Start for better stability and simpler dependencies.
        Console.WriteLine("Launcher polyfill examples (net48)");

        // For .NET Framework, check OS version. Windows 10 is Major 10.
        if (Environment.OSVersion.Version.Major < 10)
        {
            Console.WriteLine("This example requires Windows 10 or later. Press any key to exit.");
            Console.ReadKey();
            return;
        }

        Task.Run(async () =>
        {
            // Open folder using StorageFolder
            {
                string testFolder = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ".."));

                Console.WriteLine("---");
                Console.WriteLine(testFolder);
                Console.WriteLine("Opening folder...");
                StorageFolder folder = await StorageFolder.GetFolderFromPathAsync(testFolder);
                bool result = await Launcher.LaunchFolderAsync(folder);
                Console.WriteLine($"File launch using StorageFolder result: {result}");
            }

            // Open file using StorageFile
            {
                string testFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "test-storage-file.txt");
                if (!File.Exists(testFile))
                    File.WriteAllText(testFile, "This is a test file for Polyfill.Launcher using StorageFile.");

                Console.WriteLine("---");
                Console.WriteLine(testFile);
                Console.WriteLine("Opening file...");
                StorageFile file = await StorageFile.GetFileFromPathAsync(testFile);
                bool result = await Launcher.LaunchFileAsync(file);
                Console.WriteLine($"File launch using StorageFile result: {result}");
            }

            // Open folder using Uri
            {
                string testFolder = AppDomain.CurrentDomain.BaseDirectory;

                Console.WriteLine("---");
                Console.WriteLine(testFolder);
                Console.WriteLine("Opening folder...");

                bool result = await Launcher.LaunchUriAsync(new Uri($"file://{testFolder}"));
                Console.WriteLine($"Folder launch using Uri result: {result}");
            }

            // Open file using Uri
            {
                string testFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "test-uri.txt");
                if (!File.Exists(testFile))
                    File.WriteAllText(testFile, "This is a test file for Polyfill.Launcher using Uri.");

                Console.WriteLine("---");
                Console.WriteLine(testFile);
                Console.WriteLine("Opening file...");
                bool result = await Launcher.LaunchUriAsync(new Uri($"file://{testFile}"));
                Console.WriteLine($"File launch using Uri result: {result}");
            }

            // Open uri
            {
                Console.WriteLine("---");
                Console.WriteLine("https://www.microsoft.com");
                Console.WriteLine("Opening URI...");
                bool result = await Launcher.LaunchUriAsync(new Uri("https://www.microsoft.com"));
                Console.WriteLine($"URI launch result: {result}");
            }
        }).GetAwaiter().GetResult();
    }
}
