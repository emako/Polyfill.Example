using WindowsAPICodePack.Dialogs;

namespace Polyfill.Example.CommonFileDialogs;

internal sealed class Program
{
    [STAThread]
    private static void Main()
    {
        Console.WriteLine("CommonFileDialogs polyfill examples (net48)");

        using CommonOpenFileDialog dialog = new()
        {
            IsFolderPicker = true,
        };

        if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
        {
            Console.WriteLine($"Result: {dialog.FileName}");
        }
    }
}
