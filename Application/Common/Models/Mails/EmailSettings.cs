namespace Application.Common.Models;

public class EmailSettings
{
    public string DisplayName { get; set; }
    public string From { get; set; }
    public string SmtpServer { get; set; }
    public bool UseSsl { get; set; }
    public int Port { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
}