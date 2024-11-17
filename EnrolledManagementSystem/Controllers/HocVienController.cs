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
    public class HocVienController : BaseController
    {
        private readonly HocVienService _service;
        public HocVienController(HocVienService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var hocViens = await _service.GetAll();
                if (hocViens.Any())
                {
                    return CustomResult(hocViens, HttpStatusCode.OK);
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
                    var hocVien = await _service.GetById(id);
                    if (hocVien != null)
                    {
                        return CustomResult(hocVien, HttpStatusCode.OK);
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
        public async Task<IActionResult> Create(HocVienCreate hv)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var hocVien = await _service.Add(hv);
                    if (hocVien == null)
                    {
                        HocVienResponse response = new HocVienResponse()
                        {
                            MaHocVien = hv.MaHocVien,
                            HoTen = hv.Ho + " " + hv.TenDemVaTen,
                            NgaySinh = hv.NgaySinh,
                            GioiTinh = hv.GioiTinh,
                            Email = hv.Email,
                            DienThoai = hv.DienThoai,
                            DiaChi = hv.DiaChi,
                            HoTenPhuHuynh = hv.HoTenPhuHuynh,
                            MaLopHoc = hv.MaLopHoc,
                            HinhAnh = hv.HinhAnh
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
        public async Task<IActionResult> Update(string id, HocVienUpdate hv)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var hocVien = await _service.Update(id, hv);
                    if (hocVien != null)
                    {
                        return CustomResult(
                            ResponseMessage.UPDATED_SUCCESSFULLY,
                            hocVien,
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
                    var hocVien = await _service.Delete(id);
                    if (hocVien != null)
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
