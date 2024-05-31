using date_night_admin.Data;
using date_night_admin.Interfaces;
using date_night_admin.Model;
using Microsoft.EntityFrameworkCore;

namespace date_night_admin.Repository
{
    public class CompanyInformationRepository : ICompanyInformationRepository
    {
        private readonly DataContext context;

        public CompanyInformationRepository(DataContext context)
        {
            this.context = context;
        }
        public Task<CompanyInformation> Create(CompanyInformation companyInformation)
        {
            throw new NotImplementedException();
        }

        public Task<CompanyInformation> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<CompanyInformation>> GetAll()
        {
            var information = await context.CompanyInformation.ToListAsync();

            return information;
        }

        public Task<CompanyInformation> Update(int id, CompanyInformation companyInformation)
        {
            throw new NotImplementedException();
        }
    }
}
