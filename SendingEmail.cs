using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace MenuSMPTUserConsoleApp
{
    class SendingEmail
    {
        //properties
        #region
        public static string username { get; set; }
        public static string password { get; set; }
        public static string Bcc { get; private set; }
        public static string Cc { get; set; }
        public static string destination { get; private set; }
        public static string subject { get; private set; }
        public static string body { get; private set; }
        public static int exitCode { get; set; }
        #endregion
        //sendmail method
        #region
        public void SendEmail()
        {
            MenuBar CreateMenuBar = new MenuBar();
            //email 
            #region
            Console.WriteLine("▬Please enter your email address: ");
            username = Console.ReadLine();
            while (username == string.Empty)
            {
                Console.WriteLine("▬Please enter your email address: ");
                username = Console.ReadLine();
            }
            //password
            Console.WriteLine("Please enter your password: ");
            password = Console.ReadLine();
            while (password == string.Empty)
            {
                Console.WriteLine("Please enter your password: ");
                password = Console.ReadLine();
            }
            //bcc
            Console.WriteLine("Please enter the BCC of the email: ");
            Bcc = Console.ReadLine();
            while (Bcc == string.Empty)
            {
                Console.WriteLine("Please enter the BCC of the email: ");
                Bcc = Console.ReadLine();
            } 
            //cc
            Console.WriteLine("Please enter the CC of the message: ");
            Cc = Console.ReadLine();
            while (Cc == string.Empty)
            {
                Console.WriteLine("Please the CC of the message: ");
                Cc = Console.ReadLine();
            }
            //subject
            Console.WriteLine("Please enter the Subject of the message: ");
            subject = Console.ReadLine();
            while (subject == string.Empty)
            {
                Console.WriteLine("Please enter the Subject of the message: ");
                subject = Console.ReadLine();
            }
            //body
            Console.WriteLine("Please enter the body of the message: ");
            body = Console.ReadLine();
            while (body == string.Empty)
            {
                Console.WriteLine("Please enter the body of the message: ");
                body = Console.ReadLine();
            }
            //destination
            Console.WriteLine("Please enter the email addres you wish to send the message: ");
            destination = Console.ReadLine();
            while (destination == string.Empty) 
            {
                Console.WriteLine("Please enter the email address you wish to send the message: ");
                destination = Console.ReadLine();
            }
            #endregion 
            //Settin up Smpt Client and Server
            #region
            try
            {
                using (SmtpClient client = new SmtpClient("smtp.gmail.com", 587))//587 TLS , 465 SSL or default type of port
                {
                    client.EnableSsl = true;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.UseDefaultCredentials = false;
                    client.Credentials = new NetworkCredential(username, password);

                    //mail set-up
                    MailMessage msgObj = new MailMessage();
                    msgObj.From = new MailAddress(username);
                    msgObj.Subject = subject;
                    msgObj.Body = body;
                    msgObj.To.Add(new MailAddress(username));
                    msgObj.CC.Add(new MailAddress(Cc)); //Adding CC 
                    msgObj.Bcc.Add(new MailAddress(Bcc));  //Adding BCC   
                    msgObj.To.Add(destination);
                    client.Send(msgObj);
                    Console.WriteLine("Email was succesfully sent!");
                    Console.WriteLine("Enter any key to go back to Menu...");
                    Console.ReadLine();
                    Console.Clear();
                    CreateMenuBar.CreateMenuBar("reload..");
                }
            }
            catch (System.FormatException e)
            {
                Console.WriteLine("" + e.Message);
                //Console.WriteLine("Erro at: " + e.StackTrace);
            }
            catch (TimeoutException e)
            {
                Console.WriteLine(e.Message + "www.google.com!");
                Console.WriteLine("Error at: " + e.StackTrace);
            }
            catch (System.ArgumentException e)
            {
                Console.WriteLine("Error is beacuse: " + e.Message);
                Console.WriteLine("Search in : " + e.StackTrace);
            }
            #endregion
        }
        #endregion
    }
}
