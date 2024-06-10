using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjBarberFullStack.Server.Models;
using ProjBarberFullStack.Server.Services.SchedulingService;

namespace ProjBarberFullStack.Server.Controllers
{
    [Route("api/scheduling")]
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
		public async Task<ActionResult<ServiceResponseModel<List<SchedulingModel>>>> GetScheduling()
		{
			return Ok(await _schedulingInterface.GetScheduling());
		}

		[HttpGet]
		[Route("GetSchedulingById")]
		public async Task<ActionResult<ServiceResponseModel<SchedulingModel>>> GetSchedulingById(int id)
		{
			return Ok(await _schedulingInterface.GetSchedulingById(id));
		}

		[HttpPost]
		[Route("CreateScheduling")]
		public async Task<ActionResult<ServiceResponseModel<SchedulingModel>>> CreateScheduling(SchedulingModel newScheduling)
		{
			return Ok(await _schedulingInterface.CreateScheduling(newScheduling));
		}

		[HttpPut]
		[Route("UpdateScheduling")]
		public async Task<ActionResult<ServiceResponseModel<SchedulingModel>>> UpdateScheduling(SchedulingModel updateScheduling)
		{
			return Ok(await _schedulingInterface.UpdateScheduling(updateScheduling));
		}

		[HttpDelete]
		[Route("DeleteScheduling")]
		public async Task<ActionResult<ServiceResponseModel<SchedulingModel>>> DeleteScheduling(int id)
		{
			return Ok(await _schedulingInterface.DeleteScheduling(id));
		}
	}
}
