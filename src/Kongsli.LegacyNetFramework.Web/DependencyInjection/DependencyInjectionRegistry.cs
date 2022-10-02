using System.Data.SqlClient;
using StructureMap;

namespace Kongsli.LegacyNetFramework.Web.DependencyInjection
{
    public class DependencyInjectionRegistry : Registry
    {
        public DependencyInjectionRegistry()
        {
            For<IShortUrlDatabase>().Use(ctx => new ShortUrlDatabase(new SqlConnection())).Transient();
        }
    }
}
