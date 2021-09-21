using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELAKIL.Business.Entities
{
    public class Message
    {
        public int Id { get; set; }
        public int? FromUserProfileId { get; set; }
        public UserProfile FromUserProfile { get; set; }
        public int? ToUserProfileId { get; set; }
        public UserProfile ToUserProfile { get; set; }
        public DateTime SendDate { get; set; }
        public string Content { get; set; }
    }
}
