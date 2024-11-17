using CoreApiResponse;
using EnrolledManagementSystem.DTO.Requests;
using EnrolledManagementSystem.DTO.Responses;
using EnrolledManagementSystem.Enums;
using EnrolledManagementSystem.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace EnrolledManagementSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PhieuLuongNhanVienController : BaseController
    {
        private readonly PhieuLuongService _service;
        public PhieuLuongNhanVienController(PhieuLuongService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var phieuLuongs = await _service.GetAll();
                if (phieuLuongs.Any())
                {
                    return CustomResult(phieuLuongs, HttpStatusCode.OK);
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
                    var phieuLuong = await _service.GetById(id);
                    if (phieuLuong != null)
                    {
                        return CustomResult(phieuLuong, HttpStatusCode.OK);
                    }
                    return CustomResult(ResponseMessage.EMPTY, HttpStatusCode.NotFound);
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
        public async Task<IActionResult> Create(PhieuLuongCreate pl)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var phieuLuong = await _service.Add(pl);
                    return CustomResult(
                        ResponseMessage.CREATED_SUCCESSFULLY,
                        phieuLuong,
                        HttpStatusCode.Created
                        );
                }
                catch (DbUpdateException db)
                {
                    return CustomResult(db.Message, HttpStatusCode.InternalServerError);
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
        public async Task<IActionResult> Update(int id, PhieuLuongUpdate pl)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var phieuLuong = await _service.Update(id, pl);
                    if (phieuLuong != null)
                    {
                        return CustomResult(
                            ResponseMessage.UPDATED_SUCCESSFULLY,
                            phieuLuong,
                            HttpStatusCode.OK);
                    }
                    return CustomResult(ResponseMessage.DATA_NOT_FOUND, HttpStatusCode.NotFound);
                }
                catch (DbUpdateException db)
                {
                    return CustomResult(db.Message, HttpStatusCode.InternalServerError);
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
                    var phieuLuong = await _service.Delete(id);
                    if (phieuLuong != null)
                    {
                        return CustomResult(ResponseMessage.DELETED_SUCCESSFULLY, HttpStatusCode.OK);
                    }
                    return CustomResult(ResponseMessage.DATA_NOT_FOUND, HttpStatusCode.NotFound);
                }
                catch (DbUpdateException db)
                {
                    return CustomResult(db.Message, HttpStatusCode.InternalServerError);
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
