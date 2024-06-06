using date_night_admin.Interfaces;
using date_night_admin.Model;
using Microsoft.AspNetCore.Mvc;

namespace date_night_admin.Controllers
{
    [Route("api/admin/[controller]")]
    [ApiController]
    public class AboutCompanyController : ControllerBase
    {
        private readonly IAboutCompanyRepository _aboutCompany;

        public AboutCompanyController(IAboutCompanyRepository aboutCompany)
        {
            _aboutCompany = aboutCompany;
        }


        [HttpPost]
        public async Task<ActionResult<AboutCompany>> Create(AboutCompany aboutCompany, IFormFile imageFile)
        {

            var createdAboutCompany = await _aboutCompany.CreateAsync(aboutCompany, imageFile);
            return Ok(createdAboutCompany);
        }
    }
}
