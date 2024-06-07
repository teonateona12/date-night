using date_night_admin.Model;

namespace date_night_admin.Interfaces
{
    public interface IAboutCompanyRepository
    {
        Task<AboutCompany> CreateAsync(AboutCompany aboutCompany);

    }
}
