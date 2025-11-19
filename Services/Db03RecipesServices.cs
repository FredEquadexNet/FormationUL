using DataContracts;
using Microsoft.Data.SqlClient;
using Services.Core;
using ServicesContracts;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class Db03RecipesServices : AbstractRecipesServices
    {
        public override List<Recipe> GetAll()
        {
            var recipes = new List<Recipe>();

            var factory = SqlClientFactory.Instance;

            using (var cn = factory.CreateConnection())
            {
                cn.ConnectionString = "ConnectionStrings:RecipesConnectionString".GetValueFor();

                cn.Open();

                var cmd = cn.CreateCommand();

                cmd.CommandText = "sSelectRecipes";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    recipes.Add(new Recipe() { Id = Guid.Parse(reader["id"].ToString()), Title = reader["title"].ToString() });
                }
            }

            return recipes;
        }

        public override List<Recipe> GetByTitle(string title)
        {
            var recipes = new List<Recipe>();

            var factory = SqlClientFactory.Instance;

            using (var cn = factory.CreateConnection())
            {
                cn.ConnectionString = "ConnectionStrings:RecipesConnectionString".GetValueFor();

                cn.Open();

                var cmd = cn.CreateCommand();

                cmd.CommandText = "sSelectRecipes";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                if (!String.IsNullOrEmpty(title))
                {
                    var param = cmd.CreateParameter();
                    param.ParameterName = "@title";
                    param.Value = title;

                    cmd.Parameters.Add(param);
                }

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    recipes.Add(new Recipe() { Id = Guid.Parse(reader["id"].ToString()), Title = reader["title"].ToString() });
                }
            }

            return recipes;
        }
    }
}

