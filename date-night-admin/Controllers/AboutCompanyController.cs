using date_night_admin.Interfaces;
using date_night_admin.Model;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace date_night_admin.Controllers
{
    [Route("api/admin/[controller]")]
    [ApiController]
    public class AboutCompanyController : ControllerBase
    {
        private readonly IAboutCompanyRepository aboutCompanyRepository;

        public AboutCompanyController(IAboutCompanyRepository aboutCompanyRepository)
        {
            this.aboutCompanyRepository = aboutCompanyRepository;
        }


        [HttpPost]
        public async Task<ActionResult<AboutCompany>> Create(AboutCompany aboutCompany)
        {

            var createdAboutCompany = await aboutCompanyRepository.CreateAsync(aboutCompany);
            if (createdAboutCompany == null)
            {
                return NotFound();
            }
            return Ok(createdAboutCompany);
        }

    }
}
