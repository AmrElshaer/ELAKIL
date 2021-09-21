using ELAKIL.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELAKIL.Business.IService
{
    public interface IMessageService
    {
        Task<int> AddAsync(string sendTo,string sendFrom, string content);
        Task<IEnumerable<Message>> GetMessagesAsync(int userId);
        IEnumerable<Message> GetUserSendMessagesAsync();
    }
}
