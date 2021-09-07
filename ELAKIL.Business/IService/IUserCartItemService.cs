using ELAKIL.Business.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ELAKIL.Business.IService
{
    public interface IUserCartItemService
    {
        Task<IEnumerable<UserCartItem>> GetUserCartItemsAsync();
        Task<int> AddUserCartItemAsync(UserCartItem userCartItem);
        Task<int> EditUserCartItemAsync(UserCartItem userCartItem);
        Task DeleteUserCartItemAsync(int id);
        Task<UserCartItem> GetUserCartItemAsync(int id);
    }
}
