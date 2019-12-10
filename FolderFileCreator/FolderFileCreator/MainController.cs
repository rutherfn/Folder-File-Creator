using System;
using System.Collections.Generic;
using System.Text;

namespace FolderFileCreator
{
    class MainController
    {
        public void controlProgram()
        {
            Console.Clear();  // intro welcome  and method for do while loop that controls the whole program. 
            Console.WriteLine("Welcome to Folder FIle Creator!\t\nThis is a script that allows you to create a new folder, with a file inside!");
            string userChoice = "1";
            do
            { // ask the user for the choice.
                Console.WriteLine("\t\nSo what would you like to do?\t\n1: Create A Folder\t\n2: Create A File\t\n3: Delete A Folder Or File.\t\n4: Leave Program!");
                userChoice = Console.ReadLine();
                if (userChoice == "1")
                { // if user selects 1, call create folder method
                    FolderCreator folderCreator = new FolderCreator();
                    folderCreator.createFolder();
                }else if(userChoice == "2")
                {
                    FileCreator fileCreator = new FileCreator();
                    fileCreator.createAFileInsideAFolder();
                }else if(userChoice == "3")
                {
                    RemoveFolderOrFile removeFolderOrFile = new RemoveFolderOrFile();
                    removeFolderOrFile.remove();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("\t\nNot a valid entry, please try again:");
                }
            } while (userChoice != "4");
        }
    }
}
