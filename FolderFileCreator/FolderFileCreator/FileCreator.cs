using System;
using System.Collections.Generic;
using System.Text;

namespace FolderFileCreator
{
    class FileCreator
    {
        String fileName = "";
        String topLevelFolderName = "";
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
            Console.WriteLine("\t\nPlease give me the full path of your new parent folder location.");
            topLevelFolderName = Console.ReadLine();
            createNewFileWhenNewFolderCreated(topLevelFolderName);
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

            // Read and display the data from your file.
            //    try
            //   {
            //      byte[] readBuffer = System.IO.File.ReadAllBytes(pathString);
            //      foreach (byte b in readBuffer)
            //     {
            //        Console.Write(b + " ");
            //   }
            //  Console.WriteLine();
            // }
            //  catch (System.IO.IOException e)
            //  {
            //     Console.WriteLine(e.Message);
            // }
            //}
        }
    }
}

