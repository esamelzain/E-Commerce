using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Net;

namespace E_CommerceApi.Handlers
{
    public class SendEmail
    {

        const String SMTP_USERNAME = "Info@ahad-me.com";
        const String SMTP_PASSWORD = "A!had@2020";
        const String HOST = "smtp.office365.com";
        const int PORT = 587;

        public static bool SendResetPasswordMail(string ToEmail, string EmailSubject, string EmailBody)
        {

            try
            {
                //string MailAccount = "Info@ahad-me.com";
                //string password = "A!had@2020";
                string MailAccount = "Info@ahad-me.com";
                string password = "A!had@2020";

                NetworkCredential loginInfo = new NetworkCredential(MailAccount, password, "ahad-me.com");
                MailMessage msg = new MailMessage();
                msg.From = new MailAddress(MailAccount, "AHAD - Securely Transforming Notification: Reset Password");
                msg.To.Add(new MailAddress(ToEmail));
                msg.Subject = EmailSubject;
                msg.Body = EmailBody;
                msg.IsBodyHtml = true;
                SmtpClient client = new SmtpClient("smtp.office365.com", 587);
                client.EnableSsl = true;
                client.Credentials = loginInfo;
                client.Send(msg);
            }
            catch (Exception)
            {
            }
            return true;

        }

        public static bool SendPasswordLinkToMail(string ToEmail, string EmailSubject, string EmailBody)
        {

            try
            {
                string MailAccount = "Info@ahad-me.com";
                string password = "A!had@2020";
                NetworkCredential loginInfo = new NetworkCredential(MailAccount, password, "ahad-me.com");
                MailMessage msg = new MailMessage();
                msg.From = new MailAddress(MailAccount, "AHAD - Securely Transforming Notification : Reset Password Link");
                msg.To.Add(new MailAddress(ToEmail));
                msg.Subject = EmailSubject;
                msg.Body = EmailBody;
                msg.IsBodyHtml = true;
                SmtpClient client = new SmtpClient("smtp.office365.com", 587);
                client.EnableSsl = true;
                client.Credentials = loginInfo;
                client.Send(msg);
            }
            catch (Exception)
            {
            }
            return true;

        }

        public static bool SendRegistrationEmil(string ToEmail, string EmailSubject, string EmailBody)
        {
             
            SmtpClient client = new SmtpClient();
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential("info@ahad-me.com", "A!had@2020");
            client.Port = 587;
            client.Host = "smtp.office365.com"; 
            client.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
            client.EnableSsl = true;

            MailMessage msg = new MailMessage();
            msg.To.Add(ToEmail);
            msg.From = new MailAddress("info@ahad-me.com");
            msg.Body = EmailBody;
            msg.Subject = EmailSubject;
            msg.IsBodyHtml = true;

            try
            {
                client.Send(msg);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
             

        }
        public static bool SendSMTPMail(string ToEmail, string EmailSubject, string EmailBody)
        {
            try
            {
                MailMessage msg = new MailMessage();
                msg.From = new MailAddress(SMTP_USERNAME, "AHAD - Securely Transforming Notification");
                msg.To.Add(new MailAddress(ToEmail));
                msg.Body = EmailBody;
                msg.Subject = EmailSubject;
                msg.IsBodyHtml = true;
                SmtpClient client = new SmtpClient();
                client.Host = HOST;
                client.EnableSsl = true;
                client.UseDefaultCredentials = false;
                client.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                NetworkCredential NetworkCred = new NetworkCredential(SMTP_USERNAME, SMTP_PASSWORD, "ahad-me.com");
                client.Credentials = NetworkCred;
                client.Port = PORT;

                try
                {
                    client.Send(msg);
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }

        }


        public static bool EnquiryNotificationToManagement(string EmailBody, string EmailSubject = "", string OtherUsers = "")
        {
            if (string.IsNullOrEmpty(EmailSubject))
            {
                EmailSubject = "Enquiry Notification";
            }
            MailMessage msg = new MailMessage();
            msg.To.Add("muneeb@ahad-me.com");
            msg.To.Add("ankit@ahad-me.com");
            msg.To.Add("rohan@ahad-me.com");
            if (!string.IsNullOrEmpty(OtherUsers))
                msg.To.Add(OtherUsers);
            msg.From = new MailAddress(SMTP_USERNAME, SMTP_USERNAME);
            msg.Body = EmailBody;
            msg.Subject = EmailSubject;
            msg.IsBodyHtml = true;
            SmtpClient client = new SmtpClient();
            client.Host = HOST;
            client.EnableSsl = true;
            client.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
            NetworkCredential NetworkCred = new NetworkCredential(SMTP_USERNAME, SMTP_PASSWORD, "ahad-me.com");
            client.Credentials = NetworkCred;
            client.Port = PORT;

            try
            {
                client.Send(msg);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}