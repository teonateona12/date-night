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
        public async Task<CompanyInformation> Create(CompanyInformation companyInformation)
        {
            bool companyExists = await context.CompanyInformation.AnyAsync();

            if (companyExists)
            {
                return null;
            }
            await context.CompanyInformation.AddAsync(companyInformation);
            await context.SaveChangesAsync();
            return companyInformation;
        }

        public async Task<CompanyInformation> Delete(int id)
        {
            var information = await context.CompanyInformation.FirstOrDefaultAsync(x=>x.Id==id);
            if (information == null)
            {
                return null;
            }
            
            context.CompanyInformation.Remove(information);
            await context.SaveChangesAsync();
            return information;
        }

        public async Task<CompanyInformation> Get()
        {
            var information = await context.CompanyInformation.FirstOrDefaultAsync();
            return information;
        }

        public async Task<CompanyInformation> Update(int id, CompanyInformation companyInformation)
        {
            var information = await context.CompanyInformation.FirstOrDefaultAsync(x=>x.Id==id);
            if(information == null)
            {
                return null;
            }

            information.PhoneNumber = companyInformation.PhoneNumber;
            information.Email = companyInformation.Email;
            information.Name = companyInformation.Name;

            await context.SaveChangesAsync();
            return information;
        }
    }
}
