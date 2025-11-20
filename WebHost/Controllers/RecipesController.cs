using Microsoft.AspNetCore.Mvc;
using Services;

namespace WebHost.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RecipesController : ControllerBase
    {
        private IConfiguration config;
        private Db01RecipesServices services;
        public RecipesController(IConfiguration pconfig, Db01RecipesServices pservices)
        {
            config = pconfig;
            services = pservices;
        }

        [HttpGet("")]
        public List<DataContracts.Recipe>? GetAll()
        {
            var cs = config["ConnectionStrings:RecipesConnectionString"].ToString();

            return services.GetAll();
            //return Factory.Instance.GetAll();
        }
    }
}
