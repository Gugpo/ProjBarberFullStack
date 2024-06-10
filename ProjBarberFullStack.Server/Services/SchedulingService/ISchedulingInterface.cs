using ProjBarberFullStack.Server.Models;

namespace ProjBarberFullStack.Server.Services.SchedulingService
{
	public interface ISchedulingInterface
	{
		Task<ServiceResponseModel<List<SchedulingModel>>> GetScheduling();
		Task<ServiceResponseModel<SchedulingModel>> GetSchedulingById(int? id);
		Task<ServiceResponseModel<SchedulingModel>> CreateScheduling(SchedulingModel newScheduling);
		Task<ServiceResponseModel<SchedulingModel>> UpdateScheduling(SchedulingModel updatedScheduling);
		Task<ServiceResponseModel<SchedulingModel>> DeleteScheduling(int? id);
	}
}
