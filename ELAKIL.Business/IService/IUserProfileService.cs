using ELAKIL.Business.Entities;
using System.Threading.Tasks;

namespace ELAKIL.Business.IService
{
    public interface IUserProfileService
    {
        Task<int> AddUserProfileAsync(UserProfile userProfile);

        Task<int> GetUserProfileIdAsync(string name);
    }
}