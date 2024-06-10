using Microsoft.AspNetCore.Mvc;
using ProjBarberFullStack.Server.Models;
using ProjBarberFullStack.Server.Services.ServiceSchedule;

namespace ProjBarberFullStack.Server.Controllers
{
	[Route("api/controller/v3")]
	[ApiController]
	public class ScheduleController : ControllerBase
	{
		private readonly IScheduleInterface _scheduleInterface;
		public ScheduleController(IScheduleInterface scheduleInterface)
		{
			_scheduleInterface = scheduleInterface;
		}

		[HttpGet]
		[Route("GetSchedule")]
		public async Task<ActionResult<ServiceResponseModel<List<ScheduleModel>>>> GetSchedule()
		{
			return Ok(await _scheduleInterface.GetSchedule());
		}

		[HttpGet]
		[Route("GetScheduleById")]
		public async Task<ActionResult<ServiceResponseModel<ScheduleModel>>> GetScheduleById(int id)
		{
			return Ok(await _scheduleInterface.GetScheduleById(id));
		}

		[HttpPost]
		[Route("CreateSchedule")]
		public async Task<ActionResult<ServiceResponseModel<ScheduleModel>>> CreateSchedule(ScheduleModel newSchedule)
		{
			return Ok(await _scheduleInterface.CreateSchedule(newSchedule));
		}

		[HttpPut]
		[Route("UpdateSchedule")]
		public async Task<ActionResult<ServiceResponseModel<ScheduleModel>>> UpdateSchedule(ScheduleModel updateSchedule)
		{
			return Ok(await _scheduleInterface.UpdateSchedule(updateSchedule));
		}

		[HttpDelete]
		[Route("DeleteSchedule")]
		public async Task<ActionResult<ServiceResponseModel<ScheduleModel>>> DeleteSchedule(int id)
		{
			return Ok(await _scheduleInterface.DeleteSchedule(id));
		}
	}
}
