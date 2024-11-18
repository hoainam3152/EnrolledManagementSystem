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
    public class PhanQuyenController : BaseController
    {
        private readonly PhanQuyenService _service;
        public PhanQuyenController(PhanQuyenService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var phanQuyens = await _service.GetAll();
                if (phanQuyens.Any())
                {
                    return CustomResult(phanQuyens, HttpStatusCode.OK);
                }
                return CustomResult(ResponseMessage.EMPTY, HttpStatusCode.NotFound);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Detail")]
        public async Task<IActionResult> Details(int maVT, int maQ)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var phanQuyen = await _service.GetById(maVT, maQ);
                    if (phanQuyen != null)
                    {
                        return CustomResult(phanQuyen, HttpStatusCode.OK);
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
        public async Task<IActionResult> Create(PhanQuyenRequest dk)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var phanQuyen = await _service.Add(dk);
                    if (phanQuyen == null)
                    {
                        var response = await _service.GetById(dk.MaVaiTro, dk.MaQuyen);
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

        [HttpDelete]
        public async Task<IActionResult> Delete(int maVT, int maQ)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var phanQuyen = await _service.Delete(maVT, maQ);
                    if (phanQuyen != null)
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
