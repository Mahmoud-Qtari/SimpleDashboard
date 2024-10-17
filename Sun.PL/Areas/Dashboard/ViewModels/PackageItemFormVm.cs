using Microsoft.AspNetCore.Mvc.Rendering;

namespace Sun.PL.Areas.Dashboard.ViewModels
{
    public class PackageItemFormVm
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public IFormFile Image { get; set; }
        public string? ImageName {  get; set; }
        public bool IsDeleted { get; set; }

        public int? PackageId { get; set; }
        public SelectList? packagesList { get; set; }

    }
}
