using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Collections;

namespace FolderFileCreator
{
    class RemoveFolder
    {
        string folderWishingToRemove = "";
        public void remove()
        {
                removeFolder();
        }
      
        private void inputingFoldingWishingToRemove()
        {
            Console.WriteLine("Please enter the folder name you wish to remove ");
            folderWishingToRemove = Console.ReadLine();
        }
    
       
        private void setAttributesNormal(DirectoryInfo dir)
        {
            foreach (var subDir in dir.GetDirectories())
            {
                setAttributesNormal(subDir);
                subDir.Attributes = FileAttributes.Normal;
            }
            foreach (var file in dir.GetFiles())
            {
                file.Attributes = FileAttributes.Normal;
            }
        }
        private void removeFolder()
        {
            string removeAnotherOne = "";
            string directoryNotValidTryAgain = "";
            Console.Clear();
            inputingFoldingWishingToRemove();
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(folderWishingToRemove);
            if (dir.Exists)
            {
                setAttributesNormal(dir);
                dir.Delete(true);
                Console.Clear();
                Console.WriteLine("Directory Removed!");
                Console.WriteLine("Would you like to remove another one?\t\n1: Yes\t\n2: No");
                removeAnotherOne = Console.ReadLine();
                if(removeAnotherOne == "1")
                {
                    removeFolder();
                }
            }
            else
            {
                Console.WriteLine("Seems like directory is not valid, would you like to try again?\t\n1: Yes\t\n2: No");
                directoryNotValidTryAgain = Console.ReadLine();
                if(directoryNotValidTryAgain == "1")
                {
                    removeFolder();
                }
            }
        }
    }
}
