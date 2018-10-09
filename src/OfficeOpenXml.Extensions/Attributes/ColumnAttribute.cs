using System;

namespace OfficeOpenXml.Extensions.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ColumnAttribute : Attribute
    {
        public int Number { get; set; }
    }
}