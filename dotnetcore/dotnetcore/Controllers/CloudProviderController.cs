using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace dotnetcore.Controllers
{
    [Route("api/cloudprovider")]
    [ApiController]
    public class CloudProviderController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<CloudProvider>> Get()
        {
            return new CloudProvider[] {
                new CloudProvider{Id=1,Name="Amazon Web Services (AWS)"},
                new CloudProvider{Id=2,Name="Microsoft Azure",},
                new CloudProvider{Id=3,Name="Google Cloud",},
                new CloudProvider{Id=4,Name="Alibaba Cloud",},
                new CloudProvider{Id=5,Name="IBM Cloud",},
                new CloudProvider{Id=6,Name="Digital Ocean",},
                new CloudProvider{Id=7,Name="Rackspace",},
                new CloudProvider{Id=8,Name="Massive Grid",},
            };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
    public class CloudProvider
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
