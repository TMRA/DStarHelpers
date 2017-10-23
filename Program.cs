internal class Program
{
    // Methods
    private static void Main(string[] args)
    {
        if (File.Exists(new AppSettingsReader().GetValue("NewUserDStarFileToCheck", Type.GetType("System.String")).ToString()) && !File.ReadAllText(new AppSettingsReader().GetValue("NewUserDStarFileToCheck", Type.GetType("System.String")).ToString()).Contains("(0 rows)"))
        {
            SendEmail(new AppSettingsReader().GetValue("PeopleToEmail", Type.GetType("System.String")).ToString());
            if (Convert.ToBoolean(new AppSettingsReader().GetValue("DeleteFileAfterEmailSent", Type.GetType("System.Boolean"))))
            {
                try
                {
                    File.Delete(new AppSettingsReader().GetValue("NewUserDStarFileToCheck", Type.GetType("System.String")).ToString());
                }
                catch
                {
                }
            }
        }
    }

    private static void SendEmail(string List)
    {
        MailMessage message = new MailMessage("notify@AAAAA.com", List, "New W8HHF D-Star User Registration", "Attached is a list of new user registrations.  Please login to the W8HHF D-Star Gateway and register them and send the welcome email.");
        message.Attachments.Add(new Attachment(new AppSettingsReader().GetValue("NewUserDStarFileToCheck", Type.GetType("System.String")).ToString()));
        new SmtpClient("localhost", 25).Send(message);
    }
}
