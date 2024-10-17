﻿namespace Sun.PL.Areas.Dashboard.ViewModels
{
    public class AboutFormVm
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public IFormFile Image { get; set; }
        public string? ImageName {  get; set; }
        public bool IsDeleted { get; set; }
    }
}