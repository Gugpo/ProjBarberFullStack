using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjBarberFullStack.Server.Models;
using ProjBarberFullStack.Server.Services.SchedulingService;

namespace ProjBarberFullStack.Server.Controllers
{
    [Route("api/controller/v2")]
	[ApiController]
	public class SchedulingController : ControllerBase
	{
		private readonly ISchedulingInterface _schedulingInterface;
		public SchedulingController(ISchedulingInterface schedulingInterface)
		{
			_schedulingInterface = schedulingInterface;
		}

		[HttpGet]
		[Route("GetScheduling")]
		public async Task<ActionResult<ServiceResponse<List<SchedulingModel>>>> GetScheduling()
		{
			return Ok(await _schedulingInterface.GetScheduling());
		}

		[HttpGet]
		[Route("GetSchedulingById")]
		public async Task<ActionResult<ServiceResponse<SchedulingModel>>> GetSchedulingById(int id)
		{
			return Ok(await _schedulingInterface.GetSchedulingById(id));
		}

		[HttpPost]
		[Route("CreateScheduling")]
		public async Task<ActionResult<ServiceResponse<SchedulingModel>>> CreateScheduling(SchedulingModel newScheduling)
		{
			return Ok(await _schedulingInterface.CreateScheduling(newScheduling));
		}

		[HttpPut]
		[Route("UpdateScheduling")]
		public async Task<ActionResult<ServiceResponse<SchedulingModel>>> UpdateScheduling(SchedulingModel updateScheduling)
		{
			return Ok(await _schedulingInterface.UpdateScheduling(updateScheduling));
		}

		[HttpDelete]
		[Route("DeleteScheduling")]
		public async Task<ActionResult<ServiceResponse<SchedulingModel>>> DeleteScheduling(int id)
		{
			return Ok(await _schedulingInterface.DeleteScheduling(id));
		}
	}
}
