using CoreApiResponse;
using EnrolledManagementSystem.DTO.Requests;
using EnrolledManagementSystem.Enums;
using EnrolledManagementSystem.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EnrolledManagementSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChucVuController : BaseController
    {
        private readonly ChucVuService _service;

        public ChucVuController(ChucVuService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var chucVus = await _service.GetAll();
                if (chucVus.Any())
                {
                    return CustomResult(chucVus, HttpStatusCode.OK);
                }
                return CustomResult(ResponseMessage.EMPTY, HttpStatusCode.NotFound);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("id")]
        public async Task<IActionResult> Details(int id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var chucVu = await _service.GetById(id);
                    if (chucVu != null)
                    {
                        return CustomResult(chucVu, HttpStatusCode.OK);
                    }
                    return CustomResult(ResponseMessage.DATA_NOT_FOUND, HttpStatusCode.NotFound);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(ChucVuRequest cv)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var chucVu = await _service.Add(cv);
                    return CustomResult(
                        ResponseMessage.CREATED_SUCCESSFULLY,
                        chucVu,
                        HttpStatusCode.Created
                        );
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPut("id")]
        public async Task<IActionResult> Update(int id, ChucVuRequest cv)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var chucVu = await _service.Update(id, cv);
                    if (chucVu != null)
                    {
                        return CustomResult(
                            ResponseMessage.UPDATED_SUCCESSFULLY,
                            chucVu,
                            HttpStatusCode.OK);
                    }
                    return CustomResult(ResponseMessage.DATA_NOT_FOUND, HttpStatusCode.NotFound);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpDelete("id")]
        public async Task<IActionResult> Delete(int id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var chucVu = await _service.Delete(id);
                    if (chucVu != null)
                    {
                        return CustomResult(ResponseMessage.DELETED_SUCCESSFULLY, HttpStatusCode.OK);
                    }
                    return CustomResult(ResponseMessage.DATA_NOT_FOUND, HttpStatusCode.NotFound);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}
