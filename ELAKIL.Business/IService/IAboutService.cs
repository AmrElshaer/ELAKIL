using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ELAKIL.Business.Entities;

namespace ELAKIL.Business.IService
{
    public interface IAboutService
    {
        Task<About> GetAboutAsync();
        Task<int> EditAddAboutAsync(About about);
    }
}
