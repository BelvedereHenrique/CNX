namespace CNX.Contracts.DTO
{
    public class MailRequestDto
    {
        public MailRequestDto(string to, string subject, string body)
        {
            ToEmail = to;
            Subject = subject;
            Body = body;
        }

        public string ToEmail { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
