using CoreApiResponse;
using EnrolledManagementSystem.DTO.Requests;
using EnrolledManagementSystem.Enums;
using EnrolledManagementSystem.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace EnrolledManagementSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NguoiDungController : BaseController
    {
        private readonly NguoiDungService _service;
        public NguoiDungController(NguoiDungService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var nguoiDungs = await _service.GetAll();
                if (nguoiDungs.Any())
                {
                    return CustomResult(nguoiDungs, HttpStatusCode.OK);
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
                    var nguoiDung = await _service.GetById(id);
                    if (nguoiDung != null)
                    {
                        return CustomResult(nguoiDung, HttpStatusCode.OK);
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
        public async Task<IActionResult> Create(NguoiDungCreate nvc)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var nguoiDung = await _service.Add(nvc);
                    if (nguoiDung == null)
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
        public async Task<IActionResult> Update(string id, NguoiDungUpdate nvc)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var nguoiDung = await _service.Update(id, nvc);
                    if (nguoiDung != null)
                    {
                        return CustomResult(
                            ResponseMessage.UPDATED_SUCCESSFULLY,
                            nguoiDung,
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
                    var nguoiDung = await _service.Delete(id);
                    if (nguoiDung != null)
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
