namespace Sun.PL.Areas.Dashboard.ViewModels
{
    public class ProfessionalDetailsVm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string positionJob { get; set; }
        public string ImageName { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
