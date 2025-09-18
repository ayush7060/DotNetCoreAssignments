using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.Design;
using TodoApp.Model;
using TodoApp.Services;

namespace TodoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MerchantController : ControllerBase
    {
        private readonly List<Merchant> _merchant = new List<Merchant>();
        private int _nextincrementId = 1;
        private readonly IMerchantServices _service;

        public MerchantController(IMerchantServices service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("AddMerchant")]
        [ProducesResponseType(typeof(Merchant), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Merchant> Create([FromBody] Merchant merchant)
        {

            var created = _service.Add(merchant);
            //return CreatedAtAction(nameof(Create), new { id = created.Id }, created);
            //return Ok(created);
            return Ok(merchant);
        }


        [HttpGet]
        [Route("GetMerchant")]
        [ProducesResponseType(typeof(IEnumerable<Merchant>), StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<Merchant>> GetAll()
        {
            var data = _service.GetAll();
            //return Ok(data);
            return Ok(data);
        }


        [HttpGet]
        [Route("GetMerchantById/{id}")]
        [ProducesResponseType(typeof(Merchant), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Merchant> GetMerchantById(int id)
        {
            var Merchant = _service.GetById(id);
            if (Merchant == null)
                return NotFound();
            
                
            return Ok(Merchant);
        }

        [HttpDelete]
        [Route("DeleteMerchantbyId/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteMerchantbyId(int id)
        {
            var deleted = _service.Delete(id);
            if (!deleted) return NotFound();
            return NoContent();
        }


        [HttpPut]
        [Route("Update/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Update(int id, [FromBody] Merchant merchant)
        {
            var updated = _service.Update(id, merchant);
            if (!updated) return NotFound();
            return NoContent();
        }
    }
}
