namespace Sun.PL.Areas.Dashboard.ViewModels
{
    public class PackageDetailsVm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
