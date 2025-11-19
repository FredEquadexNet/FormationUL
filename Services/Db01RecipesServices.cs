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
            var cs = "ConnectionStrings:RecipesConnectionString".GetValueFor();

            return getInternalRecipes("SELECT * FROM Recipes", System.Data.CommandType.Text, cs);
        }

        public override List<Recipe> GetByTitle(string title)
        {
            var cs = "ConnectionStrings:RecipesConnectionString".GetValueFor();

            return getInternalRecipes($"SELECT * FROM Recipes WHERE title LIKE '%{title}%'", System.Data.CommandType.Text, cs);
        }
    }
}

