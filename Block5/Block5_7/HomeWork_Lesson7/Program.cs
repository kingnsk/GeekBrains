using System;
using System.IO;

namespace HomeWork_Lesson7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DriveInfo[] allDrives = DriveInfo.GetDrives();
            byte currentDrive = 0;
            FileSystemInfo fileSystemInfo = new FileSystemInfo();

            foreach (DriveInfo d in allDrives)
            {
                fileSystemInfo.DiskIndex = currentDrive;
                fileSystemInfo.DiskName = d.Name;
                fileSystemInfo.DriveFormat = d.DriveFormat;
                fileSystemInfo.DriveType = d.DriveType.ToString();
                fileSystemInfo.IsReady = d.IsReady;
                fileSystemInfo.RootDirectory = d.RootDirectory.ToString();
                fileSystemInfo.VolumeLabel = d.VolumeLabel.ToString();
                fileSystemInfo.AvailableFreeSpace = d.AvailableFreeSpace;
                fileSystemInfo.FreeSpace = d.TotalFreeSpace.ToString();
                fileSystemInfo.CurrentDiskSize = d.TotalSize;
                currentDrive++;

                //Console.WriteLine(currentDrive.ToString());
                //Console.WriteLine(fileSystemInfo.DiskName);
                //Console.WriteLine(fileSystemInfo.DriveFormat);
                //Console.WriteLine(fileSystemInfo.DriveType);
                //Console.WriteLine(fileSystemInfo.IsReady);
                //Console.WriteLine(fileSystemInfo.RootDirectory);
                //Console.WriteLine(fileSystemInfo.VolumeLabel);
                //Console.WriteLine(fileSystemInfo.AvailableFreeSpace);
                //Console.WriteLine(fileSystemInfo.CurrentDiskSize);
                //Console.WriteLine(fileSystemInfo.FreeSpace);

                ReportService reportService = new ReportService();
                reportService.GenerateReport(fileSystemInfo);
            }


        }
    }
}
