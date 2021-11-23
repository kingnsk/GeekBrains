using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using TemplateEngine.Docx;

namespace HomeWork_Lesson7
{
    public sealed class ReportService
    {
        public void GenerateReport(FileSystemInfo fileSystemInfo, string output ="")
        {
            if (fileSystemInfo is null)
            {
                return;
            }

            if (string.IsNullOrWhiteSpace(output))
            {
                output = Path.Combine(Directory.GetCurrentDirectory(), $"Disk{fileSystemInfo.DiskIndex.ToString()}_FileSystemReport.docx");
            }

            if (File.Exists(output))
            {
                File.Delete(output);
            }

            //File.Copy("C:\\Templates\\FileSystemInfoTemplate.docx", output);
            File.Copy("..\\..\\..\\Templates\\FileSystemInfoTemplate.docx", output);

            var valuesToFill = new Content(
                new FieldContent("Disk Index", fileSystemInfo.DiskIndex.ToString()),
                new FieldContent("Disk Name",  fileSystemInfo.DiskName),
                new FieldContent("Drive Format", fileSystemInfo.DriveFormat),
                new FieldContent("Drive Type", fileSystemInfo.DriveType),
                new FieldContent("IsReady", fileSystemInfo.IsReady.ToString()),
                new FieldContent("Root Directory", fileSystemInfo.RootDirectory),
                new FieldContent("Volume Label", fileSystemInfo.VolumeLabel),
                new FieldContent("Disk Size", fileSystemInfo.CurrentDiskSize.ToString()),
                new FieldContent("Free bytes", fileSystemInfo.AvailableFreeSpace.ToString())
                );

            using (var outputDocument =
                new TemplateProcessor(output)
                .SetRemoveContentControls(true))
                
            {
                outputDocument.FillContent(valuesToFill);
                outputDocument.SaveChanges();
            }

        }

    }
}
