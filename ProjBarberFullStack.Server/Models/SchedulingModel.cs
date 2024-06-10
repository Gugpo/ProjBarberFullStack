using ProjBarberFullStack.Server.Enums;
using System.ComponentModel.DataAnnotations;

namespace ProjBarberFullStack.Server.Models
{
	public class SchedulingModel
	{
		[Key]
		public int Id { get; set; }
        public string Name { get; set; }
        public ServicesEnum Services { get; set; }
		public DateTime SchedulingDate { get; set; }
		public string SchedulingTime { get; set; }
		public DateTime CreationDate { get; set; } = DateTime.Now.ToLocalTime();
		public DateTime ChangeDate { get; set; } = DateTime.Now.ToLocalTime();
	}
}
