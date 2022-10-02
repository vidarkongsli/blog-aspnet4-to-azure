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

        // GET api/values/vg
        public async Task<IHttpActionResult> Get(string id)
        {
            var content = await _shortUrlRepository.Get(id);
            if (content == null) return NotFound();
            return Ok(content);
        }

        // GET api/values
        public async Task<IEnumerable<ShortUrl>> Get()
        {
            return await _shortUrlRepository.Get();
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
