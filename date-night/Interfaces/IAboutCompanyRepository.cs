using date_night_user.Data;

namespace date_night_user.Interfaces
{
    public interface IAboutCompanyRepository
    {
        Task<AboutCompany> GetAsync();
    }
}
