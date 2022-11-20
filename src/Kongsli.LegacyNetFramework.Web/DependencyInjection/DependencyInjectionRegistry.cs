using System.Configuration;
using Microsoft.Data.SqlClient;
using StructureMap;

namespace Kongsli.LegacyNetFramework.Web.DependencyInjection
{
    public class DependencyInjectionRegistry : Registry
    {
        public DependencyInjectionRegistry()
        {
            var defaultConnectionString = ConfigurationManager
                .ConnectionStrings["default"].ConnectionString;
            For<IShortUrlDatabase>().Use(
                ctx => new ShortUrlDatabase(new SqlConnection(defaultConnectionString)))
                .Transient();
        }
    }
}
