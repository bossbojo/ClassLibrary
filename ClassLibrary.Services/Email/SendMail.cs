using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SelectPdf;
using System.IO;
using System.Net;
using System.Net.Mail;


namespace ClassLibrary.Services.Email
{
    public class SendMail
    {
        public static string Smtp = "mail.runbox.com";
        public static string email_sender = "support@9t.com"; 
        public static string passmailAddress = "Ninet890!";   
        public static bool Mail(string ToMail, string Subject, string Body, string KrakenCard_Support = "KrakenCard Support")
        {
            try
            {
                var smtp = new SmtpClient
                {
                    Host = Smtp,
                    Port = 587,//587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(email_sender, passmailAddress)
                };

                using (var message = new MailMessage(new MailAddress(email_sender, KrakenCard_Support), new MailAddress(ToMail))
                {
                    Subject = Subject,
                    Body = Body,
                    IsBodyHtml = true
                })
                {
                    smtp.Send(message);
                }

                return true;

            }
            catch { return false; }
        }

        public static bool MailAttachments(string ToMail, string Subject, string Body, string HTMLAttachments, string filename = "Invoice.pdf", string KrakenCard_Support = "KrakenCard Support")
        {
            try
            {
                var smtp = new SmtpClient
                {
                    Host = Smtp,
                    Port = 587,//587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(email_sender, passmailAddress)
                };

                HtmlToPdf converter = new HtmlToPdf();
                PdfDocument doc = converter.ConvertHtmlString(HTMLAttachments);

                // save pdf document 
                byte[] pdf = doc.Save();

                // close pdf document 
                doc.Close();

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    byte[] bytes = pdf.ToArray();
                    memoryStream.Close();

                    MailMessage mm = new MailMessage(new MailAddress(email_sender, KrakenCard_Support), new MailAddress(ToMail));
                    mm.Subject = Subject;
                    mm.Body = Body;
                    mm.Attachments.Add(new Attachment(new MemoryStream(bytes), filename));
                    mm.IsBodyHtml = true;
                    smtp.Send(mm);
                }

                return true;
            }
            catch { return false; }
        }
    }
}
