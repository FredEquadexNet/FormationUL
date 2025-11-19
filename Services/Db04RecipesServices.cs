using AutoMapper;
using DataContracts;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.IdentityModel.Tokens;
using Services.DataAccessLayer;
using ServicesContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class Db04RecipesServices : AbstractRecipesServices
    {
        public override List<DataContracts.Recipe> GetAll()
        {
            using (var context = new BRecipesContext())
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<DataAccessLayer.Recipe, DataContracts.Recipe>(), NullLoggerFactory.Instance);
                var mapper = new Mapper(config);

                //return context.Recipes.Select(@r => new DataContracts.Recipe() { Id = @r.Id, Title = @r.Title }).ToList();
                return context.Recipes.Select(@r => mapper.Map<DataContracts.Recipe>(r)).ToList();
            }
        }

        public override List<DataContracts.Recipe> GetByTitle(string title)
        {
            using (var context = new BRecipesContext())
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<DataAccessLayer.Recipe, DataContracts.Recipe>(), NullLoggerFactory.Instance);
                var mapper = new Mapper(config);

                //return context.Recipes.Select(@r => new DataContracts.Recipe() { Id = @r.Id, Title = @r.Title }).ToList();
                return context.Recipes.Where(@p => @p.Title.Contains(title)).Select(@r => mapper.Map<DataContracts.Recipe>(r)).ToList();
            }
        }
    }
}
