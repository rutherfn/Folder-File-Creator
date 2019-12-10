using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FolderFileCreator
{
    class FileCreator
    {
        String fileName = "";
        String topLevelFolderName = "";
        String tryAgain = "";
        bool directoryExist;
        public void createNewFileWhenNewFolderCreated(String pathString)
        {
            Console.Clear();
            Console.WriteLine("Please give me the file name, along with the extension you want to save this file under!");
            fileName = Console.ReadLine();

            pathString = System.IO.Path.Combine(pathString, fileName);
            createActualFile(pathString, fileName);
        }
        public void createAFileInsideAFolder()
        {
            Console.Clear();
            do
            {
                Console.WriteLine("\t\nPlease give me the full path of a existing folder location.");
                topLevelFolderName = Console.ReadLine();
                if (Directory.Exists(topLevelFolderName))
                {
                    directoryExist = true;
                    tryAgain = "1";
                    createNewFileWhenNewFolderCreated(topLevelFolderName);
                }
                else
                {
                    Console.WriteLine("\t\nDirectory does not exist will you like to try again?\t\n1:Yes\t\n2:No");
                    tryAgain = Console.ReadLine();
                    if (tryAgain == "2")
                    {
                        directoryExist = true;
                    }
                }
            } while (directoryExist == false);
        }
        private void createActualFile(String pathString, String fileName)
        {
            if (!System.IO.File.Exists(pathString))
            {
                using (System.IO.FileStream fs = System.IO.File.Create(pathString))
                {
                    for (byte i = 0; i < 100; i++)
                    {
                        fs.WriteByte(i);
                    }
                }
            }
            else
            {
                Console.WriteLine("File \"{0}\" already exists.", fileName);
                return;
            }
        }
    }
}

