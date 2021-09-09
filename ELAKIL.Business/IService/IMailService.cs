using ELAKIL.UI.Models;
using System.Threading.Tasks;

namespace ELAKIL.Business.IService
{
    public interface IMailService
    {
        Task SendAsync(MessageModel message);
    }
}