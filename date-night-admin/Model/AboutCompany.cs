﻿using System.ComponentModel.DataAnnotations.Schema;

namespace date_night_admin.Model
{
    public class AboutCompany
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageFileName { get; set; }

    }
}
