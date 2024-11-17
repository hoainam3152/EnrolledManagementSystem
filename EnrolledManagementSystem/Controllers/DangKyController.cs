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
    public class DangKyController : BaseController
    {
        private readonly DangKyService _service;
        public DangKyController(DangKyService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var dangKys = await _service.GetAll();
                if (dangKys.Any())
                {
                    return CustomResult(dangKys, HttpStatusCode.OK);
                }
                return CustomResult(ResponseMessage.EMPTY, HttpStatusCode.NotFound);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Detail")]
        public async Task<IActionResult> Details(string maHV, string maLH)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var dangKy = await _service.GetById(maHV, maLH);
                    if (dangKy != null)
                    {
                        return CustomResult(dangKy, HttpStatusCode.OK);
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
        public async Task<IActionResult> Create(DangKyRequest dk)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var dangKy = await _service.Add(dk);
                    if (dangKy == null)
                    {
                        var response = await _service.GetById(dk.MaHocVien, dk.MaLopHoc);
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

        [HttpPut]
        public async Task<IActionResult> Update(string maHV, string maLH)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var dangKy = await _service.Update(maHV, maLH);
                    if (dangKy != null)
                    {
                        return CustomResult(
                            ResponseMessage.UPDATED_SUCCESSFULLY,
                            dangKy,
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

        [HttpDelete]
        public async Task<IActionResult> Delete(string maHV, string maLH)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var dangKy = await _service.Delete(maHV, maLH);
                    if (dangKy != null)
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
