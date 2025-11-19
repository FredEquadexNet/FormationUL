using DataContracts;
using Microsoft.Data.SqlClient;
using Services.Core;
using ServicesContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class Db01RecipesServices : AbstractRecipesServices
    {
        public override List<Recipe> GetAll()
        {
            var recipes = new List<Recipe>();

            var cs = "ConnectionStrings:RecipesConnectionString".GetValueFor();
            using (var cn = new SqlConnection(cs))
            {
                cn.Open();

                var cmd = cn.CreateCommand();
                cmd.CommandText = "SELECT * FROM Recipes";

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

