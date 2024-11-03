using NuGet.Packaging.Signing;
using Sun.DAL.Models;
using System.Net;
using System.Net.Mail;

namespace Sun.PL.Helper
{
    public class EmailSettings
    {
        public static void SendEmail(Email email)
        {
            var client = new SmtpClient("smtp.gmail.com",587);
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential("mahmoudqtari5@gmail.com", "njnm yofs imbw smng");
            client.Send("mahmoudqtari5@gmail.com",email.Recevers,email.Subject,email.Body);
            
        }
    }
}
