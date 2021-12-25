using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_13
{
	class MKVDirInfo
	{
        /* 4. Методы для вывода информации о конкретном директории:
			a. Количестве файлов
			b. Время создания
			c. Количестве поддиректориев
			d. Список родительских директориев */

        public static void FileCount(string path)
        {
            Console.WriteLine($"Количество файлов в каталоге {path}: {Directory.GetFiles(path).Length}");
            Console.WriteLine();

            MKVLog.AddNote("MKVDirInfo ---> ", path, "Определено количество файлов в каталоге.\n");
        }

        public static void CreationTime(string path)
        {
            Console.WriteLine($"Время создания каталога {path}: {Directory.GetCreationTime(path)}");
            Console.WriteLine();

            MKVLog.AddNote("MKVDirInfo ---> ", path, "Определено время создания каталога.\n");
        }

        public static void SubDirectoryCount(string path)   // количество поддиректориев
        {
            Console.WriteLine($"Количество подкаталогов каталога {path}: {Directory.GetDirectories(path).Length}");
            Console.WriteLine();

            MKVLog.AddNote("MKVDirInfo ---> ", path, "Определено количество подкаталогов каталога.\n");
        }

        public static void ParentDirectory(string path)     // список родительских директориев
        {
            Console.WriteLine($"Родительский путь каталога {path}: {Directory.GetParent(path)}");
            Console.WriteLine();

            MKVLog.AddNote("MKVDirInfo ---> ", path, "Определен родительский путь каталога.\n");
        }
    }
}
