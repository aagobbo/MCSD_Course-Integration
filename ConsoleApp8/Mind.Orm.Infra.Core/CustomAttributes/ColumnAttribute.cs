using System;

namespace Mind.Orm.Infra.Core.CustomAttributes
{
    public enum ColumnType
    {
        Text,
        Number,
        DateTime
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class ColumnAttribute : Attribute
    {
        public string Name { get; set; }
        public ColumnType CustomType { get; set; }
        public int Length { get; set; }

        public ColumnAttribute(string name, ColumnType customType, int length)
        {
            this.Name = name;
            this.CustomType = customType;
            this.Length = length;
        }
    }
}
