using Spectre.Console; // To use Table.

// Handling cross-platform environments and filesystems
#region Handling cross-platform environments and filesystems
SectionTitle("Handling cross-platform environments and filesystems");
// Create a Spectre Console table.
Table table = new()
{
    Border = TableBorder.Double
};
table.BorderColor(new(128,0,0));
// Add two columns with markup for colors.
table.AddColumn("[green]MEMBER[/]");
table.AddColumn("[green]VALUE[/]");
// Add rows
table.AddRow("Path.PathSeparator", PathSeparator.ToString());
table.AddRow("Path.DirectorySeparatorChar", DirectorySeparatorChar.ToString());
table.AddRow("Directory.GetCurrentDirectory()", GetCurrentDirectory());
table.AddRow("Environment.CurrentDirectory", CurrentDirectory);
table.AddRow("Environment.SystemDirectory", SystemDirectory);
table.AddRow("Path.GetTempPath()", GetTempPath());
table.AddRow("");
table.AddRow("GetFolderPath(SpecialFolder", "");
table.AddRow("  .System)", GetFolderPath(SpecialFolder.System));
table.AddRow("  .ApplicationData)", GetFolderPath(SpecialFolder.ApplicationData));
table.AddRow("  .MyDocuments)", GetFolderPath(SpecialFolder.MyDocuments));
table.AddRow("  .Personal)", GetFolderPath(SpecialFolder.Personal));
// Render the table to the console.
AnsiConsole.Write(table);
WriteLine();
#endregion Handling cross-platform environments and filesystems

// Managing drives
#region Managing drives
SectionTitle("Managing drives");
Table drives = new()
{
    Border = TableBorder.Double
};
drives.BorderColor(new(128,0,0));
drives.AddColumn("[green]NAME[/]");
drives.AddColumn("[green]TYPE[/]");
drives.AddColumn("[green]FORMAT[/]");
drives.AddColumn(new TableColumn("[green]SIZE (BYTES)[/]").RightAligned());
drives.AddColumn(new TableColumn("[green]FREE SPACE[/]").RightAligned());
foreach (DriveInfo drive in DriveInfo.GetDrives())
{
    if (drive.IsReady) { drives.AddRow(drive.Name, drive.DriveType.ToString(), drive.DriveFormat, drive.TotalSize.ToString("N0"), drive.AvailableFreeSpace.ToString()); }
    else { drives.AddRow(drive.Name, drive.DriveType.ToString(), string.Empty, string.Empty, string.Empty); }
}
AnsiConsole.Write(drives);
WriteLine();
#endregion Managing drives

// Managing directories
#region Managing directories
SectionTitle("Managing directories");
string newFolderName = "TestFolder";
string newFolder = Combine(GetFolderPath(SpecialFolder.Personal), newFolderName);
WriteLine($"Working with: {newFolder}");
// We must explicitly say which Exists method to use
// because we statically imported Path and Directory.
WriteLine($"Does it exist? {Path.Exists(newFolder)}");
WriteLine("Creating it...");
CreateDirectory(newFolder);
// Let's use the Directory.Exists method this time.
WriteLine($"Does it exist? {Directory.Exists(newFolder)}");
Write("Confirm the directory exists, and then press any key.");
ReadKey(intercept: true);
WriteLine("Deleting it...");
Delete(newFolder, recursive: true);
WriteLine($"Does it exist {Path.Exists(newFolder)}");
WriteLine();
#endregion Managing directories

// Managing files
#region Managing files
SectionTitle("Managing files");
newFolderName = "OutputFiles";
// Define a directory path to output files starting in the user's folder.
string dir = Combine(GetFolderPath(SpecialFolder.Personal), newFolderName);
CreateDirectory(dir);
// Define file paths.
string textFile = Combine(dir, "Dummy.txt");
string backupFile = Combine(dir, "Dummy.bak");
WriteLine($"Working with: {textFile}");
WriteLine($"Does it exist? {File.Exists(textFile)}");
// Create a new text file and write a line to it.
StreamWriter textWriter = File.CreateText(textFile);
textWriter.WriteLine("Hello, C#!");
textWriter.Close(); // Close file and release resources.
WriteLine($"Does it exist? {File.Exists(textFile)}");
// Copy the file, and overwrite if it already exists.
File.Copy(sourceFileName: textFile, destFileName: backupFile, overwrite: true);
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
WriteLine();
#endregion Managing files

#region Managing paths
SectionTitle("Managing paths");
WriteLine($"Folder Name: {GetDirectoryName(textFile)}");
WriteLine($"File Name: {GetFileName(textFile)}");
WriteLine("File Name without Extension: {0}", GetFileNameWithoutExtension(textFile));
WriteLine($"File Extension: {GetExtension(textFile)}");
WriteLine($"Random File Name: {GetRandomFileName()}");
WriteLine($"Temporary File Name: {GetTempFileName()}");
WriteLine();
#endregion Managing paths

// Getting file information
#region Getting file information
SectionTitle("Getting file information");
FileInfo info = new(backupFile);
WriteLine($"{backupFile}:");
WriteLine($"  Contains {info.Length} bytes.");
WriteLine($"  Last accessed: {info.LastAccessTime}.");
WriteLine($"  Has readonly set to {info.IsReadOnly}.");
WriteLine();
#endregion Getting file information

// Cleanup
File.Delete(backupFile);
Delete(dir, recursive: true);
