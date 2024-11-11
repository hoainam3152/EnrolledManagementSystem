using CoreApiResponse;
using EnrolledManagementSystem.Entities;
using EnrolledManagementSystem.Enums;
using EnrolledManagementSystem.Models;
using EnrolledManagementSystem.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EnrolledManagementSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoaiDiemController : BaseController
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
                    
                    return CustomResult(loaiDiemList, HttpStatusCode.OK);
                }
                return CustomResult(ResponeMessage.EMPTY, HttpStatusCode.NotFound);
                //return loaiDiemList == null ? NotFound() : Ok(loaiDiemList);
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
                    var loaiDiem = await _service.GetByID(id);
                    if (loaiDiem != null)
                    {
                        return CustomResult(loaiDiem, HttpStatusCode.OK);
                    }
                    return CustomResult(ResponeMessage.DATA_NOT_FOUND, HttpStatusCode.NotFound);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            } else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(LoaiDiemCreate ld)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var loaiDiem = await _service.Add(ld);
                    if (loaiDiem == null)
                    {
                        return CustomResult(
                            ResponeMessage.CREATED_SUCCESSFULLY,
                            ld,
                            HttpStatusCode.Created
                            );
                    }
                    return CustomResult(ResponeMessage.DUPLICATE_KEY, HttpStatusCode.Conflict);
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
        public async Task<IActionResult> Update(string id, LoaiDiemUpdate ld)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var loaiDiem = await _service.Update(id, ld);
                    if (loaiDiem != null)
                    {
                        return CustomResult(
                            ResponeMessage.UPDATED_SUCCESSFULLY, 
                            loaiDiem,
                            HttpStatusCode.OK);
                    }
                    return CustomResult(ResponeMessage.DATA_NOT_FOUND, HttpStatusCode.NotFound);
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
                    var loaiDiem = await _service.Delete(id);
                    if (loaiDiem != null)
                    {
                        return CustomResult(ResponeMessage.DELETED_SUCCESSFULLY, HttpStatusCode.OK);
                    }
                    return CustomResult(ResponeMessage.DATA_NOT_FOUND, HttpStatusCode.NotFound);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            } else
            {
                return BadRequest(ModelState);
            }
        }
    }
}
