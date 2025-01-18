using MimeKit;
using MailKit.Net.Smtp;
using IPM.Application.IServices;

namespace IPM.WebApi.Services;

public class EmailService(IConfiguration config): IEmailService
{
    public void SendMail(string receiverName, string receiverAddress, string emailMessage)
    {
        var email = new MimeMessage();
        email.From.Add(new MailboxAddress(config["Mailer:Name"], config["Mailer:EmailAddress"]));
        email.To.Add(new MailboxAddress(receiverName, receiverAddress));

        email.Subject = "Testing";
        email.Body = new TextPart(MimeKit.Text.TextFormat.Html)
        {
            Text = emailMessage
        };
        using (var smtp = new SmtpClient())
        {
            smtp.Connect(config["Mailer:Server"], 465, false);
            smtp.Authenticate(config["Mailer:EmailAddress"], config["Mailer:Password"]);
            smtp.Send(email);
            smtp.Disconnect(true);
        }
    }
}
