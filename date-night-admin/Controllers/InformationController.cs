using date_night_admin.Interfaces;
using date_night_admin.Model;
using Microsoft.AspNetCore.Mvc;

namespace date_night_admin.Controllers
{
    [Route("api/admin/[controller]")]
    [ApiController]
    public class InformationController : Controller
    {
        private readonly ICompanyInformationRepository companyInformation;

        public InformationController(ICompanyInformationRepository companyInformation)
        {
            this.companyInformation = companyInformation;
        }

        [HttpGet]
        public async Task<ActionResult<List<CompanyInformation>>> GetAll()
        {
            var information = await companyInformation.GetAll();

            return Ok(information);
        }
    }
}
