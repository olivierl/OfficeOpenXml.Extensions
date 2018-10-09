using System;
using System.IO;

namespace OfficeOpenXml.Extensions.Tests
{
    public static class TestHelper
    {
        public static string CurrentProjectPath =>
            GetProjectPath("OfficeOpenXml.Extensions.sln", "tests");

        private static string GetProjectPath(string solutionFileName, string solutionRelativePath)
        {
            var projectName = typeof(TestHelper).Assembly.GetName().Name;
            var applicationBasePath = AppContext.BaseDirectory;
            var directoryInfo = new DirectoryInfo(applicationBasePath);

            do
            {
                var solutionFileInfo = new FileInfo(Path.Combine(directoryInfo.FullName, solutionFileName));
                if (solutionFileInfo.Exists)
                    return Path.GetFullPath(Path.Combine(directoryInfo.FullName, solutionRelativePath, projectName));

                directoryInfo = directoryInfo.Parent;
            } while (directoryInfo.Parent != null);

            throw new Exception($"Solution root could not be located using application root {applicationBasePath}.");
        }
    }
}