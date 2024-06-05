using date_night_user.Interfaces;
using date_night_user.Model;
using Microsoft.AspNetCore.Mvc;

namespace date_night_user.Controllers
{
    [Route("api/admin/[controller]")]
    [ApiController]
    public class CompanyInformationController : ControllerBase
    {
        private readonly ICompanyInformationRepository company;

        public CompanyInformationController(ICompanyInformationRepository company)
        {
            this.company = company;
        }
        [HttpGet]
        public async Task<CompanyInformation> GetCompanyInformation()
        {
            var information = await company.Get();

            return information;
        }
    }
}
