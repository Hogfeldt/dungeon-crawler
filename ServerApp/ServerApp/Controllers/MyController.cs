using Microsoft.AspNetCore.Mvc;

namespace ServerApp.Controllers
{
    [Route("")]
    [ApiController]
    public class MyController : ControllerBase
    {
        // GET: 
        [HttpGet]
        public string Get()
        {
            return "<h1>Hello, proj4-World!</h1>";
        }

        // GET: /test
        [HttpGet("/test")]
        public IActionResult Get(string hello)
        {
            var content = "<html><body><h1>Hello World</h1><p>Some text</p></body></html>";

            return new ContentResult()
            {
                Content = content,
                ContentType = "text/html",
            };
        }

        // GET: api/My/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "url value: " + id;
        }

        // POST: api/My
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/My/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
