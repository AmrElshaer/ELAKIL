using ELAKIL.Business.Entities;
using System.Threading.Tasks;

namespace ELAKIL.Business.IService
{
    public interface IAboutService
    {
        Task<About> GetAboutAsync();

        Task<int> EditAddAboutAsync(About about);
    }
}