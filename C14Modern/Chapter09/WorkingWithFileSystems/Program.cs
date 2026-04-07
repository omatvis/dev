using Spectre.Console;

partial class Program
{
    static void Main(string[] args)
    {
        #region Handling cross-platform environments and filesystems
        SectionTitle("Handling cross-platform environments and filesystems");

        // Create a Spectre Console table.
        Table table = new();

        // Add two columns with markup for colors.
        table.AddColumn("[blue]MEMBER[/]");
        table.AddColumn("[blue]VALUE[/]");

        // Add rows.
        table.AddRow(
            "Path.PathSeparator",
            System.IO.Path.PathSeparator.ToString());

        table.AddRow(
            "Path.DirectorySeparatorChar",
            System.IO.Path.DirectorySeparatorChar.ToString());

        table.AddRow(
            "Directory.GetCurrentDirectory()",
            System.IO.Directory.GetCurrentDirectory());

        table.AddRow(
            "Environment.CurrentDirectory",
            System.Environment.CurrentDirectory);

        table.AddRow(
            "Environment.SystemDirectory",
            System.Environment.SystemDirectory);

        table.AddRow(
            "Path.GetTempPath()",
            System.IO.Path.GetTempPath());

        table.AddRow(string.Empty);

        table.AddRow(
            "GetFolderPath(SpecialFolder",
            string.Empty);

        table.AddRow(
            "  .System)",
            System.Environment.GetFolderPath(System.Environment.SpecialFolder.System));

        table.AddRow(
            "  .ApplicationData)",
            System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData));

        table.AddRow(
            "  .MyDocuments)",
            System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments));

        table.AddRow(
            "  .Personal)",
            System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal));

        // Render the table to the console.
        AnsiConsole.Write(table);
        #endregion

        #region Managing drives
        SectionTitle("Managing drives");

        Table drives = new();
        drives.AddColumn("[blue]NAME[/]");
        drives.AddColumn("[blue]TYPE[/]");
        drives.AddColumn("[blue]FORMAT[/]");
        drives.AddColumn(new TableColumn("[blue]SIZE (BYTES)[/]").RightAligned());
        drives.AddColumn(new TableColumn("[blue]FREE SPACE[/]").RightAligned());

        foreach (System.IO.DriveInfo drive in System.IO.DriveInfo.GetDrives())
        {
            if (drive.IsReady)
            {
                drives.AddRow(
                    drive.Name,
                    drive.DriveType.ToString(),
                    drive.DriveFormat,
                    drive.TotalSize.ToString("N0"),
                    drive.AvailableFreeSpace.ToString("N0"));
            }
            else
            {
                drives.AddRow(
                    drive.Name,
                    drive.DriveType.ToString(),
                    string.Empty,
                    string.Empty,
                    string.Empty);
            }
        }

        AnsiConsole.Write(drives);

        #endregion

        #region managing directories
        SectionTitle("Managing directories");

        string newFolder = System.IO.Path.Combine(
            System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal),
            "NewFolder");

        WriteLine($"Working with: {newFolder}");

        // We must explicitly say which Exists method to use
        // because we statically imported both Path and Directory.
        WriteLine($"Does it exist? {System.IO.Path.Exists(newFolder)}");

        WriteLine("Creating it...");
        System.IO.Directory.CreateDirectory(newFolder);

        // Let's use the Directory.Exists method this time.
        WriteLine($"Does it exist? {System.IO.Directory.Exists(newFolder)}");

        Write("Confirm the directory exists, and then press any key.");
        ReadKey(intercept: true);

        WriteLine("Deleting it...");
        if (!IsCurrentDirectoryInside(newFolder)) {
            ClearReadOnlyAttributesRecursively(newFolder);
            System.IO.Directory.Delete(newFolder, recursive: true);
        }
        

        WriteLine($"Does it exist? {System.IO.Path.Exists(newFolder)}");
        #endregion

        #region Managing files
        SectionTitle("Managing files");

        // Define a directory path to output files starting
        // in the user's folder.
        string dir = System.IO.Path.Combine(
            System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal),
            "OutputFiles");

        System.IO.Directory.CreateDirectory(dir);

        // Define file paths.
        string textFile = System.IO.Path.Combine(dir, "Dummy.txt");
        string backupFile = System.IO.Path.Combine(dir, "Dummy.bak");

        WriteLine($"Working with: {textFile}");
        WriteLine($"Does it exist? {System.IO.File.Exists(textFile)}");
        // Create a new text file and write a line to it.
        StreamWriter textWriter = System.IO.File.CreateText(textFile);
        textWriter.WriteLine("Hello, C#!");
        textWriter.Close(); // Close file and release resources.

        WriteLine($"Does it exist? {System.IO.File.Exists(textFile)}");
        // Copy the file, and overwrite if it already exists.
        System.IO.File.Copy(
            sourceFileName: textFile,
            destFileName: backupFile,
            overwrite: true);

        WriteLine($"Does {backupFile} exist? {File.Exists(backupFile)}");
        Write("Confirm the files exist, and then press any key.");
        ReadKey(intercept: true);

        // Delete the file.
        File.Delete(textFile);
        WriteLine($"Does it exist? {File.Exists(textFile)}");

        // Read from the text file backup.
        WriteLine($"Reading contents of {backupFile}:");
        StreamReader textReader = File.OpenText(backupFile);
        WriteLine(textReader.ReadToEnd());
        textReader.Close();
        #endregion


        #region Managing paths
        SectionTitle("Managing paths");
        WriteLine($"Folder Name: {System.IO.Path.GetDirectoryName(textFile)}");
        WriteLine($"File Name: {System.IO.Path.GetFileName(textFile)}");
        WriteLine("File Name without Extension: {0}",
          System.IO.Path.GetFileNameWithoutExtension(textFile));
        WriteLine($"File Extension: {System.IO.Path.GetExtension(textFile)}");
        WriteLine($"Random File Name: {System.IO.Path.GetRandomFileName()}");
        WriteLine($"Temporary File Name: {System.IO.Path.GetTempFileName()}");
        #endregion

        #region Getting file and directory information
        SectionTitle("Getting file information");
        System.IO.FileInfo info = new(backupFile);
        WriteLine($"{backupFile}:");
        WriteLine($"  Contains {info.Length} bytes.");
        WriteLine($"  Last accessed: {info.LastAccessTime}");
        WriteLine($"  Has readonly set to {info.IsReadOnly}.");
        #endregion
    }

 
}
