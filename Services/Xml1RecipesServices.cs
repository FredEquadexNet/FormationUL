using DataContracts;
using ServicesContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Services
{
    public class Xml1RecipesServices : AbstractRecipesServices
    {
        public override List<Recipe> GetAll()
        {
            var recipes = new List<Recipe>();
            var xdoc = new XmlDocument();

            xdoc.Load("Recipes.xml");

            var nodes = xdoc.SelectNodes("/recipes/recipe");

            foreach(XmlNode node in nodes)
            {
                recipes.Add(

                    new Recipe() { Id = Guid.Parse(node.Attributes["id"].Value), Title = node.Attributes["title"].Value }
                    );
            }

            return recipes;
        }

        public override List<Recipe> GetByTitle(string title)
        {
            return GetAll().Where(@r => @r.Title.Contains(title)).ToList();
        }
    }
}
