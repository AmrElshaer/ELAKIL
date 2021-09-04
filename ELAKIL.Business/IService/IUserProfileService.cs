using ELAKIL.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELAKIL.Business.IService
{
    public interface IUserProfileService
    {
        Task<int> AddUserProfileAsync(UserProfile userProfile);
    }
}
