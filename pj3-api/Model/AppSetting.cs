namespace pj3_api.Model
{
    public class AppSettings
    {
        public MSSQLSettings MSSQLSettings { get; set; }
        public MailService MailService { get; set; }
    }
    public class MSSQLSettings
    {
        public string SQLConnectionString { get; set; }
    }
    public class MailService
    {
        public string SMTP { get; set; }
        public int Port { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
