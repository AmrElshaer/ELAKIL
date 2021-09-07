using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ELAKIL.Business.Entities;

namespace ELAKIL.Business.IService
{
    public interface IAboutService
    {
        Task<About> GetAboutAsync(int id);
        Task<int> EditAboutAsync(int id, About about);
    }
}
