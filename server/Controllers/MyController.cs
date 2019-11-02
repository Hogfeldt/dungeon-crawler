using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TestRestAPI.Controllers
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

        // GET: /<number>
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "url value: " + id;
        }

        // POST: 
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: <number>
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: <number>
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
