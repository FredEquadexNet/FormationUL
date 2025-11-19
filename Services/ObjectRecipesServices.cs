using DataContracts;
using ServicesContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ObjectRecipesServices : AbstractRecipesServices
    {
        public override List<Recipe> GetAll()
        {
            return new List<Recipe>()
            {
                new Recipe() { Id = Guid.NewGuid(), Title = "Object Recipe 01" },
                new Recipe() { Id = Guid.NewGuid(), Title = "Object Recipe 02" },
                new Recipe() { Id = Guid.NewGuid(), Title = "Object Recipe 03" }
            };
        }
    }
}
