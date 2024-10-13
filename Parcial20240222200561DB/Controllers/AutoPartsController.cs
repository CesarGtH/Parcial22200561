using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Parcial20240222200561DB.Infraestructure.Data;
using Parcial20240222200561DB.Infraestructure.Repositories;

namespace Parcial20240222200561DB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutoPartsController : ControllerBase
    {
        private readonly IAutoPartsRepository _autoPartsRepository;
        public AutoPartsController(IAutoPartsRepository autopartsRepository)
        {
            _autoPartsRepository = autopartsRepository;
        }

        [HttpGet]

        public async Task<IActionResult> GetAutoParts()
        {
            var autoparts = await _autoPartsRepository.GetAutoParts();
            return Ok(autoparts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAutoPartsbyid(int id)
        {
            var autoparts = await _autoPartsRepository.GetAutoPartsbyid(id);
            if (autoparts == null) return NotFound();
            return Ok(autoparts);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AutoParts autoparts)
        {
            int id = await _autoPartsRepository.Insert(autoparts);
            return Ok(id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] AutoParts autoparts)
        {
            if (id != autoparts.Id) return BadRequest();
            var result = await _autoPartsRepository.Update(autoparts);
            if (!result) return BadRequest();
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var result = await _autoPartsRepository.Delete(id);
            if (!result) return BadRequest();
            return Ok(result);
        }


    }
}
