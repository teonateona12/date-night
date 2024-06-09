using date_night_admin.Data;
using date_night_admin.Interfaces;
using date_night_admin.Model;
using Microsoft.EntityFrameworkCore;

namespace date_night_admin.Repository
{
    public class AboutCompanyRepository : IAboutCompanyRepository
    {
        private readonly DataContext context;

        public AboutCompanyRepository(DataContext context)
        {
            this.context = context;
        }
        public async Task<AboutCompany> CreateAsync(AboutCompany aboutCompany)
        {
            await context.AboutCompany.AddAsync(aboutCompany);
            await context.SaveChangesAsync();
            return aboutCompany;
        }

        public async Task<AboutCompany> DeleteAsync(int id)
        {
            var information = await context.AboutCompany.FindAsync(id);
            if (information != null)
            {
                return null;
            }

            context.AboutCompany.Remove(information);
            await context.SaveChangesAsync();
            return information;
        }

        public async Task<AboutCompany> GetAsync()
        {
            var aboutCompany = await context.AboutCompany.FirstOrDefaultAsync();
            return aboutCompany;
        }

        public Task<AboutCompany> UpdateAsync(int id, AboutCompany aboutCompany)
        {
            throw new NotImplementedException();
        }
    }
}
