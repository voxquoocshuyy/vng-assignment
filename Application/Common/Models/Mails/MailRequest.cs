using System.ComponentModel.DataAnnotations;

namespace Application.Common.Models;

public class MailRequest
{
    [EmailAddress]
    public string From { get; set; }
    [EmailAddress]
    public string ToAddress { get; set; }
    public IEnumerable<string> ToAddresses { get; set; } = new List<string>();
    public string Subject { get; set; }
    public string Body { get; set; }
}