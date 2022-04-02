using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Email
{
    public class EmailService
    {
        public Task SendAsync(string destination, string subject, string body)
        {
            SmtpClient client = new SmtpClient();
            client.Port = 587;
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            //client.Timeout = 10000;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential("feelgdtest@gmail.com", "Asdfgg123.@");

            return client.SendMailAsync("feelgdtest@gmail.com", destination, subject, body);
        }
    }
}
