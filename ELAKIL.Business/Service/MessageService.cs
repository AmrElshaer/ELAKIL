using ELAKIL.Business.Contexts;
using ELAKIL.Business.Entities;
using ELAKIL.Business.IService;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELAKIL.Business.Service
{
    public class MessageService:IMessageService
    {
        private readonly ApplicationDbContext dbContext;

        public MessageService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public  async Task<int> AddAsync(string sendTo, string sendFrom, string content)
        {
            var message = await GenerateMessageAsync();
            await this.dbContext.Messages.AddAsync(message);
            await this.dbContext.SaveChangesAsync();
            return message.Id; 

            async Task<Message> GenerateMessageAsync()
            {
                var result = new Message();
                result.SendDate = DateTime.Now;
                result.Content = content;
                result.ToUserProfileId=  !string.IsNullOrEmpty(sendTo) ? 
                    (await this.dbContext.UserProfiles.FirstOrDefaultAsync(a => a.Name == sendTo))?.Id:null;
                result.FromUserProfileId=!string.IsNullOrEmpty(sendFrom) ?
                    (await this.dbContext.UserProfiles.FirstOrDefaultAsync(a => a.Name == sendFrom))?.Id:null;
                return result;
            }
        }
       
        public  IEnumerable<Message> GetUserSendMessagesAsync()
        {
           var result=  this.dbContext.Messages.Include(a => a.FromUserProfile).Include(a=>a.ToUserProfile)
                .OrderByDescending(a=>a.SendDate)
                .AsEnumerable().GroupBy(a => a.FromUserProfileId).Select(a=>a.FirstOrDefault()).ToList();
            return result;
        }
        public async Task<IEnumerable<Message>> GetMessagesAsync(int userId)
        {
            var result = await this.dbContext.Messages.Where(a => a.FromUserProfileId == userId ||
             a.ToUserProfileId == userId).ToListAsync();
            return result;
        }
    }
}
