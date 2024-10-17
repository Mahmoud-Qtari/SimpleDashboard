namespace Sun.PL.Areas.Dashboard.ViewModels
{
    public class ProfessionalFormVm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IFormFile Image { get; set; }
        public string positionJob { get; set; }
        public string? ImageName {  get; set; }
        public bool IsDeleted { get; set; }
    }
}
