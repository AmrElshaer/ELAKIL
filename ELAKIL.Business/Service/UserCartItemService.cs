using ELAKIL.Business.Contexts;
using ELAKIL.Business.Entities;
using ELAKIL.Business.IService;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
            _context.UserCartItems.Add(userCartItem);
            _context.SaveChanges();
            return userCartItem.ID;
        }

        public void DeleteUserCartItemAsync(int id)
        {
            _context.UserCartItems.Attach(GetUserCartItemAsync(id).Result);
            _context.UserCartItems.Remove(GetUserCartItemAsync(id).Result);
            _context.SaveChangesAsync();
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

        public async Task<IEnumerable<UserCartItem>> GetUserCartItemsAsync()
        {
            return await _context.UserCartItems.ToListAsync();
        }
    }
}
