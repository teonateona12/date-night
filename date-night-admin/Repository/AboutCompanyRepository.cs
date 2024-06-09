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

        public Task<AboutCompany> DeleteAsync(int id)
        {
            throw new NotImplementedException();
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
