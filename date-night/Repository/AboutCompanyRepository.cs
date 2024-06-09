using date_night_user.Data;
using date_night_user.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace date_night_user.Repository
{
    public class AboutCompanyRepository : IAboutCompanyRepository
    {
        private readonly DataContext context;

        public AboutCompanyRepository(DataContext context)
        {
            this.context = context;
        }
        public async Task<AboutCompany> GetAsync()
        {
            var company = await context.AboutCompany.FirstOrDefaultAsync();
            if (company == null)
            {
                return null;
            }
            return company;
        }
    }
}
