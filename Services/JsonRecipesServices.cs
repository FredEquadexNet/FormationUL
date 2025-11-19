using DataContracts;
using Newtonsoft.Json;
using ServicesContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Services
{
    public class JsonRecipesServices : AbstractRecipesServices
    {
        public override List<Recipe> GetAll()
        {
            var json = File.ReadAllText("recipes.json");
            return JsonConvert.DeserializeObject<List<Recipe>>(json)!;
        }

        public override List<Recipe> GetByTitle(string title)
        {
            return GetAll().Where(@r => @r.Title.Contains(title)).ToList();
        }
    }
}
