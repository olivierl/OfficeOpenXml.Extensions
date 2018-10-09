using System.IO;
using System.Linq;
using OfficeOpenXml;
using OfficeOpenXml.Extensions.Tests.Fixtures;
using Xunit;

namespace OfficeOpenXml.Extensions.Tests
{
    public class ExcelPackageExtensionsTests
    {
        private readonly string _fixturesPath = Path.Combine(TestHelper.CurrentProjectPath, "Fixtures");
        
        private string GetFilePath(string fileName)
        {
            return Path.Combine(_fixturesPath, fileName);
        }
        
        [Fact]
        public void ParseWorksheet_ReturnsTodoRows()
        {
            var excelFilePath = GetFilePath("Todos.xlsx");
            var fileStream = new FileStream(excelFilePath, FileMode.Open);
            using (var excelPackage = new ExcelPackage(fileStream))
            {
                var todoRows = excelPackage.ParseWorksheet<TodoRow>().ToList();
                
                Assert.Equal(3, todoRows.Count);
                
                var todo1 = todoRows[0];
                Assert.Equal(0, todo1.Id);
                Assert.Equal("Make TDs", todo1.Title);
                Assert.Equal(3, todo1.Priority);
                Assert.False(todo1.Completed);
                
                var todo2 = todoRows[1];
                Assert.Equal(0, todo2.Id);
                Assert.Equal("Do code reviews", todo2.Title);
                Assert.Equal(2, todo2.Priority);
                Assert.False(todo2.Completed);
                
                var todo3 = todoRows[2];
                Assert.Equal(0, todo3.Id);
                Assert.Equal("Take holidays", todo3.Title);
                Assert.Equal(1, todo3.Priority);
                Assert.True(todo3.Completed);
            }
        }
        
        [Fact]
        public void ParseWorksheet_ReturnsProjectRows()
        {
            var excelFilePath = GetFilePath("Projects.xlsx");
            var fileStream = new FileStream(excelFilePath, FileMode.Open);
            using (var excelPackage = new ExcelPackage(fileStream))
            {
                var projectRows = excelPackage.ParseWorksheet<ProjectRow>().ToList();
                
                Assert.Equal(2, projectRows.Count);
                
                var project1 = projectRows[0];
                Assert.Equal(1, project1.Id);
                Assert.Equal("MyHRW", project1.Name);
                Assert.Equal("Case Management Tool", project1.Description);
                
                var project2 = projectRows[1];
                Assert.Equal(2, project2.Id);
                Assert.Equal("PEX", project2.Name);
                Assert.Equal("Global Payroll Exchange", project2.Description);
            }
        }
    }
}