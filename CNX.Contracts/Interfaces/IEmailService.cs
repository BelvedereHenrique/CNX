using System.Threading.Tasks;
using CNX.Contracts.DTO;

namespace CNX.Contracts.Interfaces
{
    public interface IEmailService
    {
        Task SendEmailAsync(MailRequestDto mailRequest);
    }
}
