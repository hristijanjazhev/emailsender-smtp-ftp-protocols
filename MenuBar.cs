using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace MenuSMPTUserConsoleApp
{
    public class MenuBar
    {
        #region declaring properties
        public static string username { get; set; }
        public static string password { get; set; }
        public static string Bcc { get; private set; }
        public static string Cc { get; set; }
        public static string destination { get; private set; }
        public static string subject { get; private set; }
        public static string body { get; private set; }
        public static int exitCode { get; set; }
        #endregion 
        #region set-up for Menu
        public void CreateMenuBar(string MenuBar)
        {
            MenuBar CreateMenuBar = new MenuBar();
            bool quit = false;
            int option = -1;
            string userInput = null;
            string pass = "";
            ConsoleColor green = ConsoleColor.Green;
            Console.ForegroundColor = green;

            Console.WriteLine("\n Please choose one of the options below: ");
            Console.WriteLine("\t 1) Send Email: ");
            Console.WriteLine("\t 2) CRUD files with FTP in a Server");
            Console.WriteLine("\t 3) Quit");
            
            while (!quit)
            {
                userInput = Console.ReadLine();
                if (!Int32.TryParse(userInput, out option) || !(option >= 1 && option <= 3))
                {
                    Console.WriteLine("Invalid input.Try again: ");
                    CreateMenuBar.CreateMenuBar(MenuBar);
                }
                switch (option)
                {
                    case 1:
                        //SendMail
                        SendingEmail se = new SendingEmail();
                        se.SendEmail();
                      break;
                    case 2:
                        //CRUD
                        CRUD cf = new CRUD();
                        cf.FolderCreating();
                        CreateMenuBar.CreateMenuBar("Reaload..");
                        break;
                    case 3:
                        //Quit
                            int exitCode = Environment.ExitCode;
                            Console.WriteLine("\t Closing the program...");
                            Environment.Exit(exitCode);
                        break;
                    default:
                        break;
                }
            }
        }
        #endregion 
    }
}
