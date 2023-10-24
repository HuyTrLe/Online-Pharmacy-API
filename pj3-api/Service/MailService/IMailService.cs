using pj3_api.Model;

namespace pj3_api.Service.Mail
{
    public interface IMailService
    {
        Task<int> SendMail(MailParam mailService);
      
    }
}
