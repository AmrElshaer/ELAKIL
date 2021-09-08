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
    public class UserCartItemService : IUserCartItemService
    {
        private readonly ApplicationDbContext _context;

        public UserCartItemService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddUserCartItemAsync(UserCartItem userCartItem)
        {
            if (userCartItem is null)
                throw new ArgumentNullException();
            await  _context.UserCartItems.AddAsync(userCartItem);
            await _context.SaveChangesAsync();
            return userCartItem.ID;
        }

        public async Task DeleteUserCartItemAsync(int id)
        {
            _context.UserCartItems.Remove(await GetUserCartItemAsync(id));
            await _context.SaveChangesAsync();
        }

        public async Task<int> EditUserCartItemAsync(UserCartItem userCartItem)
        {
            if (userCartItem is null)
                throw new ArgumentNullException($"Entity UserCartItem {userCartItem.ID} Not Found");
            _context.UserCartItems.Update(userCartItem);
            await _context.SaveChangesAsync();
            return userCartItem.ID;
        }

        public async Task<UserCartItem> GetUserCartItemAsync(int id)
        {
            var mel = await _context.UserCartItems.FindAsync(id);
            if (mel is null)
                throw new ArgumentNullException($"Entity Meal {id} Not Found");
            return mel;
        }

       

        public async Task<IEnumerable<UserCartItem>> GetUserCartItemsAsync(int userProfileId)
        {
            return await _context.UserCartItems.Where(a => a.UserID == userProfileId).ToListAsync();
        }
    }
}
