partial class Program
{
    private static void SectionTitle(string title)
    {
        System.Console.WriteLine();
        System.ConsoleColor previousColor = System.Console.ForegroundColor;
        // Use a color that stands out on your system.
        try
        {
            System.Console.ForegroundColor = System.ConsoleColor.DarkYellow;
            System.Console.WriteLine($"*** {title} ***");
        }
        finally
        {
            System.Console.ForegroundColor = previousColor;
        }
    }

    private static bool IsCurrentDirectoryInside(string folder)
    {
        var cwd = Path.GetFullPath(Environment.CurrentDirectory)
            .TrimEnd(Path.DirectorySeparatorChar) + Path.DirectorySeparatorChar;

        var target = Path.GetFullPath(folder)
            .TrimEnd(Path.DirectorySeparatorChar) + Path.DirectorySeparatorChar;

        return cwd.StartsWith(target, StringComparison.OrdinalIgnoreCase);
    }

    // C#
    private static void ClearReadOnlyAttributesRecursively(string path)
    {
        // Clear files' attributes (use EnumerateFiles for lower memory)
        foreach (var file in Directory.EnumerateFiles(path, "*", SearchOption.AllDirectories))
        {
            File.SetAttributes(file, FileAttributes.Normal);
        }

        // Clear directories' attributes (iterate directories after files)
        foreach (var dir in Directory.EnumerateDirectories(path, "*", SearchOption.AllDirectories))
        {
            var attrs = File.GetAttributes(dir);
            if ((attrs & FileAttributes.ReadOnly) != 0)
                File.SetAttributes(dir, attrs & ~FileAttributes.ReadOnly);
        }

        // Finally clear the target folder attribute itself
        var rootAttrs = File.GetAttributes(path);
        if ((rootAttrs & FileAttributes.ReadOnly) != 0)
            File.SetAttributes(path, rootAttrs & ~FileAttributes.ReadOnly);
    }
}

