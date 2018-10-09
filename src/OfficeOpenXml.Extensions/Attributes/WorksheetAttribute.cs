using System;

namespace OfficeOpenXml.Extensions.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class WorksheetAttribute : Attribute
    {
        public int Index { get; set; }
        public bool HasHeader { get; set; } = true;
    }
}