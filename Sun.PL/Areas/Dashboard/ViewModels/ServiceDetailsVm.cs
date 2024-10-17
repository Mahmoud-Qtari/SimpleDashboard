namespace Sun.PL.Areas.Dashboard.ViewModels
{
    public class ServiceDetailsVm
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ImageName { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
