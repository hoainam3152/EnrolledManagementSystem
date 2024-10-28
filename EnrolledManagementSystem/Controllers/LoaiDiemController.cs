using EnrolledManagementSystem.Entities;
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
                return Ok(loaiDiemList);
            }
            catch 
            {
                return BadRequest();
            }
        }
    }
}
