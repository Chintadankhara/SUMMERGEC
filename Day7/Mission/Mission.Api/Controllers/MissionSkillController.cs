using Microsoft.AspNetCore.Mvc;
using Mission.Entities.ViewModels;
using Mission.Entities.ViewModels.MissionSkill;
using Mission.Services.IService;

namespace Mission.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MissionSkillController : ControllerBase
    {
        private readonly IMissionSkillService _missionSkillService;

        public MissionSkillController(IMissionSkillService missionSkillService)
        {
            _missionSkillService = missionSkillService;
        }

        [HttpPost("AddMissionSkill")]
        public async Task<IActionResult> AddMissionSkill([FromBody] UpsertMissionSkillRequestModel model)
        {
            if (model == null || string.IsNullOrWhiteSpace(model.SkillName))
            {
                return BadRequest(new ResponseResult
                {
                    Result = ResponseStatus.Error,
                    Message = "Invalid data. Skill name is required."
                });
            }

            await _missionSkillService.AddMissionSkillAsync(model);

            return Ok(new ResponseResult
            {
                Result = ResponseStatus.Success,
                Message = "New Mission Skill added successfully."
            });
        }

        [HttpGet("GetMissionSkillList")]
        public async Task<IActionResult> GetMissionSkillList()
        {
            var response = await _missionSkillService.GetMissionSkillListAsync();

            return Ok(new ResponseResult
            {
                Data = response,
                Result = ResponseStatus.Success
            });
        }

        [HttpGet("GetMissionSkillById/{id:int}")]
        public async Task<IActionResult> GetMissionSkillById(int id)
        {
            var response = await _missionSkillService.GetMissionSkillByIdAsync(id);

            if (response == null)
            {
                return NotFound(new ResponseResult
                {
                    Result = ResponseStatus.Error,
                    Message = "Mission Skill record not found."
                });
            }

            return Ok(new ResponseResult
            {
                Result = ResponseStatus.Success,
                Data = response
            });
        }

        [HttpPost("UpdateMissionSkill")]
        public async Task<IActionResult> UpdateMissionSkill([FromBody] UpsertMissionSkillRequestModel model)
        {
            if (model == null || model.Id <= 0 || string.IsNullOrWhiteSpace(model.SkillName))
            {
                return BadRequest(new ResponseResult
                {
                    Result = ResponseStatus.Error,
                    Message = "Invalid data. ID and Skill name are required."
                });
            }

            var updated = await _missionSkillService.UpdateMissionSkillAsync(model);

            if (!updated)
            {
                return NotFound(new ResponseResult
                {
                    Result = ResponseStatus.Error,
                    Message = "Mission Skill record not found."
                });
            }

            return Ok(new ResponseResult
            {
                Result = ResponseStatus.Success,
                Message = "Mission Skill updated successfully."
            });
        }

        [HttpDelete("DeleteMissionSkill/{id:int}")]
        public async Task<IActionResult> DeleteMissionSkill(int id)
        {
            var deleted = await _missionSkillService.DeleteMissionSkill(id);

            if (!deleted)
            {
                return NotFound(new ResponseResult
                {
                    Result = ResponseStatus.Error,
                    Message = "Mission Skill record not found."
                });
            }

            return Ok(new ResponseResult
            {
                Result = ResponseStatus.Success,
                Message = "Mission Skill deleted successfully."
            });
        }
    }
}
