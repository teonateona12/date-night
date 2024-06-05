using date_night_user.Data;
using date_night_user.Interfaces;
using date_night_user.Model;
using Microsoft.EntityFrameworkCore;

namespace date_night_user.Repository
{
    public class CompanyInformationRepository : ICompanyInformationRepository
    {
        private readonly DataContext context;

        public CompanyInformationRepository(DataContext context)
        {
            this.context = context;
        }
        public async Task<CompanyInformation> Get()
        {
            var information = await context.CompanyInformation.FirstOrDefaultAsync();

            return information;
        }
    }
}
