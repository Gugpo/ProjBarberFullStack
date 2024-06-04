namespace ProjBarberFullStack.Server.Models
{
	public class UserModel
	{
		protected int Id { get; set; }
		public string User { get; set; }
		protected string Passoword { get; set; }
		public string Email { get; set; }
		public string Contact { get; set; }
		public DateTime CreationDate { get; set; } = DateTime.Now.ToLocalTime();
		public DateTime ChangeDate { get; set; } = DateTime.Now.ToLocalTime();
	}
}
