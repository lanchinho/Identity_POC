using Microsoft.AspNet.Identity;
using System;
using System.Configuration;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Threading.Tasks;
using System.Web;

namespace Infrastructure.Identity.Configuration
{
    public class EmailService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            // Habilitar o envio de e-mail
            if (false)
            {
                var text = HttpUtility.HtmlEncode(message.Body);

                var msg = new MailMessage { From = new MailAddress("derpprogrammertes@gmail.com", "Admin do Portal") };

                msg.To.Add(new MailAddress(message.Destination));
                msg.Subject = message.Subject;
                msg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(text, null, MediaTypeNames.Text.Plain));
                msg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(text, null, MediaTypeNames.Text.Html));

                var smtpClient = new SmtpClient( "smtp.gmail.com", Convert.ToInt32(587));
                //var credentials = new NetworkCredential(ConfigurationManager.AppSettings["ContaDeEmail"],
                //    ConfigurationManager.AppSettings["SenhaEmail"]);
                var credentials = new NetworkCredential("guilherme@uniriotec.com", "12345derp");
                smtpClient.Credentials = credentials;
                smtpClient.EnableSsl = true;
                smtpClient.Send(msg);
            }

            return Task.FromResult(0);
        }
    }
}
