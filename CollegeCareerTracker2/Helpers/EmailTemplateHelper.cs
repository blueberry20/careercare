using System.IO;

namespace CollegeCareerTracker2.Helpers
{
    public static class EmailTemplateHelper
    {
        public static string GetTemplate(string name)
        {
            string filepath = System.Web.HttpContext.Current.Server.MapPath("\\content\\emails\\" + name + ".htm");
            string content = string.Empty;

            using (var stream = new StreamReader(filepath))
            {
                content = stream.ReadToEnd();
            }
            return content;
        }
    }
}