using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MenuSMPTUserConsoleApp
{
    class FTPBackup
    {
        #region
        public string host = "ftp://82.214.114.2";
        public string path = "/HomeWork/";
        public string fileToUpload = "MyFile.txt";
        public string userId = "bojan_academy";
        public string password = "qjeK7#88";
        public string filePath = "/HomeWork/HristijanFolder/";
        public string deleteFile = "/HomeWork";
        #endregion
        //Create ftp folder
        #region
        public bool CreateFtpFolder()
        {
            string path = "/HomeWork/";
            bool isCreated = true;
            try
            {
                WebRequest request = WebRequest.Create(host + path);
                request.Method = WebRequestMethods.Ftp.MakeDirectory;
                request.Credentials = new NetworkCredential(userId, password);
                using (var resp = (FtpWebResponse)request.GetResponse())
                {
                    Console.WriteLine("\t" + resp.StatusCode + " into your specified path!");
                }
            }
            catch (WebException ex)
            {
                isCreated = false;
                Console.WriteLine(ex.Message);
                Console.WriteLine("\t Folder already exists!");
                Console.WriteLine("\t Press any key to continue..");
                Console.ReadLine();
            }
         
            return isCreated;
        }
        #endregion
        //Delete directory
        #region
        public void DeleteFtpFolder()
        {
            try
            {
                WebRequest request = WebRequest.Create(host + path);
                request.Method = WebRequestMethods.Ftp.RemoveDirectory;
                request.Credentials = new NetworkCredential(userId, password);
                using (var resp = (FtpWebResponse)request.GetResponse())
                {
                    Console.WriteLine(resp.StatusCode);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        #endregion
        //Upload file
        #region
        public void FileToUpload()
        {
            string filePath = "/HomeWork/";
            WebClient wc = new WebClient();
            wc.Credentials = new NetworkCredential(userId, password);
            wc.UploadFile(host + filePath + fileToUpload, @"C:\temp\" + fileToUpload);
        }
        #endregion
        //Check if the directory exists
        #region
        public bool DoesFtpDirectoryExist(string host, string userId, string password)
        {
            bool isexist = false;

            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(host);
                request.Credentials = new NetworkCredential(userId, password);
                request.Method = WebRequestMethods.Ftp.ListDirectory;
                using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
                {
                    isexist = true;
                }
            }
            catch (WebException ex)
            {
                if (ex.Response != null)
                {
                    FtpWebResponse response = (FtpWebResponse)ex.Response;
                    if (response.StatusCode == FtpStatusCode.ActionNotTakenFileUnavailable)
                    {
                        return false;
                    }
                }
            }
            return isexist;
        }

        #endregion
    }
}
