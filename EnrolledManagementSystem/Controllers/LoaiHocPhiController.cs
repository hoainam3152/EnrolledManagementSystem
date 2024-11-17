using CoreApiResponse;
using EnrolledManagementSystem.DTO.Requests;
using EnrolledManagementSystem.Enums;
using EnrolledManagementSystem.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EnrolledManagementSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoaiHocPhiController : BaseController
    {
        private readonly LoaiHocPhiService _service;

        public LoaiHocPhiController(LoaiHocPhiService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var hocPhis = await _service.GetAll();
                if (hocPhis.Any())
                {
                    return CustomResult(hocPhis, HttpStatusCode.OK);
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
                    var hocPhi = await _service.GetById(id);
                    if (hocPhi != null)
                    {
                        return CustomResult(hocPhi, HttpStatusCode.OK);
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
        public async Task<IActionResult> Create(LoaiHocPhiRequest hp)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var loaiHocPhi = await _service.Add(hp);
                    return CustomResult(
                        ResponseMessage.CREATED_SUCCESSFULLY,
                        loaiHocPhi,
                        HttpStatusCode.Created
                        );
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
        public async Task<IActionResult> Update(int id, LoaiHocPhiRequest hp)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var loaiHocPhi = await _service.Update(id, hp);
                    if (loaiHocPhi != null)
                    {
                        return CustomResult(
                            ResponseMessage.UPDATED_SUCCESSFULLY,
                            loaiHocPhi,
                            HttpStatusCode.OK);
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

        [HttpDelete("id")]
        public async Task<IActionResult> Delete(int id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var loaiHocPhi = await _service.Delete(id);
                    if (loaiHocPhi != null)
                    {
                        return CustomResult(ResponseMessage.DELETED_SUCCESSFULLY, HttpStatusCode.OK);
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
    }
}
