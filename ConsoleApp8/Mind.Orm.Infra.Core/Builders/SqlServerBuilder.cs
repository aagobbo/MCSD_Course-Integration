using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Mind.Orm.Infra.Core.CustomAttributes;

namespace Mind.Orm.Infra.Core.Builders
{
    public class SqlServerBuilder<T> : IQueryBuilder<T> where T : IEntity
    {
        public string BuildDelete(T instance)
        {
            // ToDo: Implementar
            throw new NotImplementedException();
        }

        public string BuildInsert(T instance, out IDictionary<string, object> parameters)
        {
            // ToDo: Implementar
            throw new NotImplementedException();
        }

        public string BuildSelect()
        {
            var type = typeof(T);
            var select = new StringBuilder();

            var tableAttribute = type.GetCustomAttributes(false).OfType<TableAttribute>();
            var tableName = default(string);

            if (tableAttribute == null)
                tableName = type.Name;
            else
                tableName = tableAttribute.First().Name;

            select.Append("select ");

            var columns = new List<string>();

            foreach (var property in type.GetProperties())
            {
                var column = property.GetCustomAttributes(false).OfType<ColumnAttribute>();

                if (column == null)
                    columns.Add(property.Name);
                else
                    columns.Add(column.First().Name);
            }

            select.Append(string.Join(", ", columns));
            select.Append(" from ");
            select.Append(tableName);

            return select.ToString();
        }

        public string BuildUpdate(T instance)
        {
            // ToDo: Implementar
            throw new NotImplementedException();
        }
    }
}
