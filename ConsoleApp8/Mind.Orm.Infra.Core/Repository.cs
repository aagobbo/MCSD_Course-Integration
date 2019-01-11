using Mind.Orm.Infra.Core.Builders;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;

namespace Mind.Orm.Infra.Core
{
    public class Repository<T> where T : IEntity
    {
        private string connectionString;
        private DbProviderFactory factory;
        private IQueryBuilder<T> builder;

        public Repository(IQueryBuilder<T> builder)
        {
            this.builder = builder;
            this.connectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
            this.factory = DbProviderFactories.GetFactory(ConfigurationManager.ConnectionStrings["conn"].ProviderName);
        }

        /// <summary>
        /// Terminar de implementar
        /// </summary>
        /// <param name="instance"></param>
        public void Insert(T instance)
        {
            var connection = this.factory.CreateConnection();
            connection.ConnectionString = this.connectionString;

            var command = connection.CreateCommand();

            IDictionary<string, object> parameters = new Dictionary<string, object>();
            command.CommandText = this.builder.BuildInsert(instance, out parameters);

            foreach (var parameter in parameters)
            {
                var newParameter = command.CreateParameter();

                newParameter.ParameterName = parameter.Key;
                newParameter.Value = parameter.Value;

                command.Parameters.Add(newParameter);
            }

            try
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }

        }

        public IEnumerable<T> SelectAll()
        {
            var connection = this.factory.CreateConnection();
            connection.ConnectionString = this.connectionString;

            var command = connection.CreateCommand();

            command.CommandText = this.builder.BuildSelect();

            try
            {
                connection.Open();

                var reader = command.ExecuteReader();
                var instances = new List<T>();

                while (reader.Read())
                {
                    var instance = (T)typeof(T).GetConstructor(new Type[] { }).Invoke(new object[] { });

                    foreach (var property in instance.GetType().GetProperties())
                    {
                        property.SetValue(instance, reader[property.Name]);
                    }
                    instances.Add(instance);
                }

                return instances;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }

        }

    }
}
