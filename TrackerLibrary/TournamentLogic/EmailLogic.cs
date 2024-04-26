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
        public static void SendEmail(string To,string subject,  string Body)
        {
            MailAddress FromMailAddress = new MailAddress(GlobalConfig.AppKeyLookup("senderEmail"), GlobalConfig.AppKeyLookup("senderDisplayName"));

            MailMessage Mail = new MailMessage();
            Mail.To.Add(To);
            Mail.From = FromMailAddress;
            Mail.Subject = subject;
            Mail.Body = Body;
            Mail.IsBodyHtml = true;

            SmtpClient smtpClient = new SmtpClient();

            smtpClient.Send(Mail);
        }
    }
}
 