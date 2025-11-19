using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Core
{
    public static class StringExtensions
    {
        static StringExtensions()
        {
            configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: false, reloadOnChange: true).Build();
        }

        private static IConfiguration? configuration { get; set; }
        public static String? GetValueFor(this String key)
        {
            return configuration?[key];
       }
    }
}
