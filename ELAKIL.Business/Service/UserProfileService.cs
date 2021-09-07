using ELAKIL.Business.Contexts;
using ELAKIL.Business.Entities;
using ELAKIL.Business.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELAKIL.Business.Service
{
    public class UserProfileService:IUserProfileService
    {
        private readonly ApplicationDbContext _context;

        public UserProfileService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> AddUserProfileAsync(UserProfile userProfile)
        {
            if (userProfile is null)
                throw new ArgumentNullException();
            await _context.UserProfiles.AddAsync(userProfile);
            await _context.SaveChangesAsync();
            return userProfile.Id;
        }

        public int GetUserProfileId(string Name)
        {
            var usrProfId = _context.UserProfiles.Where(x => x.Name == Name)
                .FirstOrDefault().Id;
            if (usrProfId == 0)
                throw new ArgumentNullException($"Entity UserProfile {Name} Not Found");
            return usrProfId;
        }
    }
}
