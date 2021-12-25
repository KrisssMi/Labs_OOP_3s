using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_13
{
	class MKVDiskInfo
	{
        /* 2. Методы для вывода информации о:
            a. свободном месте на диске
            b. файловой системе
            c. для каждого существующего диска - имя, объем, доступный объем, метка тома. */

        public static void FreeSpace(string driveName)
        {
            foreach (DriveInfo drive in DriveInfo.GetDrives())
            {
                if (drive.Name == driveName && drive.IsReady)
                {
                    Console.WriteLine($"Доступный объём на диске {driveName.First()}: {Math.Round(drive.AvailableFreeSpace / Math.Pow(10, 9), 2)}Гб");
                    MKVLog.AddNote("MKVDiskInfo ---> ", drive.Name, "Определено свободное место на диске.\n");
                }
            }
            Console.WriteLine();
        }


        public static void FileSystemInfo(string driveName)
        {
            foreach (DriveInfo drive in DriveInfo.GetDrives())
            {
                if (drive.Name == driveName && drive.IsReady)
                {
                    Console.WriteLine($"Тип файловой системы и формат диска {driveName.First()}: {drive.DriveType}, {drive.DriveFormat}");
                    MKVLog.AddNote("MKVDiskInfo ---> ", drive.Name, $"{drive.DriveFormat}.\n");
                }
            }
            Console.WriteLine();
        }


        public static void DriveFullInfo()
        {
            foreach (DriveInfo drive in DriveInfo.GetDrives())
            {
                if (drive.IsReady)
                {
                    Console.WriteLine($"Имя: {drive.Name}");
                    Console.WriteLine($"Объём: {Math.Round(drive.TotalSize / Math.Pow(10, 9), 2)}Гб");
                    Console.WriteLine($"Доступный объём: {Math.Round(drive.AvailableFreeSpace / Math.Pow(10, 9), 2)}Гб");
                    Console.WriteLine($"Места тома: {drive.VolumeLabel}");
                    Console.WriteLine();

                    MKVLog.AddNote("MKVDiskInfo ---> ", drive.Name, "Выведена информация о диске.\n");
                }
            }
        }
    }
}
