using ProjBarberFullStack.Server.Models;

namespace ProjBarberFullStack.Server.Services.SchedulingService
{
	public interface ISchedulingInterface
	{
		Task<ServiceResponse<List<SchedulingModel>>> GetScheduling();
		Task<ServiceResponse<SchedulingModel>> GetSchedulingById(int? id);
		Task<ServiceResponse<SchedulingModel>> CreateScheduling(SchedulingModel newScheduling);
		Task<ServiceResponse<SchedulingModel>> UpdateScheduling(SchedulingModel updatedScheduling);
		Task<ServiceResponse<SchedulingModel>> DeleteScheduling(int? id);
	}
}
