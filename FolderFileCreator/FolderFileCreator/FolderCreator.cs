using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Collections;

namespace FolderFileCreator
{
    class FolderCreator
    {
        string pathString = "";
        String subFolder = "";
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
                    createFolderUnderTopLevel(subFolder,pathString);
                    createDirectory(pathString);
                    askUserIfTheyWantToCreateANewFile();
                }
            }
            else
            {
                topLevelFolderName = System.AppDomain.CurrentDomain.BaseDirectory;
                createFolderUnderTopLevel(subFolder,pathString);
                createDirectory(pathString);
                askUserIfTheyWantToCreateANewFile();
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
        public void createFolderUnderTopLevel(String subFolder,String pathString)
        {
            Console.WriteLine("\t\nPlease enter name of sub folder: ");
            subFolder = Console.ReadLine();

            // To create a string that specifies the path to a subfolder under your 
            // top-level folder, add a name for the subfolder to folderName.
            pathString = System.IO.Path.Combine(topLevelFolderName, subFolder);
        }
        private void createDirectory(String pathString)
        {
            System.IO.Directory.CreateDirectory(pathString);
        }
        private void askUserIfTheyWantToCreateANewFile()
        {
            string userChoice = "";
            Console.Clear();
            Console.WriteLine("\t\nCongrats you have now just created a new sub folder called: " + subFolder + "\t\nWould you like to create a new file under this folder?\t\n1: For Yes\t\n2: For No");
            userChoice = Console.ReadLine();
            if(userChoice == "1")
            {
                FileCreator fileCreator = new FileCreator();
                fileCreator.createNewFileWhenNewFolderCreated(pathString);
            }
        }
    }
}
