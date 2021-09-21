using ELAKIL.Business.Contexts;
using ELAKIL.Business.Entities;
using ELAKIL.Business.IService;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace ELAKIL.Business.Service
{
    public class UserProfileService : IUserProfileService
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

        public async Task<int> GetUserProfileIdAsync(string name)
        {
            var user = await _context.UserProfiles.FirstOrDefaultAsync(a => a.Name == name);
            if (user is null)
                throw new ArgumentNullException($"Entity UserProfile {name} Not Found");
            return user.Id;
        }
        public async Task<UserProfile> GetUserProfileAsync(int userId)
        {
            return await _context.UserProfiles.FindAsync(userId);
        }
    }
}