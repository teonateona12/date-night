using date_night_user.Data;
using date_night_user.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace date_night_user.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutCompanyController : ControllerBase
    {
        private readonly IAboutCompanyRepository aboutCompany;

        public AboutCompanyController(IAboutCompanyRepository aboutCompany)
        {
            this.aboutCompany = aboutCompany;
        }

        [HttpGet]
        public async Task<ActionResult<AboutCompany>> Get()
        {
            var company = await aboutCompany.GetAsync();
            if(company == null)
            {
                return NotFound();
            }
            return Ok(company);
        }
    }
}
