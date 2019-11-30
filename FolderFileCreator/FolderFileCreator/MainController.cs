using System;
using System.Collections.Generic;
using System.Text;

namespace FolderFileCreator
{
    class MainController
    {
        public void controlProgram()
        {
            string userChoice = "1";
            do
            {
                Console.WriteLine("Welcome to Folder FIle Creator!\t\nThis is a script that allows you to create a new folder, with a file inside!");
                Console.WriteLine("\t\nSo what would you like to do?\t\n1: Create A Folder\t\n2: Create A File\t\n3: Delete A Folder Or File.\t\n4: Leave Program!");
                userChoice = Console.ReadLine();
                if (userChoice == "1")
                {
                    FolderCreator folderCreator = new FolderCreator();
                    folderCreator.createFolder();
                }else if(userChoice == "2")
                {

                }else if(userChoice == "3")
                {

                }
            } while (userChoice != "4");
        }
    }
}
