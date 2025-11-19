using Services.Core;
using ServicesContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public static class Factory
    {
        static Factory()
        {
            var afn = "Settings:AssemblyFileName".GetValueFor();
            var cn = "Settings:ClassName".GetValueFor();

            Instance = Activator.CreateInstance(afn, cn).Unwrap() as AbstractRecipesServices;
        }

        public static AbstractRecipesServices? Instance { get; private set; }
    }
}
