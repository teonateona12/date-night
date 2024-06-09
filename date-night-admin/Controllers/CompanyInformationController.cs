using date_night_admin.Interfaces;
using date_night_admin.Model;
using Microsoft.AspNetCore.Mvc;

namespace date_night_admin.Controllers
{
    [Route("api/admin/[controller]")]
    [ApiController]
    public class CompanyInformationController : Controller
    {
        private readonly ICompanyInformationRepository companyInformation;

        public CompanyInformationController(ICompanyInformationRepository companyInformation)
        {
            this.companyInformation = companyInformation;
        }

        [HttpGet]
        public async Task<ActionResult<CompanyInformation>> Get()
        {
            var information = await companyInformation.Get();
            if (information == null)
            {
                return NotFound();
            }
            return Ok(information);
        }

        [HttpPost]
        public async Task<ActionResult<CompanyInformation>> Create(CompanyInformation information)
        {
            var company = await companyInformation.Create(information);
            if (company == null)
            {
                return NotFound();
            }
            return Ok(company);

        }


    }
}
