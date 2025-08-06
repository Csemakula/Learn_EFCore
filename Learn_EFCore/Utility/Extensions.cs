using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Learn_EFCore.Utility
{
    public static class Extensions
    {
        private static readonly ConcurrentDictionary<Type, PropertyInfo[]> _propertyCache =
        new ConcurrentDictionary<Type, PropertyInfo[]>();

        public static DataTable ToDataTable<T>(this List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);

            // Get properties of T
            // PropertyInfo[] properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            // Get properties from cache or reflection
            Type type = typeof(T);
            PropertyInfo[] properties = _propertyCache.GetOrAdd(
                key: type,
                valueFactory: t => t.GetProperties(BindingFlags.Public | BindingFlags.Instance)
            );

            // Create columns
            foreach (PropertyInfo prop in properties)
            {
                // Determine column type (handle nullable types)
                Type columnType = Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType;
                dataTable.Columns.Add(prop.Name, columnType);
            }

            // Add rows
            foreach (T item in items)
            {
                DataRow row = dataTable.NewRow();
                foreach (PropertyInfo prop in properties)
                {
                    object value = prop.GetValue(item, null) ?? DBNull.Value;
                    row[prop.Name] = value;
                }
                dataTable.Rows.Add(row);
            }

            return dataTable;
        }
    }
}
