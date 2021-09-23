using ELAKIL.Business.Entities;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELAKIL.UI.Hubs
{
    public class ChatService
    {
        public ConcurrentDictionary<string, int> MessagesNotSee = new ConcurrentDictionary<string, int>();
        public ConcurrentDictionary<string,bool> ActiveUsers = new ConcurrentDictionary<string,bool>();
    }
}
