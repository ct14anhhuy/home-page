using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace Utilities
{
    public static class NormalizeString
    {
        public static string ConvertToUnsignAndRemoveEmpty(this string input)
        {
            string fileName = Path.GetFileNameWithoutExtension(input);
            string fileExtension = Path.GetExtension(input);

            Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
            fileName = fileName.Normalize(NormalizationForm.FormD);
            fileName = regex.Replace(fileName, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');
            fileName = fileName.Trim().ToLower();
            fileName = Regex.Replace(fileName, @"\s+", "-");

            string result = fileName + fileExtension;
            return result;
        }
    }
}