using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MenuSMPTUserConsoleApp
{
    class CRUD
    {
        #region declared variables
        public string host = "ftp://82.214.114.2";
        public string userId = "bojan_academy";
        public string password = "qjeK7#88";
        public string path = "/HomeWork/";
        public string fileToUpload = "MyFile.txt";
        public string fileToDelete = "/HomeWork/HristijanFolder/";
        public string folderPath = "/HomeWork/HristijanFolder/";
        public string filePath = "/HomeWork/HristijanFolder/";
        public string deleteFile = "/HomeWork";
        #endregion
        #region CRUD methods
        public void FolderCreating()
        {
            //creating folder in server
            #region creating folder
            Console.WriteLine("[1]Do you want to create a folder?-Please enter Y or N ");
            var user1 = Convert.ToString(Console.ReadLine());
            while (user1 == string.Empty)
            {
                Console.WriteLine("[1]Do you want to create a folder?-Please enter Y or N ");
                user1 = Convert.ToString(Console.ReadLine());
            }
            if (user1 != "Y" && user1 != "y")
            {
                Console.WriteLine("Thank you for your time");
            }
            else
            {
                FTPBackup ftpBackup = new FTPBackup();
                ftpBackup.CreateFtpFolder();
            }
            #endregion
            //deleting folder 
            #region delete folder
            Console.WriteLine("[2]Do you want to delete a folder?-Please enter Y or N  ");
            var user2 = Convert.ToString(Console.ReadLine());
            while(user2 == string.Empty)
            {
                Console.WriteLine("[2]Do you want to delete a folder?-Please enter Y or N  ");
                 user2 = Convert.ToString(Console.ReadLine());
            }
            if (user2 == "Y" && user2 == "y")
            {
                Console.WriteLine("Thank you for your time!");
            }
            else
            {
                Console.WriteLine("\t Deleting folders...");
                FTPBackup ftpBackup = new FTPBackup();
                ftpBackup.DeleteFtpFolder();
                Console.WriteLine("\t Folder succesfully deleted!");
            }
            #endregion
            //uploading file in server
            #region upload file
            Console.WriteLine("[3]Do you want to upload a file into folder?-Please enter Y or N ");
            var user3 = Convert.ToString(Console.ReadLine());
            while(user3 == string.Empty)
            {
                Console.WriteLine("[3]Do you want to upload a file into folder?-Please enter Y or N ");
                user3 = Convert.ToString(Console.ReadLine());
            }
                if (user3 != "Y" && user3 != "y")
                {
                    Console.WriteLine("Thank you for your time!");
                }
                else
                {
                    FTPBackup ftpBackup = new FTPBackup();
                    ftpBackup.CreateFtpFolder();
                    ftpBackup.FileToUpload();
                    Console.WriteLine("\t File was succesfully uploaded !");
                }
            #endregion
            //check if directory ecists
            #region check does file exists
            Console.WriteLine("[4]Do you want to check if directory exists on a Server?▬Please enter Y or N ");
            var user4 = Console.ReadLine();
            while(user4 == string.Empty)
            {
                Console.WriteLine("[4]Do you want to check if directory exists on a Server?▬Please enter Y or N ");
                user4 = Console.ReadLine();
            }
            if (user4 != "Y" && user4 != "y")
            {
                Console.WriteLine("Thank you for your time");
            }
            else
            {
                Console.WriteLine("\t Cheking does folder exists...");
                FTPBackup ftpBackup = new FTPBackup();
                ftpBackup.DoesFtpDirectoryExist(host, userId, password);
                Console.WriteLine("\t Folder already exists!");
                Console.WriteLine("Enter any key to back to the Menu!");
                Console.ReadLine();
                Console.Clear();
            }
            #endregion
        }
        #endregion
    }
}
