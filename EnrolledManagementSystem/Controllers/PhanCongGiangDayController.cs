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
    public class PhanCongGiangDayController : BaseController
    {
        private readonly PhanCongGiangDayService _service;
        public PhanCongGiangDayController(PhanCongGiangDayService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var phanCongs = await _service.GetAll();
                if (phanCongs.Any())
                {
                    return CustomResult(phanCongs, HttpStatusCode.OK);
                }
                return CustomResult(ResponseMessage.EMPTY, HttpStatusCode.NotFound);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Detail")]
        public async Task<IActionResult> Details(string maLH, string maMH, string maGV)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var phanCong = await _service.GetById(maLH, maMH, maGV);
                    if (phanCong != null)
                    {
                        return CustomResult(phanCong, HttpStatusCode.OK);
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
        public async Task<IActionResult> Create(PhanCongGiangDayCreate pc)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var phanCong = await _service.Add(pc);
                    if (phanCong == null)
                    {
                        return CustomResult(
                            ResponseMessage.CREATED_SUCCESSFULLY,
                            pc,
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
        public async Task<IActionResult> Update(string maLH, string maMH, string maGV, PhanCongGiangDayUpdate pc)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var phanCong = await _service.Update(maLH, maMH, maGV, pc);
                    if (phanCong != null)
                    {
                        return CustomResult(
                            ResponseMessage.UPDATED_SUCCESSFULLY,
                            phanCong,
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
        public async Task<IActionResult> Delete(string maLH, string maMH, string maGV)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var phanCong = await _service.Delete(maLH, maMH, maGV);
                    if (phanCong != null)
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
