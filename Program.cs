using Microsoft.Data.Sqlite;
using QueryBuilder.Models;
using System.Reflection;
using System.Text;

namespace QueryBuilder
{
    public class QueryBuilder: IDisposable
    {
        private SqliteConnection connection;
        

        static void Main(string[] args)
        {
            string dbFilePath = @"Data Source=C:\Users\keymp\OneDrive\Documents\ServerSide\Labs\Lab5\QueryBuilder\Data\data.db";

            QueryBuilder qb = new QueryBuilder(dbFilePath);

            using (qb)
            {
                Author a = new Author(99, "Maxwell", "Key");
                //qb.Create<Author>(a);

                Console.WriteLine(qb.Read<Author>(99));

                qb.Delete<Author>(99);

            }



            

        }

       
        //creates connection to sqlite database following filepath
        public QueryBuilder(string locationOfDataBase)
        {
            
            connection = new SqliteConnection(locationOfDataBase);
            connection.Open();
        }

        public T Read<T>(int id) where T : new()
        {
            var command = connection.CreateCommand();
            command.CommandText = $"SELECT * FROM {typeof(T).Name} WHERE ID = {id};";
            using (var reader = command.ExecuteReader())
            {
                T data = new T();

                while(reader.Read())
                {
                    for(int i = 0; i < reader.FieldCount; i++)
                    {
                        var propertyType = typeof(T).GetProperty(reader.GetName(i)).PropertyType;
                        var propertyName = typeof(T).GetProperty(reader.GetName(i));


                        //switching sql default 64bit int values to C# 32bit
                        if(propertyType == typeof(int))
                        {
                            propertyName.SetValue(data, Convert.ToInt32(reader.GetValue(i)));
                        }
                        else
                        {
                            propertyName.SetValue(data, reader.GetValue(i));
                        }
                    }
                }
            return data;
            }
        }

        public List<T>ReadAll<T>() where T : new()
        {
            var command = connection.CreateCommand();
            command.CommandText = $"SELECT * FROM {typeof(T).Name};";
            using (var reader = command.ExecuteReader())
            {
                T data;
                var list = new List<T>();


                while (reader.Read())
                {
                    data = new T();
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        var propertyType = typeof(T).GetProperty(reader.GetName(i)).PropertyType;
                        var propertyName = typeof(T).GetProperty(reader.GetName(i));


                        //switching sql default 64bit int values to C# 32bit
                        if (propertyType == typeof(int))
                        {
                            propertyName.SetValue(data, Convert.ToInt32(reader.GetValue(i)));
                        }
                        else
                        {
                            propertyName.SetValue(data, reader.GetValue(i));
                        }
                    }
                    list.Add(data);
                }
                return list;
            }

        }
        

        //closes connection after using statment is finished
        public void Dispose()
        {
            connection.Close();
        }

        public void Create<T>(T obj)
        {
            // gets properties of objects generically
            PropertyInfo[] properties = typeof(T).GetProperties();

            //get values of properties
            var values = new List<string>();
            var columns = new List<string>();
            PropertyInfo property;

            //loop through collection and assign names/values as lists of strings
            for(int i = 0; i < properties.Length; i++)
            {
                property = properties[i];
                values.Add("\"" + property.GetValue(obj).ToString() + "\"");

                // column names 'must match exactly'
                columns.Add(property.Name);

            }

            StringBuilder sbValues = new StringBuilder();
            StringBuilder sbColumns = new StringBuilder();

            for(int i = 0; i < values.Count; i++)
            {
                if(i ==values.Count-1)
                {
                    sbValues.Append($"{values[i]}");
                    sbColumns.Append($"{columns[i]}");
                }
                else
                {
                    sbValues.Append($"{values[i]}, ");
                    sbColumns.Append($"{columns[i]}, ");
                }
            }

            var command = connection.CreateCommand();

            //optional steps for increased speed
            command.CommandType = System.Data.CommandType.Text;
            command.CommandTimeout = 0;

            command.CommandText = $"INSERT INTO {typeof(T).Name} ({sbColumns}) Values ({sbValues})";
            command.ExecuteNonQuery();

        }

        public void Update<T>(T obj)
        {
            // gets properties of objects generically
            PropertyInfo[] properties = typeof(T).GetProperties();

            //get values of properties
            var values = new List<string>();
            var columns = new List<string>();
            PropertyInfo property;

            StringBuilder sbValues = new StringBuilder();
            StringBuilder sbColumns = new StringBuilder();

            for (int i = 0; i < values.Count; i++)
            {
                if (i == values.Count - 1)
                {
                    sbValues.Append($"{values[i]}");
                    sbColumns.Append($"{columns[i]}");
                }
                else
                {
                    sbValues.Append($"{values[i]}, ");
                    sbColumns.Append($"{columns[i]}, ");
                }
            }

            var command = connection.CreateCommand();

            //optional steps for increased speed
            command.CommandType = System.Data.CommandType.Text;
            command.CommandTimeout = 0;

            command.CommandText = $"UPDATE {typeof(T).Name} SET ({sbColumns}) = Values ({sbValues})";
            command.ExecuteNonQuery();

        }

        public void Delete<T>(int id) where T : IClassModel
        {
            var command = connection.CreateCommand();
            command.CommandText = $"DELETE FROM {typeof(T).Name} WHERE ID = {id};";
            command.ExecuteNonQuery();
        }
    }
}