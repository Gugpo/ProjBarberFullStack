using System.ComponentModel.DataAnnotations;

namespace ProjBarberFullStack.Server.Models
{
	public class ScheduleModel
	{
		[Key]
		public int Id { get; set; }
		public string? Name { get; set; }
		public DateTime ScheduleDate { get; set; }
		public string? ScheduleTime { get; set; }
		public DateTime CreationDate { get; set; } = DateTime.Now.ToLocalTime();
		public DateTime ChangeDate { get; set; } = DateTime.Now.ToLocalTime();
	}
}
