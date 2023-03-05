using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HoloHouse.Web.Data;
using HoloHouse.Web.Data.Entities;

namespace HoloHouse.Web.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyTypesController : ControllerBase
    {
        private readonly DataContext _context;

        public PropertyTypesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/PropertyTypes
        [HttpGet]
        public IEnumerable<PropertyType> GetPropertyTypes()
        {
            return _context.PropertyTypes.OrderBy(pt => pt.Name);
        }

        // GET: api/PropertyTypes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPropertyType([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var propertyType = await _context.PropertyTypes.FindAsync(id);

            if (propertyType == null)
            {
                return NotFound();
            }

            return Ok(propertyType);
        }

        // PUT: api/PropertyTypes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPropertyType([FromRoute] int id, [FromBody] PropertyType propertyType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != propertyType.Id)
            {
                return BadRequest();
            }

            _context.Entry(propertyType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PropertyTypeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/PropertyTypes
        [HttpPost]
        public async Task<IActionResult> PostPropertyType([FromBody] PropertyType propertyType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.PropertyTypes.Add(propertyType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPropertyType", new { id = propertyType.Id }, propertyType);
        }

        // DELETE: api/PropertyTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePropertyType([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var propertyType = await _context.PropertyTypes.FindAsync(id);
            if (propertyType == null)
            {
                return NotFound();
            }

            _context.PropertyTypes.Remove(propertyType);
            await _context.SaveChangesAsync();

            return Ok(propertyType);
        }

        private bool PropertyTypeExists(int id)
        {
            return _context.PropertyTypes.Any(e => e.Id == id);
        }
    }
}