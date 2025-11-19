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
    public class Db02RecipesServices : AbstractRecipesServices
    {
        public override List<Recipe> GetAll()
        {
            var cs = "ConnectionStrings:RecipesConnectionString".GetValueFor();

            return getInternalRecipes("sSelectRecipes", System.Data.CommandType.StoredProcedure, cs);
        }
    }
}

