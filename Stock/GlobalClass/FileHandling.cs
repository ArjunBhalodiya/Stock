using System.IO;

namespace Stock.GlobalClass
{
    public enum FileUploadType
    {
        CompanyDailyData,
        CompanyHistoricalData
    }

    /// <summary>
    /// Perform all file related operation
    /// </summary>
    public class FileHandling
    {
        /// <summary>
        /// Create directory on specified path
        /// </summary>
        /// <param name="path"></param>
        public static void CreateDirectory(string path)
        {
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
        }

        /// <summary>
        /// Check whether specified file is excel or not
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static bool IsExcel(string fileName)
        {
            if (File.Exists(fileName))
                return (string.Compare(Path.GetExtension(fileName), ".xsl") == 0 ||
                    string.Compare(Path.GetExtension(fileName), ".xslx") == 0);
            return false;
        }

        /// <summary>
        /// Check whether specified file is CSV or not
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static bool IsCSV(string fileName)
        {
            if (File.Exists(fileName))
                return string.Compare(Path.GetExtension(fileName), ".csv") == 0;
            return false;
        }

        /// <summary>
        /// Delete file from specified path
        /// </summary>
        /// <param name="fileName"></param>
        public static void DeleteFile(string fileName)
        {
            if (File.Exists(fileName))
                File.Delete(fileName);
        }
    }
}