namespace Sun.PL.Areas.Dashboard.ViewModels
{
    public class ServiceFormVm
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public IFormFile Image { get; set; }
        public string? ImageName {  get; set; }
        public bool IsDeleted { get; set; }
    }
}
