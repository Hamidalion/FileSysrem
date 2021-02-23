using Lab2_FileStorage.Helpers;
using Lab2_FileStorage.Models;
using System;

namespace Lab2_FileStorage
{
    class Program
    {
        static void Main(string[] args)
        {
            string login = "1";
            string password = "1";

            do
            {
                Console.WriteLine("Enter the login");
                string enterLogin = Console.ReadLine();
                Console.WriteLine("Enter the password");
                string enterPassword = Console.ReadLine(); 
            } while (!Login.Auth(login, password));

            if (Login.Auth(login, password))
            {
                User user = new User();
                user.Login = login;
                user.CreationDate = DateTime.Now;

                Console.WriteLine($"Hello {login}");
                Console.WriteLine($"You added at {user.CreationDate.ToString("yyyy-MM-dd")}");
            }
            else
                Console.WriteLine("Wrong login and(or) password");

            do
            {
                Console.WriteLine(new string('-', 38));
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please select command ");
                Console.WriteLine("\t1 - Add file" + Environment.NewLine +
                                  "\t2 - Info file" + Environment.NewLine +
                                  "\t3 - Show directories and files" + Environment.NewLine +
                                  "\t5 - Copy file" + Environment.NewLine +
                                  "\t6 - Move file" + Environment.NewLine +
                                  "\t7 - Create folder" + Environment.NewLine +
                                  "\t8 - Delete file" + Environment.NewLine +
                                  "\t0 - Exit");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(new string('-', 38));

                string enteringValue = Console.ReadLine();

                if (!int.TryParse(enteringValue, out int command))
                {
                    Console.WriteLine("Invalid command");
                    continue;
                }

                switch (command)
                {
                    case 1:
                        Console.WriteLine("Enter filename");
                        string filenameAdd = Console.ReadLine();
                        FileSystemHelper.CreateFileIfNotExist(filenameAdd);
                        continue;

                    case 2:
                        Console.WriteLine("Enter filename");
                        string filenameInfo = Console.ReadLine();
                        FileSystemHelper.ShowFileInfo(filenameInfo);
                        continue;
                    case 3:
                        Console.WriteLine("Directories and files");
                        FileSystemHelper.ShowDirectoryStructure();
                        continue;

                    case 5:
                        Console.WriteLine("Enter filename");
                        string filenameCopy = Console.ReadLine();
                        Console.WriteLine("Enter puth");
                        string endPuthCopy = Console.ReadLine();
                        FileSystemHelper.RemoveFileIfExist(filenameCopy, endPuthCopy);
                        continue;

                    case 6:
                        Console.WriteLine("Enter filename");
                        string filename = Console.ReadLine();
                        Console.WriteLine("Enter puth");
                        string endPuth = Console.ReadLine();
                        FileSystemHelper.RemoveFileIfExist(filename, endPuth);
                        continue;

                    case 7:
                        Console.WriteLine("Enter foldername");
                        string folderAdd = Console.ReadLine();
                        FileSystemHelper.CreateFolderIfNotExist(folderAdd);
                        continue;

                    case 9:
                        Console.WriteLine("Enter filename");
                        string filenameDel = Console.ReadLine();
                        FileSystemHelper.DeleteFileIfExist(filenameDel);
                        continue;

                    case 0:
                        Console.WriteLine("Do you want to exit y/n?");
                        string switch_on = Console.ReadLine();

                        switch (switch_on)
                        {
                            case "y":
                                Environment.Exit(0);
                                break;
                            case "n":
                                continue;
                            default:
                                Console.WriteLine("Repeat answer.");
                                continue;
                        }
                        break;

                    default:
                        Console.WriteLine("Unknown command");
                        continue;
                }
            } while (Login.Auth(login, password));

            Console.ReadLine();
        }


    }
}
