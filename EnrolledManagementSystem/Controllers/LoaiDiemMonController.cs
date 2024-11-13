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
    public class LoaiDiemMonController : BaseController
    {
        private readonly LoaiDiemMonService _service;
        public LoaiDiemMonController(LoaiDiemMonService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var loaiDiemMons = await _service.GetAll();
                if (loaiDiemMons.Any())
                {
                    return CustomResult(loaiDiemMons, HttpStatusCode.OK);
                }
                return CustomResult(ResponseMessage.EMPTY, HttpStatusCode.NotFound);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Detail")]
        public async Task<IActionResult> Details(string maKhoa, string maMon, string maLoai)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var loaiDiemMon = await _service.GetById(maKhoa, maMon, maLoai);
                    if (loaiDiemMon != null)
                    {
                        return CustomResult(loaiDiemMon, HttpStatusCode.OK);
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
        public async Task<IActionResult> Create(LoaiDiemMonCreate ldm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var loaiDiemMon = await _service.Add(ldm);
                    if (loaiDiemMon == null)
                    {
                        return CustomResult(
                            ResponseMessage.CREATED_SUCCESSFULLY,
                            ldm,
                            HttpStatusCode.Created
                            );
                    }
                    return CustomResult(ResponseMessage.DUPLICATE_KEY, HttpStatusCode.Conflict);
                }
                catch (DbUpdateException)
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
        public async Task<IActionResult> Update(string maKhoa, string maMon, string maLoai, LoaiDiemMonUpdate ldm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var loaiDiemMon = await _service.Update(maKhoa, maMon, maLoai, ldm);
                    if (loaiDiemMon != null)
                    {
                        return CustomResult(
                            ResponseMessage.UPDATED_SUCCESSFULLY,
                            loaiDiemMon,
                            HttpStatusCode.OK);
                    }
                    return CustomResult(ResponseMessage.DATA_NOT_FOUND, HttpStatusCode.NotFound);
                }
                catch (DbUpdateException)
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

        [HttpDelete("id")]
        public async Task<IActionResult> Delete(string maKhoa, string maMon, string maLoai)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var loaiDiemMon = await _service.Delete(maKhoa, maMon, maLoai);
                    if (loaiDiemMon != null)
                    {
                        return CustomResult(ResponseMessage.DELETED_SUCCESSFULLY, HttpStatusCode.OK);
                    }
                    return CustomResult(ResponseMessage.DATA_NOT_FOUND, HttpStatusCode.NotFound);
                }
                catch (DbUpdateException)
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
    }
}
