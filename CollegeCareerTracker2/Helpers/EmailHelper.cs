using SendGrid;
using SendGrid.Helpers.Mail;
using System.Configuration;
using System.Threading.Tasks;

namespace CollegeCareerTracker2.Helpers
{
    public static class EmailHelper
    {
        public static async Task SendEmail(Mail pEmail)
        {
            await Execute(pEmail);
        }

        public static async Task SendEmail(string pTo, string pFrom, string pSubject, string pBody, bool pHTML)
        {
            Email from = new Email(pFrom);
            Email to = new Email(pTo);
            Content content;
            if (pHTML)
            {
                content = new Content("text/html", pBody);
            }
            else
            {
                content = new Content("text/plain", pBody);
            }
            Mail mail = new Mail(from, pSubject, to, content);

            await Execute(mail);

        }

        private static async Task Execute(Mail pEmail)
        {
            string apiKey = ConfigurationManager.AppSettings["SendGridApiKey"];
            dynamic sg = new SendGridAPIClient(apiKey);
            dynamic response = await sg.client.mail.send.post(requestBody: pEmail.Get());
        }



    }
}