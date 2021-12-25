using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_13
{
	class MKVFileManager
	{
        /* 5. С его помощью выполнить следующие действия:
			a. Прочитать список файлов и папок заданного диска. Создать директорий XXXInspect, создать текстовый файл xxxdirinfo.txt и сохранить туда информацию. 
			Создать копию файла и переименовать его. Удалить первоначальный файл.

			b. Создать еще один директорий XXXFiles. Скопировать в него все файлы с заданным расширением из заданного пользователем директория. Переместить XXXFiles в XXXInspect.

			c. Сделайте архив из файлов директория XXXFiles. Разархивируйте его в другой директорий. */

        public static void InspectDirectoty(string path)
        {
            DirectoryInfo directory = new DirectoryInfo(path);
            File.Create(@"E:\БГТУ (Теория, лабы, подготовка к экзам)\2 курс\1 семестр\ООП\Лабораторные\Лабораторная №13\Lab_13\Lab_13\MKVInspect\MKVDirInfo.txt").Close();

            using (StreamWriter sw = new StreamWriter(@"E:\БГТУ (Теория, лабы, подготовка к экзам)\2 курс\1 семестр\ООП\Лабораторные\Лабораторная №13\Lab_13\Lab_13\MKVInspect\MKVDirInfo.txt"))
            {
                sw.WriteLine("\t\t\t| Директории |");
                foreach (DirectoryInfo dir in directory.GetDirectories())
                    sw.WriteLine(dir.Name);

                sw.WriteLine("-------------------------------------------------------------------------");

                sw.WriteLine("\t\t\t| Файлы |");
                foreach (FileInfo file in directory.GetFiles())
                    sw.WriteLine(file.Name);
            }

            File.Copy(@"E:\БГТУ (Теория, лабы, подготовка к экзам)\2 курс\1 семестр\ООП\Лабораторные\Лабораторная №13\Lab_13\Lab_13\MKVInspect\MKVDirInfo.txt", @"E:\БГТУ (Теория, лабы, подготовка к экзам)\2 курс\1 семестр\ООП\Лабораторные\Лабораторная №13\Lab_13\Lab_13\MKVInspect\MKVDirInfoRenamed.txt", true);
            File.Delete(@"E:\БГТУ (Теория, лабы, подготовка к экзам)\2 курс\1 семестр\ООП\Лабораторные\Лабораторная №13\Lab_13\Lab_13\MKVInspect\MKVDirInfo.txt");
        }


        public static void CopyFiles(string path, string extension)
        {
            DirectoryInfo directory = new DirectoryInfo(path);
            Directory.CreateDirectory(@"E:\БГТУ (Теория, лабы, подготовка к экзам)\2 курс\1 семестр\ООП\Лабораторные\Лабораторная №13\Lab_13\Lab_13\MKVFiles");

            foreach (FileInfo file in directory.GetFiles())
            {
                if (file.Extension == extension)
                    file.CopyTo($@"E:\БГТУ (Теория, лабы, подготовка к экзам)\2 курс\1 семестр\ООП\Лабораторные\Лабораторная №13\Lab_13\Lab_13\MKVFiles\{file.Name}", true);
            }

            Directory.Delete(@"E:\БГТУ (Теория, лабы, подготовка к экзам)\2 курс\1 семестр\ООП\Лабораторные\Лабораторная №13\Lab_13\Lab_13\MKVInspect\MKVFiles\", true);
            Directory.Move(@"E:\БГТУ (Теория, лабы, подготовка к экзам)\2 курс\1 семестр\ООП\Лабораторные\Лабораторная №13\Lab_13\Lab_13\MKVFiles\", @"E:\БГТУ (Теория, лабы, подготовка к экзам)\2 курс\1 семестр\ООП\Лабораторные\Лабораторная №13\Lab_13\Lab_13\MKVInspect\MKVFiles\");
        }


        public static void Archive(string pathFrom, string pathTo)
        {
            if (!File.Exists($@"{pathFrom}.zip"))
                ZipFile.CreateFromDirectory(pathFrom, $@"{pathFrom}.zip");

            ZipFile.ExtractToDirectory($@"{pathFrom}.zip", pathTo, true);
        }
    }
}
