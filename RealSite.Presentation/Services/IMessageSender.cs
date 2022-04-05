using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace RealSite.Presentation.Services
{
    public interface IMessageSender
    {
        Task SendEmailAsync(string email, string subject, string message, IFormFile uploadedFile = null);
    }
}
