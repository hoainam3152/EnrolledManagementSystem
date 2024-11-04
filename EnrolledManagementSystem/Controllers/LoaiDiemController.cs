using EnrolledManagementSystem.Models;
using EnrolledManagementSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace EnrolledManagementSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoaiDiemController : Controller
    {
        private readonly LoaiDiemService _service;

        public LoaiDiemController(LoaiDiemService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var loaiDiemList = await _service.GetAll();
                if (loaiDiemList != null)
                {
                    return Ok(loaiDiemList);
                }
                return NotFound();
                //return loaiDiemList == null ? NotFound() : Ok(loaiDiemList);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("id")]
        public async Task<IActionResult> Details(string id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var loaiDiem = await _service.GetByID(id);
                    if (loaiDiem != null)
                    {
                        return Ok(loaiDiem);
                    }
                    return NotFound();
                }
                catch
                {
                    return BadRequest();
                }
            } else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(LoaiDiemModel ld)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var loaiDiem = await _service.Add(ld);
                    if (loaiDiem == null)
                    {
                        return StatusCode(StatusCodes.Status201Created, loaiDiem);
                    }
                    return BadRequest("Loại điểm đã tồn tại trong hệ thống");
                }
                catch
                {
                    return BadRequest();
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPut("id")]
        public async Task<IActionResult> Details(string id, LoaiDiemModel ld)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var loaiDiem = await _service.Update(id, ld);
                    if (loaiDiem != null)
                    {
                        return NoContent();
                    }
                    return NotFound();
                }
                catch
                {
                    return BadRequest();
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpDelete("id")]
        public async Task<IActionResult> Delete(string id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var loaiDiem = await _service.Delete(id);
                    if (loaiDiem != null)
                    {
                        return NoContent();
                    }
                    return Ok();
                }
                catch
                {
                    return BadRequest();
                }
            } else
            {
                return BadRequest(ModelState);
            }
        }
    }
}
