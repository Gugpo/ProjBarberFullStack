using ProjBarberFullStack.Server.Models;

namespace ProjBarberFullStack.Server.Services.ServiceSchedule
{
	public interface IScheduleInterface
	{
		Task<ServiceResponseModel<List<ScheduleModel>>> GetSchedule();
		Task<ServiceResponseModel<ScheduleModel>> GetScheduleById(int? id);
		Task<ServiceResponseModel<ScheduleModel>> CreateSchedule(ScheduleModel newScheduling);
		Task<ServiceResponseModel<ScheduleModel>> UpdateSchedule(ScheduleModel updatedScheduling);
		Task<ServiceResponseModel<ScheduleModel>> DeleteSchedule(int? id);
	}
}
