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
    public class DiemController : BaseController
    {
        private readonly DiemService _service;
        public DiemController(DiemService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var diems = await _service.GetAll();
                if (diems.Any())
                {
                    return CustomResult(diems, HttpStatusCode.OK);
                }
                return CustomResult(ResponseMessage.EMPTY, HttpStatusCode.NotFound);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("id")]
        public async Task<IActionResult> Details(string maMH, string maLD, string maHV)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var diem = await _service.GetById(maMH, maLD, maHV);
                    if (diem != null)
                    {
                        return CustomResult(diem, HttpStatusCode.OK);
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
        public async Task<IActionResult> Create(DiemCreate dd)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var diem = await _service.Add(dd);
                    return CustomResult(
                        ResponseMessage.CREATED_SUCCESSFULLY,
                        diem,
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
        public async Task<IActionResult> Update(string maMH, string maLD, string maHV, DiemUpdate dd)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var diem = await _service.Update(maMH, maLD, maHV, dd);
                    if (diem != null)
                    {
                        return CustomResult(
                            ResponseMessage.UPDATED_SUCCESSFULLY,
                            diem,
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
        public async Task<IActionResult> Delete(string maMH, string maLD, string maHV)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var diem = await _service.Delete(maMH, maLD, maHV);
                    if (diem != null)
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
