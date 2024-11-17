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
    public class GiangVienController : BaseController
    {
        private readonly GiangVienService _service;
        public GiangVienController(GiangVienService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var giangViens = await _service.GetAll();
                if (giangViens.Any())
                {
                    return CustomResult(giangViens, HttpStatusCode.OK);
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
                    var giangVien = await _service.GetById(id);
                    if (giangVien != null)
                    {
                        return CustomResult(giangVien, HttpStatusCode.OK);
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
        public async Task<IActionResult> Create(GiangVienCreate gv)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var giangVien = await _service.Add(gv);
                    if (giangVien == null)
                    {
                        GiangVienResponse response = new GiangVienResponse()
                        {
                            ID = gv.MaGiangVien,
                            HoTen = gv.Ho + " " + gv.TenDemVaTen,
                            NgaySinh = gv.NgaySinh,
                            GioiTinh = gv.GioiTinh,
                            Email = gv.Email,
                            DienThoai = gv.DienThoai,
                            DiaChi = gv.DiaChi,
                            MaMonDayChinh = gv.MaMonDayChinh,
                            MonDayKiemNhiem = gv.MonDayKiemNhiem,
                            HinhAnh = gv.HinhAnh
                        };
                        return CustomResult(
                            ResponseMessage.CREATED_SUCCESSFULLY,
                            response,
                            HttpStatusCode.Created
                            );
                    }
                    return CustomResult(ResponseMessage.DUPLICATE_KEY, HttpStatusCode.Conflict);
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
        public async Task<IActionResult> Update(string id, GiangVienUpdate gv)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var giangVien = await _service.Update(id, gv);
                    if (giangVien != null)
                    {
                        return CustomResult(
                            ResponseMessage.UPDATED_SUCCESSFULLY,
                            giangVien,
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
        public async Task<IActionResult> Delete(string id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var giangVien = await _service.Delete(id);
                    if (giangVien != null)
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
