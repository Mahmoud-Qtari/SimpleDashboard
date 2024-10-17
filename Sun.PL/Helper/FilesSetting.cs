namespace Sun.PL.Helper
{
    public class FilesSetting
    {
        public static string UploadFile(IFormFile file,string foulderName)
        {
            string foulderPath = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot\\files\\images",foulderName);
            string fileName = $"{Guid.NewGuid()}{file.FileName}";
            string filePath = Path.Combine(foulderPath,fileName);

            var fileStream = new FileStream(filePath, FileMode.Create);
            file.CopyTo(fileStream);
            return fileName;
        }

        public static void DeleteFile(string fileName,string foulderName)
        {
            string foulderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\files\\images", foulderName, fileName);
            if (File.Exists(foulderPath))
            {
                File.Delete(foulderPath);
            }

        }
    }
}
