﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SehirRehberiAPI.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Routing;

namespace SehirRehberiAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private DataContext _context;
        public ValuesController(DataContext context)
        {
            _context = context;
        }
        // GET api/values
        [HttpGet]
        public async Task<ActionResult> GetValues()
        {
            var values = await _context.Values.ToListAsync();
            return Ok(values);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var value = await _context.Values.FirstOrDefaultAsync(v => v.Id == id);
            return Ok(value);
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
}
