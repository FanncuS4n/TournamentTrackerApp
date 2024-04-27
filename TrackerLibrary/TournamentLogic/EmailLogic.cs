using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary.TournamentLogic
{
    public static class EmailLogic
    {
        public static void SendEmail(string To, string subject, string Body)
        {
            SendEmail(new List<string> { To }, new List<string>(), subject, Body);
        }

        public static void SendEmail(List<string> To, List<string> Bcc,string subject,  string Body)
        {
            MailAddress FromMailAddress = new MailAddress(GlobalConfig.AppKeyLookup("senderEmail"), GlobalConfig.AppKeyLookup("senderDisplayName"));

            MailMessage Mail = new MailMessage();
            foreach (var Email in To)
            {
                Mail.To.Add(Email);
            }
            foreach (var Email in Bcc)
            {
                Mail.Bcc.Add(Email);
            }

            Mail.From = FromMailAddress;
            Mail.Subject = subject;
            Mail.Body = Body;
            Mail.IsBodyHtml = true;

            SmtpClient smtpClient = new SmtpClient();

            smtpClient.Send(Mail);
        }
    }
}
 