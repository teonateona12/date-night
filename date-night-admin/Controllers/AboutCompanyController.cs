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

        [HttpGet]
        public async Task<ActionResult<AboutCompany>> Get()
        {
            var aboutCompany = await aboutCompanyRepository.GetAsync();

            return Ok(aboutCompany);
        }

        [HttpDelete]
        public async Task<ActionResult<AboutCompany>> Remove(int id)
        {
            var information = await aboutCompanyRepository.DeleteAsync(id);
            if (information == null)
            {
                return NotFound();
            }
            return Ok(information);
        }

        [HttpPut]

        public async Task<ActionResult<AboutCompany>> Update (int id, AboutCompany aboutCompany)
        {
            var information = await aboutCompanyRepository.UpdateAsync(id, aboutCompany);

            if(information == null)
            {
                return NotFound();
            }
            return Ok(information);
        }
    }
}
