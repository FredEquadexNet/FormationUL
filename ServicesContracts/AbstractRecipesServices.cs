using DataContracts;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesContracts
{
    public abstract class AbstractRecipesServices
    {
        protected List<Recipe> getInternalRecipes(String commandText, System.Data.CommandType commandType, String connectionString, String? title = null)
        {
            var recipes = new List<Recipe>();

            var cs = connectionString;
            using (var cn = new SqlConnection(cs))
            {
                cn.Open();

                var cmd = cn.CreateCommand();
                cmd.CommandText = commandText;
                cmd.CommandType = commandType;

                if (!String.IsNullOrEmpty(title))
                {
                    cmd.Parameters.AddWithValue("@title", title);
                }

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    recipes.Add(new Recipe() { Id = Guid.Parse(reader["id"].ToString()), Title = reader["title"].ToString() });
                }
            }

            return recipes;

        }

        public abstract List<Recipe> GetAll();

        public abstract List<Recipe> GetByTitle(String title);
    }
}
