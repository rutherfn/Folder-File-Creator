using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Collections;

namespace FolderFileCreator
{
    class FolderCreator
    {
        bool directoryExist = false;
        string topLevelFolderName = "";
        string userCreateFolderChoice = "";
        string tryAgain = "";
        public void createFolder()
        {
            Console.Clear();
            Console.WriteLine("Currently your folder location is " + "\t\n" +  System.AppDomain.CurrentDomain.BaseDirectory + " \t\nWould you like to change that?\t\nPlease enter yes or no");
            userCreateFolderChoice = Console.ReadLine();
            if(userCreateFolderChoice == "yes" || userCreateFolderChoice == "Yes")
            {
                changeFolderCurrentLocation();
                if (tryAgain == "1")
                {
                    createFolderUnderTopLevel();
                }
            }
            else
            {
                topLevelFolderName = System.AppDomain.CurrentDomain.BaseDirectory;
                createFolderUnderTopLevel();
            }
        }
        private void changeFolderCurrentLocation()
        {
            do
            {
                Console.WriteLine("\t\nPlease give me the full path of your new parent folder location.");
                topLevelFolderName = Console.ReadLine();
                if (Directory.Exists(topLevelFolderName))
                {
                    directoryExist = true;
                    tryAgain = "1";
                }
                else
                {
                    Console.WriteLine("\t\nDirectory does not exist will you like to try again?\t\n1:Yes\t\n2:No");
                    tryAgain = Console.ReadLine();
                    if(tryAgain == "2")
                    {
                        directoryExist = true;
                    }
                }
            } while (directoryExist == false);
            // check to see if folder exists
        }
        private void createFolderUnderTopLevel()
        {
            String subFolder = "";
            Console.WriteLine("\t\nPlease enter name of sub folder: ");
            subFolder = Console.ReadLine();

            // To create a string that specifies the path to a subfolder under your 
            // top-level folder, add a name for the subfolder to folderName.
            string pathString = System.IO.Path.Combine(topLevelFolderName, subFolder);

            System.IO.Directory.CreateDirectory(pathString);
        }
    }
}
