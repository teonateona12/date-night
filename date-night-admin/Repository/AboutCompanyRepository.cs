using date_night_admin.Data;
using date_night_admin.Interfaces;
using date_night_admin.Model;
using Microsoft.EntityFrameworkCore;

namespace date_night_admin.Repository
{
    public class AboutCompanyRepository : IAboutCompanyRepository
    {
        private readonly DataContext _context;
        private readonly string _imageFolderPath;

        public AboutCompanyRepository(DataContext context)
        {
            _context = context;
            _imageFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");

            if (!Directory.Exists(_imageFolderPath))
            {
                Directory.CreateDirectory(_imageFolderPath);
            }
        }
        public async Task<AboutCompany> CreateAsync(AboutCompany aboutCompany, IFormFile imageFile)
        {
            if (imageFile != null)
            {
                var fileName = Path.GetFileNameWithoutExtension(imageFile.FileName) + "_" + Path.GetRandomFileName() + Path.GetExtension(imageFile.FileName);
                var filePath = Path.Combine(_imageFolderPath, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await imageFile.CopyToAsync(stream);
                }

                aboutCompany.ImageFileName = fileName;
            }

            _context.AboutCompany.Add(aboutCompany);
            await _context.SaveChangesAsync();
            return aboutCompany;
        }
    }
}
