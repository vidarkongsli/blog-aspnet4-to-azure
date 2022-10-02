using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Kongsli.LegacyNetFramework.Web.Models;

namespace Kongsli.LegacyNetFramework.Web
{
    public class ShortUrlRepository
    {
        private readonly IDbConnection _connection;
        public ShortUrlRepository(IShortUrlDatabase shortUrlDatabase)
        {
            _connection = shortUrlDatabase.Connection;
        }

        public async Task<ICollection<ShortUrl>> Get()
        {
            var shortUrls = await _connection.QueryAsync<ShortUrl>("");
            return shortUrls.ToList();
        }
    }

    public interface IShortUrlDatabase
    {
        IDbConnection Connection { get; }
    }

    public class ShortUrlDatabase : IShortUrlDatabase
    {
        public ShortUrlDatabase(IDbConnection dbConnection)
        {
            Connection = dbConnection;
        }

        public IDbConnection Connection { get; }
    }
}