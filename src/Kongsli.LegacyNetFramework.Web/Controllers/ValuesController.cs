using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using Kongsli.LegacyNetFramework.Web.Models;

namespace Kongsli.LegacyNetFramework.Web.Controllers
{
    public class ValuesController : ApiController
    {
        private readonly ShortUrlRepository _shortUrlRepository;

        public ValuesController(ShortUrlRepository shortUrlRepository)
        {
            _shortUrlRepository = shortUrlRepository;
        }

        // GET api/values
        public async Task<IEnumerable<ShortUrl>> Get()
        {
            return await _shortUrlRepository.Get();
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
