using CoreApiResponse;
using EnrolledManagementSystem.DTO.Requests;
using EnrolledManagementSystem.Enums;
using EnrolledManagementSystem.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace EnrolledManagementSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NhanVienController : BaseController
    {
        private readonly NhanVienService _service;
        public NhanVienController(NhanVienService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var nhanViens = await _service.GetAll();
                if (nhanViens.Any())
                {
                    return CustomResult(nhanViens, HttpStatusCode.OK);
                }
                return CustomResult(ResponseMessage.EMPTY, HttpStatusCode.NotFound);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("id")]
        public async Task<IActionResult> Details(string id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var nhanVien = await _service.GetById(id);
                    if (nhanVien != null)
                    {
                        return CustomResult(nhanVien, HttpStatusCode.OK);
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
        public async Task<IActionResult> Create(NhanVienCreate nvc)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var nhanVien = await _service.Add(nvc);
                    if (nhanVien == null)
                    {
                        return CustomResult(
                            ResponseMessage.CREATED_SUCCESSFULLY,
                            nvc,
                            HttpStatusCode.Created
                            );
                    }
                    return CustomResult(ResponseMessage.DUPLICATE_KEY, HttpStatusCode.Conflict);
                }
                catch (DbUpdateException db)
                {
                    return CustomResult(ResponseMessage.REFERENCE_ERROR, HttpStatusCode.BadRequest);
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
        public async Task<IActionResult> Update(string id, NhanVienUpdate nvc)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var nhanVien = await _service.Update(id, nvc);
                    if (nhanVien != null)
                    {
                        return CustomResult(
                            ResponseMessage.UPDATED_SUCCESSFULLY,
                            nhanVien,
                            HttpStatusCode.OK);
                    }
                    return CustomResult(ResponseMessage.DATA_NOT_FOUND, HttpStatusCode.NotFound);
                }
                catch (DbUpdateException db)
                {
                    Console.WriteLine(db.Message);
                    return CustomResult(ResponseMessage.REFERENCE_ERROR, HttpStatusCode.BadRequest);
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
        public async Task<IActionResult> Delete(string id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var nhanVien = await _service.Delete(id);
                    if (nhanVien != null)
                    {
                        return CustomResult(ResponseMessage.DELETED_SUCCESSFULLY, HttpStatusCode.OK);
                    }
                    return CustomResult(ResponseMessage.DATA_NOT_FOUND, HttpStatusCode.NotFound);
                }
                catch (DbUpdateException db)
                {
                    Console.WriteLine(db.Message);
                    return CustomResult(ResponseMessage.REFERENCE_ERROR, HttpStatusCode.BadRequest);
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
