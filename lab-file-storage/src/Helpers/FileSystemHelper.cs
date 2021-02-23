using Lab2_FileStorage.Resources;
using System;
using System.IO;

namespace Lab2_FileStorage.Helpers
{
    public static class FileSystemHelper
    {
        public static void CreateFileIfNotExist(string filename)
        {
            string path = Directory.GetCurrentDirectory();
            string filepathAdd = $@"{path}\{filename}";

            if (!File.Exists(filepathAdd))
            {
                File.Create(filepathAdd).Close();
                Console.WriteLine($"{filepathAdd} had been created");
            }
            else
                Console.WriteLine($"{Resource.SuchFileExists}");
        }

        public static void CreateFolderIfNotExist(string foldername)
        {
            string path = Directory.GetCurrentDirectory();
            string folderAdd = $@"{path}\{foldername}";


            if (!File.Exists(folderAdd))
            {
                Directory.CreateDirectory(folderAdd);
                Console.WriteLine($"{folderAdd} had been created");
            }
        }

        public static void RemoveFileIfExist(string filename, string endPath)
        {
            string path = Directory.GetCurrentDirectory();
            string fileRemove = $@"{path}\{filename}";

            if (File.Exists(fileRemove))
            {
                string folderName = $@"{path}\{endPath}";
                if (Directory.Exists(folderName))
                {
                    string newFileRemove = $@"{folderName}\{filename}";
                    if (!File.Exists(newFileRemove))
                    {
                        File.Move(filename, newFileRemove);
                        Console.WriteLine($"{filename} had been moved to {newFileRemove}");
                    }
                    else
                        Console.WriteLine($"{Resource.SuchFileExists}");
                }
                else
                {
                    Console.WriteLine($"{Resource.WrongDirectory}. Do you want create? (y/n)");
                    string answerToCreate = Console.ReadLine();
                    switch (answerToCreate)
                    {
                        case "y":
                            CreateFolderIfNotExist(endPath);
                            break;
                        case "n":
                            break;

                        default:
                            Console.WriteLine("Repeat answer.");
                            break;
                    }
                }
            }
            else
                Console.WriteLine($"{filename}, {Resource.NoFile}");
        }

        public static void CopyFileIfExist(string filename, string endPath)
        {
            string path = Directory.GetCurrentDirectory();
            string fileRemove = $@"{path}\{filename}";

            if (File.Exists(fileRemove))
            {
                string folderName = $@"{path}\{endPath}";
                if (Directory.Exists(folderName))
                {
                    string newFileRemove = $@"{folderName}\{filename}";
                    if (!File.Exists(newFileRemove))
                    {
                        File.Copy(filename, newFileRemove);
                        Console.WriteLine($"{filename} had been copy to {newFileRemove}");
                    }
                    else
                        Console.WriteLine($"{Resource.SuchFileExists}");
                }
                else
                {
                    Console.WriteLine($"{Resource.WrongDirectory}. Do you want create? (y/n)");
                    string answerToCreate = Console.ReadLine();
                    switch (answerToCreate)
                    {
                        case "y":
                            CreateFolderIfNotExist(endPath);
                            break;
                        case "n":
                            break;

                        default:
                            Console.WriteLine("Repeat answer.");
                            break;
                    }
                }
            }
            else
                Console.WriteLine($"{filename}, {Resource.NoFile}");
        }

        public static void DeleteFileIfExist(string filename)
        {
            string path = Directory.GetCurrentDirectory();
            string filepathDel = $@"{path}\{filename}";

            if (File.Exists(filepathDel))
            {
                File.Delete(filepathDel);
                Console.WriteLine($"{filepathDel} had been deleted");
            }
            else
            {
                Console.WriteLine($"{filename}, {Resource.NoFile}");
            }
        }

        public static void ShowFileInfo(string filename)
        {
            string path = Directory.GetCurrentDirectory();
            string filepathInfo = $@"{path}\{filename}";

            if (File.Exists(filepathInfo))
            {
                var info = new FileInfo(filepathInfo);



                Console.WriteLine($"{filepathInfo}:" + Environment.NewLine +
                                                    $"\t{info.Length} bytes" + Environment.NewLine +
                                                    $"\t{info.CreationTime} ");
            }
            else
            {
                Console.WriteLine($@"{filepathInfo} does not exist");
            }
        }

        public static void ShowDirectoryStructure()
        {
            string rootDir = Directory.GetCurrentDirectory();

            var dir = new DirectoryInfo(rootDir);

            ShowDirectoryEntry(dir);
        }

        private static void ShowDirectoryEntry(DirectoryInfo dir, int level = 0)
        {
            Console.WriteLine($"{new string('\t', level)}{dir.Name}");

            var files = dir.GetFiles();
            foreach (var f in files)
            {
                Console.WriteLine($"{new string(' ', level + 1)}{f.Name}");
            }

            var dirs = dir.GetDirectories();
            foreach (var d in dirs)
            {
                ShowDirectoryEntry(d, ++level);
            }
        }
    }
}
