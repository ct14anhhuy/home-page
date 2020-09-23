using System;
using System.IO;
using System.Web;

namespace Utilities
{
    public static class FileService
    {
        public static void SaveFile(HttpPostedFileBase file, string path)
        {
            try
            {
                file.SaveAs(path);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void RemoveFile(string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
