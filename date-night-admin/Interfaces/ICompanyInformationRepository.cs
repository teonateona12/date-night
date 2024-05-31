using date_night_admin.Model;

namespace date_night_admin.Interfaces
{
    public interface ICompanyInformationRepository
    {
        Task<List<CompanyInformation>> GetAll();
        Task<CompanyInformation> Delete(int id);
        Task<CompanyInformation> Update(int id, CompanyInformation companyInformation);
        Task<CompanyInformation> Create(CompanyInformation companyInformation);

    }
}
