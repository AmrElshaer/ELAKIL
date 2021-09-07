using System;
using System.Collections.Generic;
using System.Text;
using ELAKIL.Business.IService;
using ELAKIL.Business.Contexts;
using ELAKIL.Business.Entities;
using System.Threading.Tasks;

namespace ELAKIL.Business.Service
{
    public class AboutService : IAboutService
    {
        private ApplicationDbContext context;
        
        public AboutService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<About> GetAboutAsync(int id)
        {
            About about = await context.Abouts.FindAsync(id);
            if (about is null) 
                throw new NullReferenceException($"About with id { id } not found");
            return about;
        }

        public async Task<int> EditAboutAsync(int id, About updatedAbout)
        {
            About about = await context.Abouts.FindAsync(id);
            if (about is null)
                throw new NullReferenceException();
            about.AboutUs = updatedAbout.AboutUs;
            about.FaceBook = updatedAbout.FaceBook;
            about.Twitter = updatedAbout.Twitter;
            about.Whatsapp = updatedAbout.Whatsapp;
            about.Number = updatedAbout.Number;
            about.Image = updatedAbout.Image;
            await context.SaveChangesAsync();
            return about.Id;
        }
    }
}
