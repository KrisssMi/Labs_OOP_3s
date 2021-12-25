using System;

namespace Lab_13
{
	class Program
	{
		static void Main(string[] args)
		{
            MKVLog.Clear();

            MKVDiskInfo.FreeSpace("C:\\");
            MKVDiskInfo.FileSystemInfo("C:\\");
            MKVDiskInfo.DriveFullInfo();

            MKVFileInfo.FullPath(@"E:\БГТУ (Теория, лабы, подготовка к экзам)\2 курс\1 семестр\ООП\Лабораторные\Лабораторная №13\Lab_13\Lab_13\Log.txt");
            MKVFileInfo.FileInfo(@"E:\БГТУ (Теория, лабы, подготовка к экзам)\2 курс\1 семестр\ООП\Лабораторные\Лабораторная №13\Lab_13\Lab_13\Log.txt");
            MKVFileInfo.FileTiming(@"E:\БГТУ (Теория, лабы, подготовка к экзам)\2 курс\1 семестр\ООП\Лабораторные\Лабораторная №13\Lab_13\Lab_13\Log.txt");

            MKVDirInfo.CreationTime(@"E:\БГТУ (Теория, лабы, подготовка к экзам)\2 курс\1 семестр\ООП\Лабораторные\Лабораторная №13\Lab_13\Lab_13");
            MKVDirInfo.SubDirectoryCount(@"E:\БГТУ (Теория, лабы, подготовка к экзам)\2 курс\1 семестр\ООП\Лабораторные\Лабораторная №13\Lab_13\Lab_13");
            MKVDirInfo.ParentDirectory(@"E:\БГТУ (Теория, лабы, подготовка к экзам)\2 курс\1 семестр\ООП\Лабораторные\Лабораторная №13\Lab_13\Lab_13");

            MKVFileManager.InspectDirectoty(@"E:\БГТУ (Теория, лабы, подготовка к экзам)\2 курс\1 семестр\ООП\Лабораторные\Лабораторная №13\Lab_13\Lab_13");
            MKVFileManager.CopyFiles(@"E:\БГТУ (Теория, лабы, подготовка к экзам)\2 курс\1 семестр\ООП\Лабораторные\Лабораторная №13\Lab_13\Lab_13", ".txt");
            MKVFileManager.Archive(@"E:\БГТУ (Теория, лабы, подготовка к экзам)\2 курс\1 семестр\ООП\Лабораторные\Лабораторная №13\Lab_13\Lab_13\MKVFiles",
                @"E:\БГТУ (Теория, лабы, подготовка к экзам)\2 курс\1 семестр\ООП\Лабораторные\Лабораторная №13\Lab_13\Lab_13\MKVInspect\MKVFiles\");
        }
	}
}
