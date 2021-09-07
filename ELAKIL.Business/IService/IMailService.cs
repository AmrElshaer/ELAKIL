using ELAKIL.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELAKIL.Business.IService
{
    public interface IMailService
    {
        Task SendAsync(MessageModel message);
    }
}
