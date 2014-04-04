namespace Andriy.Mvc4Application1
{
    public class Consts
    {
        public const int CategoriesPerPage = 10;
        public const int ProductsPerPage = 12;

        public const string DisplayImageURLDefault = "/Images/Products/NoImage.jpg";
        public const string UploadPath = "~/Uploads";
        public const string LogDir = "~/Logs";
        public const string AdminRoleName = "admin";

        public static readonly string[] ImageExtensions = { "jpg", "jpeg", "png" };
        public static readonly string[] PlainTextExtensions = { "txt", "log", "resources" };
    }
}