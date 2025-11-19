using DataContracts;
using ServicesContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Services
{
    public class Xml2RecipesServices : AbstractRecipesServices
    {
        public override List<Recipe> GetAll()
        {
            XDocument doc = XDocument.Load("Recipes.xml");

            return doc.Root!.Elements("recipe").Select(@node => new Recipe()
            {
                Id = Guid.Parse(@node.Attribute("id")!.Value)
                                                                     ,
                Title = @node!.Attribute("title")!.Value
            }).ToList();
        }

        public override List<Recipe> GetByTitle(string title)
        {
            return GetAll().Where(@r => @r.Title.Contains(title)).ToList();
        }
    }
}
