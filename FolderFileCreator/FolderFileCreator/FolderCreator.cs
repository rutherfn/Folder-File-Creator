using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Collections;

namespace FolderFileCreator
{
    class FolderCreator
    {
        bool createNewDirectory;
        string pathString = "";
        bool userChoice;
        string userTryAgainChoice = "";
        string subFolder = "";
        bool directoryExist = false;
        string topLevelFolderName = "";
        string userCreateFolderChoice = "";
        string tryAgain = "";
        public void createFolder()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("\t\nCurrently your folder location is " + "\t\n" + System.AppDomain.CurrentDomain.BaseDirectory + " \t\n\t\nWould you like to change that?\t\n\t\nPlease enter Yes or No");
                userCreateFolderChoice = Console.ReadLine();
                if (userCreateFolderChoice == "yes" || userCreateFolderChoice == "Yes")
                {
                    changeFolderCurrentLocation();
                    if (tryAgain == "1")
                    {
                        createFolderUnderTopLevel();
                        createDirectory();
                        askUserIfTheyWantToCreateANewFile();
                        userChoice = true;
                    }
                }
                else if (userCreateFolderChoice == "no" || userCreateFolderChoice == "No")
                {
                    topLevelFolderName = System.AppDomain.CurrentDomain.BaseDirectory;
                    createFolderUnderTopLevel();
                    createDirectory();
                    askUserIfTheyWantToCreateANewFile();
                    userChoice = true;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Wrong Entry would you like to try again?\t\n\t\nEnter 1 for Yes Or Any Other Chracter For No");

                    userTryAgainChoice = Console.ReadLine();
                    if(userTryAgainChoice == "1")
                    {
                        Console.Clear();
                        userChoice = false;
                    }
                    else
                    {
                        Console.Clear();
                        userChoice = true;
                    }
                }
            } while (userChoice == false);
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
                    if(tryAgain == "1")
                    {
                        directoryExist = false;
                    }
                    else if(tryAgain == "2")
                    {
                        directoryExist = true;
                    }
                    else
                    {
                        Console.WriteLine("Wrong Entry would you like to try again?\t\n\t\nEnter 1 for Yes Or Any Other Chracter For No");

                        userTryAgainChoice = Console.ReadLine();
                        if (userTryAgainChoice == "1")
                        {
                            Console.Clear();
                            directoryExist = false;
                        }
                        else
                        {
                            Console.Clear();
                            directoryExist = true;
                        }
                    }
                }
            } while (directoryExist == false);
            // check to see if folder exists
        }
        public void createFolderUnderTopLevel()
        {
            Console.WriteLine("\t\nPlease enter name of sub folder: ");
            subFolder = Console.ReadLine();

            // To create a string that specifies the path to a subfolder under your 
            // top-level folder, add a name for the subfolder to folderName.
            pathString = System.IO.Path.Combine(topLevelFolderName, subFolder);
        }
        private void createDirectory()
        {
            System.IO.Directory.CreateDirectory(pathString);
        }
        private void askUserIfTheyWantToCreateANewFile()
        {
            do
            {
                string userChoice = "";
                Console.Clear();
                Console.WriteLine("\t\nCongrats you have now just created a new sub folder called: " + subFolder + "\t\nWould you like to create a new file under this folder?\t\n1: For Yes\t\n2: For No");
                userChoice = Console.ReadLine();
                if (userChoice == "1")
                {
                    createNewDirectory = true;
                    FileCreator fileCreator = new FileCreator();
                    fileCreator.createNewFileWhenNewFolderCreated(pathString);
                }
                else if (userChoice == "2")
                {
                    createNewDirectory = true;
                }
                else
                {
                    Console.WriteLine("Wrong Entry would you like to try again?\t\n\t\nEnter 1 for Yes Or Any Other Chracter For No");

                    userTryAgainChoice = Console.ReadLine();
                    if (userTryAgainChoice == "1")
                    {
                        Console.Clear();
                        createNewDirectory = false;
                    }
                    else
                    {
                        Console.Clear();
                        createNewDirectory = true;
                    }
                }
            } while (createNewDirectory == false);
        }
    }
}
