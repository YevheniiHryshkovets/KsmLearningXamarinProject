using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;
using DesctopKSMClient.Data;

namespace DesctopKSMClient.Model
{
    public class MailSender
    {
        public static MailAddress adminMail = new MailAddress("mainksmappadminakk@ukr.net");
        public static string adminMailPassword = "uR9WGrvDVjjiFciu";
        public static MailAddress senderMail = new MailAddress("mainksmappsender@ukr.net");
        public static string senderMailPassword = "ksmappmainsenderpassword";

        public void SendMessage(string result, string testName)
        {
            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Host = "imap.ukr.net";
            smtpClient.Port = 993;
            smtpClient.EnableSsl = true;
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential(senderMail.Address, senderMailPassword);

            MailMessage message = new MailMessage();
            message.From = senderMail;
            message.To.Add(adminMail);
            message.Subject = "TestResult";
            message.Body = "Результат проходження теста \"" + testName + "\" = " + result + "/10 ім'я студента: " + User.UserName + " з групи " + User.GroupName;
            smtpClient.Send(message);
        }

    }
}
