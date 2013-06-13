namespace Mvc4Application1
{
    public class Utils
    {
        public static string GetImageOrDefault(string imgUrl)
        {
            return string.IsNullOrEmpty(imgUrl) ? "~/Images/Products/NoImage.jpg" : imgUrl;
        }
    }
}