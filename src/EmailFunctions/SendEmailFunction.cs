using Microsoft.Azure.WebJobs;
using SendGrid.Helpers.Mail;

namespace EmailFunctions
{
    public static class SendEmailFunction
    {
        [FunctionName("SendEmail")]
        public static void Run(
            [ServiceBusTrigger("outgoingemails", Microsoft.ServiceBus.Messaging.AccessRights.Manage, Connection = "NOTIFICATIONSSERVICEBUSCONNECTION")] string myQueueItem,
            [SendGrid(ApiKey = "SENDGRIDAPIKEY")] SendGridMessage message)
        {
            message.AddTo("matt.ridgway@caternet.co.uk");
            message.AddContent("text/html", "This is sent from a precompiled function");
            message.SetFrom(new EmailAddress("matt.ridgway@caternet.co.uk"));
            message.SetSubject("Function test message");
        }
    }
}
