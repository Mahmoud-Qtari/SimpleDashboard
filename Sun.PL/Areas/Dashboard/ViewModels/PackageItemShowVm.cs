using Microsoft.AspNetCore.Mvc.Rendering;
using Sun.DAL.Models;

namespace Sun.PL.Areas.Dashboard.ViewModels
{
    public class PackageItemShowVm
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public int? PackageId { get; set; }
        public bool IsDeleted { get; set; }
    }
}
