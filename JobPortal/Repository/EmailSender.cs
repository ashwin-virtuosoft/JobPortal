using System.Net.Mail;
using System.Net;

namespace JobPortal.Repository
{
    public class EmailSender:IEmailSender
    {
        private readonly IConfiguration _configuration;

        public EmailSender(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<bool> SendEmail(Dictionary<string, string> MailContent)
        {
            var mail = "TestJobPortal@outlook.com";
            var pwd = _configuration["Credentials:Password"];
            var client = new SmtpClient("smtp-mail.outlook.com", 587)
            {
                EnableSsl = true,
                Credentials = new NetworkCredential(mail, pwd)
            };

            try
            {
                client.SendMailAsync
                    (new MailMessage(
                   from: mail, to: MailContent["Email"], MailContent["Subject"], MailContent["Message"]));
                return true;
            }catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<Dictionary<string, string>> SendMessage(Dictionary<string, string> MailContent)
        {
            Dictionary<string, string> EmailContent = new Dictionary<string, string>();
            await Task.Run(() =>
            {
                string Subject = "Verify Your Email Address for Full Access to Job Portal";
                string Message = $"Dear {MailContent["Name"]},\r\n\r\nWelcome to JobPortal!  we've generated a temporary password for you to sign in. Here are your temporary login details:\r\n\r\nUsername/Email:\n{MailContent["Email"]} \r\nTemporary Password: \n{MailContent[MailContent["Email"]]}" +
                    "\r\nPlease sign in using the provided credentials to access your account";
                EmailContent.Add("Subject", Subject);
                EmailContent.Add("Message", Message);
                EmailContent.Add("Email", MailContent["Email"]);
             });
                                                                        
            return EmailContent;
        }
        }
    }
